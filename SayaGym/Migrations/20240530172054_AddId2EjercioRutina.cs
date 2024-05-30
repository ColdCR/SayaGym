using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SayaGym.Migrations
{
    /// <inheritdoc />
    public partial class AddId2EjercioRutina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EjerciciosRutina",
                table: "EjerciciosRutina");

            migrationBuilder.AddColumn<int>(
                name: "IdEjercicioRutina",
                table: "EjerciciosRutina",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EjerciciosRutina",
                table: "EjerciciosRutina",
                column: "IdEjercicioRutina");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "FechaDeNacimiento",
                value: new DateTime(2024, 5, 30, 11, 20, 52, 460, DateTimeKind.Local).AddTicks(7245));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EjerciciosRutina",
                table: "EjerciciosRutina");

            migrationBuilder.DropColumn(
                name: "IdEjercicioRutina",
                table: "EjerciciosRutina");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EjerciciosRutina",
                table: "EjerciciosRutina",
                columns: new[] { "IdEjercicio", "IdRutina", "DiaEjercicio" });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "FechaDeNacimiento",
                value: new DateTime(2024, 5, 29, 19, 7, 9, 378, DateTimeKind.Local).AddTicks(9840));
        }
    }
}
