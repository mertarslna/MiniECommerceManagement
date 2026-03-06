using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniECommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Elektronik", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Giyim", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Ev & Yaşam", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Kitap & Hobi", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Spor & Outdoor", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "IsActive", "Name", "Password", "UpdatedDate", "UserType" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "mert@admin.com", true, "Mert Arslan", "056B51B6C969185BCF98534F9ED29A2F:703828C8E6074862C3442ADB52F344D85745EB84C5BCF3844EC94F8DAC607B0B", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmet@test.com", true, "Ahmet Yılmaz", "A2C6277F6E175DBD274B30FCC6850BC9:A533BB0AB835AEA393AC6BB2145B811C8042B9CD16D2508038D57A1E4722F918", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "ayse@test.com", true, "Ayşe Demir", "014FFDD5FD8A01F31A0B10B330D13A09:F076DB6AAB0C1D208D6016FE48619EEDE453E8C11AF5A2399166263A4CE62642", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet@test.com", true, "Mehmet Can", "216A2AA79AD9F041DDD6F1ADAE0AD0DC:FA2C5C6943D84033BE67DF98E8E1BF848747E77ABC7EF1C4002DCBD5A10F34BB", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "zeynep@test.com", true, "Zeynep Kaya", "40517A96B1D67CF627417E46F922B58D:78874F32991533EB6DB25B15F2841D8E2CACF3547D75E3112F63D982301F6675", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedDate", "IsActive", "OrderNumber", "Status", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "ORD-001", 4, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "ORD-002", 1, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "ORD-003", 3, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 4, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "ORD-004", 5, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 5, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "ORD-005", 2, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "ImageUrl", "IsActive", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, "Oyuncu Laptop", 35000m, 15, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, "Siyah Tişört", 300m, 100, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, "Kahve Makinesi", 4500m, 20, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, "Dünya Tarihi Kitabı", 150m, 50, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, "Yoga Matı", 600m, 30, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "CreatedDate", "IsActive", "OrderId", "ProductId", "Quantity", "UnitPrice", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 1, 1, 35000m, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 2, 1, 300m, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 3, 1, 4500m, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 2, 1, 300m, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 5, 1, 600m, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
