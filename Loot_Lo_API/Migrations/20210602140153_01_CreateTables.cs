using Microsoft.EntityFrameworkCore.Migrations;

namespace Loot_Lo_API.Migrations
{
    public partial class _01_CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "varchar(20)", nullable: true),
                    AdminEmail = table.Column<string>(type: "varchar(20)", nullable: true),
                    AdminPassword = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "varchar(20)", nullable: true),
                    CustomerEmail = table.Column<string>(type: "varchar(20)", nullable: true),
                    CustomerPassword = table.Column<string>(type: "varchar(20)", nullable: true),
                    CustomerAddress = table.Column<string>(type: "varchar(100)", nullable: true),
                    CustomerPhoneNo = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "varchar(20)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(20)", nullable: true),
                    CategoryRefId = table.Column<int>(type: "int", nullable: false),
                    AdminRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Admin_AdminRefId",
                        column: x => x.AdminRefId,
                        principalTable: "Admin",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryRefId",
                        column: x => x.CategoryRefId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerRefId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrderDetails", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_CustomerOrderDetails_Customer_CustomerRefId",
                        column: x => x.CustomerRefId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderedProductQuantity",
                columns: table => new
                {
                    OrderedProductQuantityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductRefId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedProductQuantity", x => x.OrderedProductQuantityId);
                    table.ForeignKey(
                        name: "FK_OrderedProductQuantity_CustomerOrderDetails_OrderRefId",
                        column: x => x.OrderRefId,
                        principalTable: "CustomerOrderDetails",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderedProductQuantity_Product_ProductRefId",
                        column: x => x.ProductRefId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrderDetails_CustomerRefId",
                table: "CustomerOrderDetails",
                column: "CustomerRefId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProductQuantity_OrderRefId",
                table: "OrderedProductQuantity",
                column: "OrderRefId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProductQuantity_ProductRefId",
                table: "OrderedProductQuantity",
                column: "ProductRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_AdminRefId",
                table: "Product",
                column: "AdminRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryRefId",
                table: "Product",
                column: "CategoryRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderedProductQuantity");

            migrationBuilder.DropTable(
                name: "CustomerOrderDetails");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
