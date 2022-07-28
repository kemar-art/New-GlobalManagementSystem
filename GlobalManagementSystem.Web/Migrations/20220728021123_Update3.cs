using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalManagementSystem.Web.Migrations
{
    public partial class Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "New",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "Used",
                table: "Conditions");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "17ff9d73-7b0a-45e1-8d80-82a36a414dca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eba7548ff-da7d-475a-b17c-a200ad79f77a",
                column: "ConcurrencyStamp",
                value: "93f22c23-fc85-4cbe-b32f-03f3ab51dbd9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f127aa8-a53b-471f-ab80-877381474d56",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ce7303c-58f6-4620-be4a-01858b0d130f", "AQAAAAEAACcQAAAAEBCDBZyX9urR2okCzTolyzcEPZTgdYZWXTjo9i1oEk4BLDu7dfadv3mPJS+4wQPEQQ==", "59d8a063-7156-4586-8979-b0b6d8c8ebd8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef7547bf-bd4d-485c-b761-a211dd47fa9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bb80c5d-16fa-4db5-9374-a4d8c4276b03", "AQAAAAEAACcQAAAAEEmIx4wehVRA9a7r5D5CFpdScVYQ9dcz73JWavpU+cUQ0kabOY9ILoJ9g1cIha/q9w==", "799660af-3ef7-4a5c-ab45-0d2cdb8d22e9" });

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "New");

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Used");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "New",
                table: "Conditions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Used",
                table: "Conditions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "b8f536cb-21bb-4c44-a27f-effd0fb12275");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eba7548ff-da7d-475a-b17c-a200ad79f77a",
                column: "ConcurrencyStamp",
                value: "74b7c9cc-5256-411f-97d4-ecd6f9bf890a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f127aa8-a53b-471f-ab80-877381474d56",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8be61be6-601c-417b-89ac-a2cfd2f44355", "AQAAAAEAACcQAAAAEKFjI4lvJMTTNimK24J4UCy7taC3EbeXxhLmVUYdqKbqiLue8xnYbS6VAdrKcSIuQQ==", "4a201546-a176-47bf-aecf-0342ff3ece9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef7547bf-bd4d-485c-b761-a211dd47fa9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f675d721-895d-430b-b699-e5db063d36d0", "AQAAAAEAACcQAAAAEAMPcwip4ZPnJg950csEZTNk8vfdAGfodYa3QdMcoEzadQgTqGWPGe6+DApZaNHhEQ==", "ca14806b-15c5-4c17-8e51-74658b354d7f" });

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: null);
        }
    }
}
