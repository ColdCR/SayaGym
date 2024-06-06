using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SayaGym.Migrations
{
    /// <inheritdoc />
    public partial class FixCosillas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Cedula", "FechaDeNacimiento" },
                values: new object[] { "111111111", new DateTime(2024, 6, 6, 15, 37, 59, 284, DateTimeKind.Local).AddTicks(9798) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Cedula", "FechaDeNacimiento" },
                values: new object[] { "11111111", new DateTime(2024, 5, 30, 11, 20, 52, 460, DateTimeKind.Local).AddTicks(7245) });
        }
    }
}
