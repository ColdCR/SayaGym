using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SayaGym.Migrations
{
    /// <inheritdoc />
    public partial class AddOtherKey2EjercicioRutina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EjerciciosRutina",
                table: "EjerciciosRutina");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Ejercicios",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Ejercicios",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EjerciciosRutina",
                table: "EjerciciosRutina");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Ejercicios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Ejercicios",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EjerciciosRutina",
                table: "EjerciciosRutina",
                columns: new[] { "IdEjercicio", "IdRutina" });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "FechaDeNacimiento",
                value: new DateTime(2024, 5, 29, 17, 25, 38, 492, DateTimeKind.Local).AddTicks(2281));
        }
    }
}
