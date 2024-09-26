using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseRentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabeseWithInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7890-ab12-c3de4f567890"), 0, "7f3fbb67-83a1-4c8a-9376-77d5bc93e96e", "agent@mail.com", true, true, null, "AGENT@MAIL.COM", "AGENT@MAIL.COM", "AQAAAAIAAYagAAAAEHbP8eVfaxfCTSSF0IIX0t4mogK9k0ROxqwIdfR5AeLFoIm3nwSrRrVH1WKAnQ8b+A==", null, false, "XKYK5BIDWLG3ED57QZYQHRLUZMMUVYWS", false, "agent@mail.com" },
                    { new Guid("f7e8d9a0-b1c2-34d5-6789-f01ab2c345de"), 0, "5d4fdb87-23b1-4da2-9e3e-a8b4df7a283f", "guest@mail.com", true, true, null, "GUEST@MAIL.COM", "GUEST@MAIL.COM", "AQAAAAIAAYagAAAAEJFPnOD8vSvNRc3QXa51npQD1l3TXXKIpBZXYU3J+YZIEvMM4Uyy0MUlfBAt9ZWI/Q==", null, false, "JTHY3GADWFA4KD67TFYUIUQNLJMNXYAS", false, "guest@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cottage" },
                    { 2, "Single-Family" },
                    { 3, "Duplex" }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("bae99276-1865-4c63-899c-093d3b85f014"), "+359888888888", new Guid("a1b2c3d4-e5f6-7890-ab12-c3de4f567890") });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "PricePerMonth", "RenterId", "Title", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("171c4809-7e29-425c-a2b0-0bdf64164fd1"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("bae99276-1865-4c63-899c-093d3b85f014"), 2, new DateTime(2024, 9, 26, 17, 13, 13, 521, DateTimeKind.Local).AddTicks(9598), "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", true, 2000.00m, null, "Grand House", new DateTime(2024, 9, 26, 17, 13, 13, 521, DateTimeKind.Local).AddTicks(9604) },
                    { new Guid("b4459c52-1ecb-4a69-bb0d-e5c03c7e75e3"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("bae99276-1865-4c63-899c-093d3b85f014"), 2, new DateTime(2024, 9, 26, 17, 13, 13, 521, DateTimeKind.Local).AddTicks(9591), "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", true, 1200.00m, null, "Family House Comfort", new DateTime(2024, 9, 26, 17, 13, 13, 521, DateTimeKind.Local).AddTicks(9593) },
                    { new Guid("fc905073-5b8d-4d39-9724-9c58552864b1"), "North London, UK (near the border)", new Guid("bae99276-1865-4c63-899c-093d3b85f014"), 3, new DateTime(2024, 9, 26, 17, 13, 13, 521, DateTimeKind.Local).AddTicks(9491), "A big house for your whole family. Don't miss to buy a house with three bedrooms.", "https://www.luxury-architecture.net/wp-content/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg", true, 2100.00m, new Guid("f7e8d9a0-b1c2-34d5-6789-f01ab2c345de"), "Big House Marina", new DateTime(2024, 9, 26, 17, 13, 13, 521, DateTimeKind.Local).AddTicks(9563) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("171c4809-7e29-425c-a2b0-0bdf64164fd1"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("b4459c52-1ecb-4a69-bb0d-e5c03c7e75e3"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("fc905073-5b8d-4d39-9724-9c58552864b1"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("bae99276-1865-4c63-899c-093d3b85f014"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f7e8d9a0-b1c2-34d5-6789-f01ab2c345de"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-ab12-c3de4f567890"));
        }
    }
}
