Company Warehouse Management System
A comprehensive .NET Windows Forms application for managing warehouse operations, inventory, suppliers, and customers.
Features
•	Warehouse Management: Create, update, and delete warehouse records
•	Inventory Control: Track items across warehouses with detailed information
•	Supplier Management: Maintain supplier contacts and relationships
•	Customer Management: Track customer information and orders
•	Voucher System:
•	Supply vouchers for incoming inventory with expiration tracking
•	Disbursement vouchers for outgoing inventory
•	Transfer Operations: Move inventory between warehouses
Tech Stack
•	.NET 8.0 with Windows Forms
•	Entity Framework Core 8.0.16 for data access
•	SQL Server database backend
•	Dependency Injection via Microsoft Extensions
•	Configuration Management using appsettings.json
Getting Started
Prerequisites
•	Visual Studio 2022 or newer
•	.NET 8.0 SDK
•	SQL Server (Express or higher)
Setup
1.	Clone the repository
2.	Create a database in SQL Server
3.	Configure connection string in appsettings.json:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true"
  }
}
4.	Run Entity Framework migrations to create the database schema:
5.	Build and run the application
Usage
Main Interface
The application provides role-based access:
•	Owner interface for warehouse and inventory management
•	Customer interface for customer operations
Data Management
The system supports full CRUD operations for:
•	Warehouses with location and manager information
•	Inventory items with unit measurements
•	Suppliers with contact details
•	Customers with comprehensive contact information
Voucher Operations
•	Supply Vouchers: Track incoming inventory with expiration dates
•	Disbursement Vouchers: Record outgoing inventory to customers
Project Structure
•	Context: Database context and configuration
•	Entities: Entity models with validation
•	Forms: User interface components
Database Schema
The system uses a relational database with properly defined relationships:
•	One-to-many relationships between warehouses and vouchers
•	Many-to-many relationships between items and units of measurement
•	Composite keys for voucher list entries
   
