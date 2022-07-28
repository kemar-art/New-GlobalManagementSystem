using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalManagementSystem.Web.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "88417fda-4a53-4149-8798-bac3269a323c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eba7548ff-da7d-475a-b17c-a200ad79f77a",
                column: "ConcurrencyStamp",
                value: "4aaecdef-a7b1-46ec-8d10-ac6d91a95e34");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f127aa8-a53b-471f-ab80-877381474d56",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c81ae33-48f5-418d-994d-91207931a4c6", "AQAAAAEAACcQAAAAEIWj2KKJ/UMbtU9W4q30JbyYVre0rY5HXnbLMLgLRjIX5DRGYmMbAuVLUbWH/Z9T8w==", "23fc77cb-f69b-456b-a1a0-5a01aa2be5db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef7547bf-bd4d-485c-b761-a211dd47fa9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2250570-1840-484e-8f6f-dd8198be6ee5", "AQAAAAEAACcQAAAAEC/qLphIYYIxopCOjPTNWraIYrYav6H7Qm4JT1ejb6ekBKo2mknsFuVhW0KyPCyUZA==", "49263707-c8f9-4b28-a8d6-ff3aed79ec39" });
        }
    }
}
