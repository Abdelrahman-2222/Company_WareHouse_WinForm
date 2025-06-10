using System;
using System.ComponentModel.DataAnnotations;

namespace CompanyForm.Entities
{
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public UserRole Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastLogin { get; set; }
    }

    public enum UserRole
    {
        Owner,
        Customer,
        Supplier
    }
}