using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Migrations
{
    public partial class Cars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_type",
                table: "cars",
                newName: "Types");

            migrationBuilder.RenameColumn(
                name: "id_localisation",
                table: "cars",
                newName: "Localisations");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c37ed34e-eba4-4f30-a8a6-a8489505f40c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "4d65a292-98d0-488a-8b10-9a9a3e57bc6f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb2fc929-12ee-4507-a208-87ab677ebb60", "AQAAAAEAACcQAAAAEPlN4EuOaCQhkydFFmSdD90MD5VLUwUzoy8DttTq93GgFObJArsjwXZONCwZFsD+Sw==", "01b6febe-57f5-4969-a414-5379a6f3018a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74790a12-cd22-42e5-9256-ecbed2e28c7e", "AQAAAAEAACcQAAAAENt+s26L7snVlCrTUYB8vDYOLVLz1vheex+55Fvo3ULXfI5QtTJwwhpZa5iwG7YsNA==", "40314b10-1bd3-4190-a815-84131660a060" });

            migrationBuilder.CreateIndex(
                name: "IX_cars_Localisations",
                table: "cars",
                column: "Localisations");

            migrationBuilder.CreateIndex(
                name: "IX_cars_Types",
                table: "cars",
                column: "Types");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_localisations_Localisations",
                table: "cars",
                column: "Localisations",
                principalTable: "localisations",
                principalColumn: "id_localisation",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cars_types_Types",
                table: "cars",
                column: "Types",
                principalTable: "types",
                principalColumn: "id_type",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_localisations_Localisations",
                table: "cars");

            migrationBuilder.DropForeignKey(
                name: "FK_cars_types_Types",
                table: "cars");

            migrationBuilder.DropIndex(
                name: "IX_cars_Localisations",
                table: "cars");

            migrationBuilder.DropIndex(
                name: "IX_cars_Types",
                table: "cars");

            migrationBuilder.RenameColumn(
                name: "Types",
                table: "cars",
                newName: "id_type");

            migrationBuilder.RenameColumn(
                name: "Localisations",
                table: "cars",
                newName: "id_localisation");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "3aa8933c-a9c2-4ad0-bfbb-e87c43b5009e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "c464c3a8-1cab-478a-93be-cef8fbc92df5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7f5aeb7-4712-4cab-8a62-bc7f5741873f", "AQAAAAEAACcQAAAAEEtSbqPndVN4F87arNLWmJRfrROdSYBkJrlEzzChoKzfYFgoOOKMJARntmAMdWWfbA==", "5eafab97-4d6e-4a4a-81bf-a152bec4c5fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c9919bc-feaf-4b32-ac08-b4b1907093dc", "AQAAAAEAACcQAAAAEBxc5vXyELAfUhbCB3W95qbQlXy+0XitlIto0mmpuSU/h7jsmcRm9pZh0HZIRlsvYQ==", "85cfb69f-3887-42d9-b289-3ecd3a044843" });
        }
    }
}
