using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SayaGym.Migrations
{
    /// <inheritdoc />
    public partial class tablasWil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "FechaDeNacimiento",
                value: new DateTime(2024, 6, 11, 0, 31, 13, 63, DateTimeKind.Local).AddTicks(8687));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "FechaDeNacimiento",
                value: new DateTime(2024, 6, 6, 15, 37, 59, 284, DateTimeKind.Local).AddTicks(9798));
        }
    }
}
