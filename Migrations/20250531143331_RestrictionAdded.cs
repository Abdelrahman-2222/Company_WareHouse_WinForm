using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyForm.Migrations
{
    /// <inheritdoc />
    public partial class RestrictionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TransferOperations_TransferOperationNumber",
                table: "TransferOperations",
                column: "TransferOperationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DisbursementVouchers_DisbursementVoucherNumber",
                table: "DisbursementVouchers",
                column: "DisbursementVoucherNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TransferOperations_TransferOperationNumber",
                table: "TransferOperations");

            migrationBuilder.DropIndex(
                name: "IX_DisbursementVouchers_DisbursementVoucherNumber",
                table: "DisbursementVouchers");
        }
    }
}
