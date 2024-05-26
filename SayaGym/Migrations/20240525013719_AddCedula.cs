using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SayaGym.Migrations
{
    /// <inheritdoc />
    public partial class AddCedula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "Usuario",
                type: "nvarchar(9)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "Cedula", "FechaDeNacimiento" },
                values: new object[] { "11111111", new DateTime(2024, 5, 24, 19, 37, 18, 134, DateTimeKind.Local).AddTicks(6202) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "Usuario");



            migrationBuilder.AddPrimaryKey(
                name: "PK_AreasATrabajarUsuario",
                table: "AreasATrabajarUsuario",
                columns: new[] { "AreaATrabajar", "IdUsuario" });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "FechaDeNacimiento",
                value: new DateTime(2024, 5, 23, 18, 28, 36, 985, DateTimeKind.Local).AddTicks(4496));


        }
    }
}
