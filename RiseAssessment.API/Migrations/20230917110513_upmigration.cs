using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RiseAssessment.API.Migrations
{
    public partial class upmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2a825030-61aa-4e75-adad-f656b09954e3"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { new Guid("34869794-d4cb-4b68-bcec-01d29a6fd0e9"), new DateTime(2023, 9, 17, 14, 5, 13, 328, DateTimeKind.Local).AddTicks(3002), "demo@user.com", "user", "demo", "demouser1", "demouser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("34869794-d4cb-4b68-bcec-01d29a6fd0e9"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { new Guid("2a825030-61aa-4e75-adad-f656b09954e3"), new DateTime(2023, 9, 17, 13, 11, 13, 332, DateTimeKind.Local).AddTicks(8034), "demo@user.com", "user", "demo", "demouser1", "demouser" });
        }
    }
}
