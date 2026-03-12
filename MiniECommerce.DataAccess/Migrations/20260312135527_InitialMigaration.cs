using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniECommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigaration : Migration
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
                    { 1, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "mert@admin.com", true, "Mert Arslan", "A9D3056C7FE16B831EB03261AD8DF04F:3869373228CABC2E12604D5C1E815AB90D20F4CCCFC2158C79395E7EF6DF11DF", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmet@test.com", true, "Ahmet Yılmaz", "A2434DCEAE475B59AC8C507968B11957:7DD849B3A7DA9D7AB775CB40A8FC32BA3792445E752D5ED498F282C102171049", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "ayse@test.com", true, "Ayşe Demir", "28C8CCAE307A53B80270A0209D20E630:FF46DCE7A19C77C9187C256C008EBB79F016D02EC2331F682806FEB3720221E5", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet@test.com", true, "Mehmet Can", "3B2D5F2179E80C35B831BCEB904F60E7:815944181A9A08D3E478644BD86FC29C771A1FC551080F417DFFF3223DF41006", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "zeynep@test.com", true, "Zeynep Kaya", "5063BD3BF2514F0A5DA7FC8695E13730:BB54947790F7698A12A5A2D30CED3CD2D5F22756500F6A65E02F47DACC7D03D5", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
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
