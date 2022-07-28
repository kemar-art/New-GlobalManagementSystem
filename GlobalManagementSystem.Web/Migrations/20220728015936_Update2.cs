using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalManagementSystem.Web.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "e36c0345-3ca1-4f12-8c25-5598a731e7f2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eba7548ff-da7d-475a-b17c-a200ad79f77a",
                column: "ConcurrencyStamp",
                value: "8e6e9cea-15b1-45da-84a7-9b9ad6fdfb0b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f127aa8-a53b-471f-ab80-877381474d56",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ef46c9b-e5a1-4ff0-80d8-065ed3357f2f", "AQAAAAEAACcQAAAAEHLEfJ0FcWe5+Vu9o8i+N65CP/QWQ+CJVcgZvoYU9LSqlNKsyyNgRz+8Gt7n1hDUAg==", "903050e2-898a-4b10-bea8-92c8d2cbcbb6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef7547bf-bd4d-485c-b761-a211dd47fa9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d961b472-3543-440d-a7ec-5c18b64311b5", "AQAAAAEAACcQAAAAEC5ifG/ZkgnTFVIThcDsDiPp7IRTfTxw3+mNBDTszcXXvL9xiiDuH9vGNWSEpBTDhQ==", "d854bcbb-6b1c-4359-8709-df6c371d613c" });
        }
    }
}
