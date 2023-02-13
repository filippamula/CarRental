using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Migrations
{
    /// <inheritdoc />
    public partial class Payments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    idpayment = table.Column<int>(name: "id_payment", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    paymentdate = table.Column<DateTime>(name: "payment_date", type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.idpayment);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payments");
        }
    }
}
