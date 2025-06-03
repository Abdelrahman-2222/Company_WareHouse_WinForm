using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyForm.Migrations
{
    /// <inheritdoc />
    public partial class ModificationExpirationColoumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SupplyVoucherListDaysUntilExpiration",
                table: "SupplyVoucherLists",
                type: "int",
                nullable: false,
                computedColumnSql: "DATEDIFF(day, GETDATE(), SupplyVoucherListExpirationDate)",
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SupplyVoucherListDaysUntilExpiration",
                table: "SupplyVoucherLists",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "DATEDIFF(day, GETDATE(), SupplyVoucherListExpirationDate)");
        }
    }
}
