using System;
using System.Linq;
using System.Security.Cryptography;
using CompanyForm.Entities;
using CompnayForm.Context;
using Microsoft.EntityFrameworkCore;

namespace CompanyForm.Services
{
    public class AuthService
    {
        private readonly CompanyWarehouseContext _context;
        public static AppUser CurrentUser { get; private set; }

        public AuthService(CompanyWarehouseContext context)
        {
            _context = context;
        }

        public bool RegisterUser(string username, string password, string email, UserRole role)
        {
            if (_context.Users.Any(u => u.Username == username || u.Email == email))
                return false;

            var user = new AppUser
            {
                Username = username,
                PasswordHash = HashPassword(password),
                Email = email,
                Role = role,
                CreatedAt = DateTime.Now
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public bool Login(string username, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Username == username);

            if (user == null || !VerifyPassword(password, user.PasswordHash))
                return false;

            user.LastLogin = DateTime.Now;
            _context.SaveChanges();

            CurrentUser = user;
            return true;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}