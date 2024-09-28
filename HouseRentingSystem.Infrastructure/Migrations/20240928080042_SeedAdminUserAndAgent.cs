using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseRentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUserAndAgent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-ab12-c3de4f567890"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFpL0R3tKFOyOl3a+e2SQHBwgFr71LEwBq7kxg/4RY8FFToTxdHpi7BURQsTVCRaWw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f7e8d9a0-b1c2-34d5-6789-f01ab2c345de"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJf9gZDQpvNuXvyw7CYON5dmgMdpaPYjsC72qa2Fy8IJu8vDO4DvVT9lUXClylXouw==");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("bcb4f072-ecca-43c9-ab26-c060c6f364e4"), 0, "a2e5bc24-9e10-4e5e-90b3-94a5c8f4a1c6", "admin@mail.com", true, "Great", "Admin", true, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEKDLplCqADyddicHX8N1kM/cowmTFrDApLe8XEC6KYFF8t1oM6JalRwNEZVkUxbwZg==", null, false, "7EFH3KADWFA4KD67TFYUIUQNLKJHYPLS", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "PricePerMonth", "RenterId", "Title", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("7a431113-eaa1-4508-800b-08176e7b217f"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("bae99276-1865-4c63-899c-093d3b85f014"), 2, new DateTime(2024, 9, 28, 11, 0, 41, 280, DateTimeKind.Local).AddTicks(6423), "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", true, 2000.00m, null, "Grand House", new DateTime(2024, 9, 28, 11, 0, 41, 280, DateTimeKind.Local).AddTicks(6430) },
                    { new Guid("88827f13-3e7c-455e-b843-9acd9d2fae7b"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("bae99276-1865-4c63-899c-093d3b85f014"), 2, new DateTime(2024, 9, 28, 11, 0, 41, 280, DateTimeKind.Local).AddTicks(6412), "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", true, 1200.00m, null, "Family House Comfort", new DateTime(2024, 9, 28, 11, 0, 41, 280, DateTimeKind.Local).AddTicks(6414) },
                    { new Guid("bcebe4ef-0369-4799-8c3e-14078eb172e4"), "North London, UK (near the border)", new Guid("bae99276-1865-4c63-899c-093d3b85f014"), 3, new DateTime(2024, 9, 28, 11, 0, 41, 280, DateTimeKind.Local).AddTicks(6224), "A big house for your whole family. Don't miss to buy a house with three bedrooms.", "https://www.luxury-architecture.net/wp-content/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg", true, 2100.00m, new Guid("f7e8d9a0-b1c2-34d5-6789-f01ab2c345de"), "Big House Marina", new DateTime(2024, 9, 28, 11, 0, 41, 280, DateTimeKind.Local).AddTicks(6310) }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("d038a75f-fcb7-475c-b36c-ab312ef170be"), "+359123456789", new Guid("bcb4f072-ecca-43c9-ab26-c060c6f364e4") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("d038a75f-fcb7-475c-b36c-ab312ef170be"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("7a431113-eaa1-4508-800b-08176e7b217f"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("88827f13-3e7c-455e-b843-9acd9d2fae7b"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("bcebe4ef-0369-4799-8c3e-14078eb172e4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bcb4f072-ecca-43c9-ab26-c060c6f364e4"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-ab12-c3de4f567890"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEC26Vfvma+uWOpFICBhkWJXrr2Lg96FaA4kKdC/Esg6eHr/bmQjqShy7VpF2DF0yIg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f7e8d9a0-b1c2-34d5-6789-f01ab2c345de"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEO8km7pqNOwcFwrA4iGW9z1OnjVTpk1vW/6N6QmjBOK4LzEN/NsfT7FmLUhn6LSikg==");

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
    }
}
