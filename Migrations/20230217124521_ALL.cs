using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Migrations
{
    public partial class ALL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "localisations",
                columns: table => new
                {
                    id_localisation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    street = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_localisations", x => x.id_localisation);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    id_payment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    payment_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.id_payment);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    id_car = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Types = table.Column<int>(type: "int", nullable: true),
                    Localisations = table.Column<int>(type: "int", nullable: true),
                    make = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    vin = table.Column<string>(type: "char(17)", nullable: false),
                    power = table.Column<int>(type: "int", nullable: false),
                    price_per_day = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.id_car);
                    table.ForeignKey(
                        name: "FK_cars_localisations_Localisations",
                        column: x => x.Localisations,
                        principalTable: "localisations",
                        principalColumn: "id_localisation");
                    table.ForeignKey(
                        name: "FK_cars_types_Types",
                        column: x => x.Types,
                        principalTable: "types",
                        principalColumn: "id_type");
                });

            migrationBuilder.CreateTable(
                name: "rentals",
                columns: table => new
                {
                    id_rental = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Cars = table.Column<int>(type: "int", nullable: false),
                    Payments = table.Column<int>(type: "int", nullable: false),
                    date_from = table.Column<DateTime>(type: "date", nullable: false),
                    date_to = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rentals", x => x.id_rental);
                    table.ForeignKey(
                        name: "FK_rentals_AspNetUsers_Customer",
                        column: x => x.Customer,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rentals_cars_Cars",
                        column: x => x.Cars,
                        principalTable: "cars",
                        principalColumn: "id_car",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rentals_payments_Payments",
                        column: x => x.Payments,
                        principalTable: "payments",
                        principalColumn: "id_payment",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "76d58b54-d7a3-4171-8a9f-cb318d4dee66", "Admin", "ADMIN" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "5a011fbb-ec1a-40d1-9fb3-bac4f4f6260c", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "first_name", "last_name" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb8", 0, "c1fc4525-0e44-45f5-a245-2cb69d606aca", "user@user.user", false, false, null, "USER@USER.USER", "USER@USER.USER", "AQAAAAEAACcQAAAAEJDUrRiithSJ7uczrUvFAv2jvQrPhdvEHo4rA8wLI6XCf5UKbNCuVG79NyrNsxeu6g==", "987654321", false, "f812beef-6db5-4d31-a835-17fb8dbb2c2a", false, "user@user.user", "User", "User" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "47ff2718-210d-419a-86c2-00740d104944", "admin@admin.admin", false, false, null, "ADMIN@ADMIN.ADMIN", "ADMIN@ADMIN.ADMIN", "AQAAAAEAACcQAAAAEAP9+Wt+DSSz9arCCEjAPRGGBytjWr9AoFnFZpPVbaS2nnUXbSLgA4wIbS+1xahVIg==", "123456789", false, "803b7e37-f340-4b31-adf0-6b83c938f426", false, "admin@admin.admin", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "localisations",
                columns: new[] { "id_localisation", "city", "number", "street" },
                values: new object[,]
                {
                    { 1, "Kraków", 1, "Filipa" },
                    { 2, "Warszawa", 23, "Długa" }
                });

            migrationBuilder.InsertData(
                table: "types",
                columns: new[] { "id_type", "type" },
                values: new object[,]
                {
                    { 1, "Sedan" },
                    { 2, "Sports" },
                    { 3, "Suv" },
                    { 4, "Cupe" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "8e445865-a24d-4543-a6c6-9443d048cdb8" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" }
                });

            migrationBuilder.InsertData(
                table: "cars",
                columns: new[] { "id_car", "Localisations", "Types", "make", "model", "power", "price_per_day", "vin" },
                values: new object[,]
                {
                    { 1, 1, 1, "Mercedes", "S500", 300, 500m, "4T1BF12B3VU142754" },
                    { 2, 1, 2, "Tesla", "Roadster", 700, 700m, "JH4KA8270RC000976" },
                    { 3, 1, 1, "Mercedes", "190", 120, 200m, "1FTRW14W84KC76110" },
                    { 4, 2, 3, "BMW", "X3", 200, 300m, "1FTJW36F2TEA03179" },
                    { 5, 2, 4, "Ford", "Mustang", 400, 450m, "JH4DC4450RS002529" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_cars_Localisations",
                table: "cars",
                column: "Localisations");

            migrationBuilder.CreateIndex(
                name: "IX_cars_Types",
                table: "cars",
                column: "Types");

            migrationBuilder.CreateIndex(
                name: "IX_rentals_Cars",
                table: "rentals",
                column: "Cars");

            migrationBuilder.CreateIndex(
                name: "IX_rentals_Customer",
                table: "rentals",
                column: "Customer");

            migrationBuilder.CreateIndex(
                name: "IX_rentals_Payments",
                table: "rentals",
                column: "Payments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "rentals");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "localisations");

            migrationBuilder.DeleteData(
                table: "types",
                keyColumn: "id_type",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "types",
                keyColumn: "id_type",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "types",
                keyColumn: "id_type",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "types",
                keyColumn: "id_type",
                keyValue: 4);
        }
    }
}
