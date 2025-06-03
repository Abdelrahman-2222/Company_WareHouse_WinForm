using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyForm.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    CustomerMobileNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerFax = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: true),
                    CustomerPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SupplierEmail = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    SupplierMobileNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasurements",
                columns: table => new
                {
                    UnitOfMeasurementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitOfMeasurementName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasurements", x => x.UnitOfMeasurementId);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    WarehouseAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WarehousePersonName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseId);
                });

            migrationBuilder.CreateTable(
                name: "ItemUnitOfMeasurements",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasurementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemUnitOfMeasurements", x => new { x.ItemId, x.UnitOfMeasurementId });
                    table.ForeignKey(
                        name: "FK_ItemUnitOfMeasurements_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemUnitOfMeasurements_UnitOfMeasurements_UnitOfMeasurementId",
                        column: x => x.UnitOfMeasurementId,
                        principalTable: "UnitOfMeasurements",
                        principalColumn: "UnitOfMeasurementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisbursementVouchers",
                columns: table => new
                {
                    DisbursementVoucherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisbursementVoucherNumber = table.Column<int>(type: "int", nullable: false),
                    DisbursementVoucherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisbursementVouchers", x => x.DisbursementVoucherId);
                    table.ForeignKey(
                        name: "FK_DisbursementVouchers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisbursementVouchers_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplyVouchers",
                columns: table => new
                {
                    SupplyVoucherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplyVoucherNumber = table.Column<int>(type: "int", nullable: false),
                    SupplyVoucherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyVouchers", x => x.SupplyVoucherId);
                    table.ForeignKey(
                        name: "FK_SupplyVouchers_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplyVouchers_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransferOperations",
                columns: table => new
                {
                    TransferOperationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferOperationNumber = table.Column<int>(type: "int", nullable: false),
                    TransferOperationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    FromWarehouseId = table.Column<int>(type: "int", nullable: false),
                    ToWarehouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferOperations", x => x.TransferOperationId);
                    table.ForeignKey(
                        name: "FK_TransferOperations_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferOperations_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferOperations_Warehouses_FromWarehouseId",
                        column: x => x.FromWarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferOperations_Warehouses_ToWarehouseId",
                        column: x => x.ToWarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DisbursementVoucherLists",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    DisbursementVoucherId = table.Column<int>(type: "int", nullable: false),
                    DisbursementVoucherListQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisbursementVoucherLists", x => new { x.DisbursementVoucherId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_DisbursementVoucherLists_DisbursementVouchers_DisbursementVoucherId",
                        column: x => x.DisbursementVoucherId,
                        principalTable: "DisbursementVouchers",
                        principalColumn: "DisbursementVoucherId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisbursementVoucherLists_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplyVoucherLists",
                columns: table => new
                {
                    SupplyVoucherId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    SupplyVoucherListQuantity = table.Column<int>(type: "int", nullable: false),
                    SupplyVoucherListProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplyVoucherListExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplyVoucherListDaysUntilExpiration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyVoucherLists", x => new { x.SupplyVoucherId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_SupplyVoucherLists_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplyVoucherLists_SupplyVouchers_SupplyVoucherId",
                        column: x => x.SupplyVoucherId,
                        principalTable: "SupplyVouchers",
                        principalColumn: "SupplyVoucherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisbursementVoucherLists_ItemId",
                table: "DisbursementVoucherLists",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DisbursementVouchers_CustomerId",
                table: "DisbursementVouchers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DisbursementVouchers_WarehouseId",
                table: "DisbursementVouchers",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemCode",
                table: "Items",
                column: "ItemCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemUnitOfMeasurements_UnitOfMeasurementId",
                table: "ItemUnitOfMeasurements",
                column: "UnitOfMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyVoucherLists_ItemId",
                table: "SupplyVoucherLists",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyVouchers_SupplierId",
                table: "SupplyVouchers",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyVouchers_SupplyVoucherNumber",
                table: "SupplyVouchers",
                column: "SupplyVoucherNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupplyVouchers_WarehouseId",
                table: "SupplyVouchers",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOperations_FromWarehouseId",
                table: "TransferOperations",
                column: "FromWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOperations_ItemId",
                table: "TransferOperations",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOperations_SupplierId",
                table: "TransferOperations",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOperations_ToWarehouseId",
                table: "TransferOperations",
                column: "ToWarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisbursementVoucherLists");

            migrationBuilder.DropTable(
                name: "ItemUnitOfMeasurements");

            migrationBuilder.DropTable(
                name: "SupplyVoucherLists");

            migrationBuilder.DropTable(
                name: "TransferOperations");

            migrationBuilder.DropTable(
                name: "DisbursementVouchers");

            migrationBuilder.DropTable(
                name: "UnitOfMeasurements");

            migrationBuilder.DropTable(
                name: "SupplyVouchers");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
