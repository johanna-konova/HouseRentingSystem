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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7890-ab12-c3de4f567890"), 0, "7f3fbb67-83a1-4c8a-9376-77d5bc93e96e", "agent@mail.com", true, "Linda", "Michaels", true, null, "AGENT@MAIL.COM", "AGENT@MAIL.COM", "AQAAAAIAAYagAAAAEC26Vfvma+uWOpFICBhkWJXrr2Lg96FaA4kKdC/Esg6eHr/bmQjqShy7VpF2DF0yIg==", null, false, "XKYK5BIDWLG3ED57QZYQHRLUZMMUVYWS", false, "agent@mail.com" },
                    { new Guid("f7e8d9a0-b1c2-34d5-6789-f01ab2c345de"), 0, "5d4fdb87-23b1-4da2-9e3e-a8b4df7a283f", "guest@mail.com", true, "Teodor", "Lesly", true, null, "GUEST@MAIL.COM", "GUEST@MAIL.COM", "AQAAAAIAAYagAAAAEO8km7pqNOwcFwrA4iGW9z1OnjVTpk1vW/6N6QmjBOK4LzEN/NsfT7FmLUhn6LSikg==", null, false, "JTHY3GADWFA4KD67TFYUIUQNLJMNXYAS", false, "guest@mail.com" }
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
                    { new Guid("4752ad08-caf5-45a8-acc8-5133eade4f6a"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("bae99276-1865-4c63-899c-093d3b85f014"), 2, new DateTime(2024, 9, 27, 17, 23, 55, 71, DateTimeKind.Local).AddTicks(1845), "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", true, 1200.00m, null, "Family House Comfort", new DateTime(2024, 9, 27, 17, 23, 55, 71, DateTimeKind.Local).AddTicks(1846) },
                    { new Guid("5a5c3878-8630-4bbb-aef4-7e3dfff5a348"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("bae99276-1865-4c63-899c-093d3b85f014"), 2, new DateTime(2024, 9, 27, 17, 23, 55, 71, DateTimeKind.Local).AddTicks(1851), "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", true, 2000.00m, null, "Grand House", new DateTime(2024, 9, 27, 17, 23, 55, 71, DateTimeKind.Local).AddTicks(1852) },
                    { new Guid("6fa066cf-3538-4c34-aac0-5805d4b89c38"), "North London, UK (near the border)", new Guid("bae99276-1865-4c63-899c-093d3b85f014"), 3, new DateTime(2024, 9, 27, 17, 23, 55, 71, DateTimeKind.Local).AddTicks(1768), "A big house for your whole family. Don't miss to buy a house with three bedrooms.", "https://www.luxury-architecture.net/wp-content/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg", true, 2100.00m, new Guid("f7e8d9a0-b1c2-34d5-6789-f01ab2c345de"), "Big House Marina", new DateTime(2024, 9, 27, 17, 23, 55, 71, DateTimeKind.Local).AddTicks(1826) }
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
                keyValue: new Guid("4752ad08-caf5-45a8-acc8-5133eade4f6a"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("5a5c3878-8630-4bbb-aef4-7e3dfff5a348"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("6fa066cf-3538-4c34-aac0-5805d4b89c38"));

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
