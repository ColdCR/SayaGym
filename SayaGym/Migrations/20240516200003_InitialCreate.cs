using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SayaGym.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ejercicios",
                columns: table => new
                {
                    IdEjercicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AreaATrabajar = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejercicios", x => x.IdEjercicio);
                });

            migrationBuilder.CreateTable(
                name: "Enfermedades",
                columns: table => new
                {
                    IdEnfermedad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEnfermedad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermedades", x => x.IdEnfermedad);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Teléfono = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Dirección = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estatura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Objetivo = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "EnfermedadesProhibidasEjercicios",
                columns: table => new
                {
                    IdEjercicio = table.Column<int>(type: "int", nullable: false),
                    IdEnfermedad = table.Column<int>(type: "int", nullable: false),
                    EjercicioIdEjercicio = table.Column<int>(type: "int", nullable: false),
                    EnfermedadIdEnfermedad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnfermedadesProhibidasEjercicios", x => new { x.IdEjercicio, x.IdEnfermedad });
                    table.ForeignKey(
                        name: "FK_EnfermedadesProhibidasEjercicios_Ejercicios_EjercicioIdEjercicio",
                        column: x => x.EjercicioIdEjercicio,
                        principalTable: "Ejercicios",
                        principalColumn: "IdEjercicio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnfermedadesProhibidasEjercicios_Enfermedades_EnfermedadIdEnfermedad",
                        column: x => x.EnfermedadIdEnfermedad,
                        principalTable: "Enfermedades",
                        principalColumn: "IdEnfermedad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreasATrabajarUsuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    AreaATrabajar = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasATrabajarUsuario", x => new { x.AreaATrabajar, x.IdUsuario });
                    table.ForeignKey(
                        name: "FK_AreasATrabajarUsuario_Usuario_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnfermedadesUsuario",
                columns: table => new
                {
                    IdEnfermedad = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: false),
                    EnfermedadIdEnfermedad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnfermedadesUsuario", x => new { x.IdEnfermedad, x.IdUsuario });
                    table.ForeignKey(
                        name: "FK_EnfermedadesUsuario_Enfermedades_EnfermedadIdEnfermedad",
                        column: x => x.EnfermedadIdEnfermedad,
                        principalTable: "Enfermedades",
                        principalColumn: "IdEnfermedad");
                    table.ForeignKey(
                        name: "FK_EnfermedadesUsuario_Usuario_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rutina",
                columns: table => new
                {
                    IdRutina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRutina = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutina", x => x.IdRutina);
                    table.ForeignKey(
                        name: "FK_Rutina_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EjerciciosRutina",
                columns: table => new
                {
                    IdRutina = table.Column<int>(type: "int", nullable: false),
                    IdEjercicio = table.Column<int>(type: "int", nullable: false),
                    DiaEjercicio = table.Column<int>(type: "int", nullable: false),
                    RutinaIdRutina = table.Column<int>(type: "int", nullable: false),
                    EjercicioIdEjercicio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EjerciciosRutina", x => new { x.IdEjercicio, x.IdRutina });
                    table.ForeignKey(
                        name: "FK_EjerciciosRutina_Ejercicios_EjercicioIdEjercicio",
                        column: x => x.EjercicioIdEjercicio,
                        principalTable: "Ejercicios",
                        principalColumn: "IdEjercicio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EjerciciosRutina_Rutina_RutinaIdRutina",
                        column: x => x.RutinaIdRutina,
                        principalTable: "Rutina",
                        principalColumn: "IdRutina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "IdUsuario", "Contraseña", "Correo", "Dirección", "Edad", "Estado", "Estatura", "Nombre", "Objetivo", "Peso", "Rol", "Sexo", "Teléfono" },
                values: new object[] { 1, "admin", "admin@gmail.com", "", 20, "A", 170m, "Admin", 0, 80m, 0, "M", "00000000" });

            migrationBuilder.CreateIndex(
                name: "IX_AreasATrabajarUsuario_UsuarioIdUsuario",
                table: "AreasATrabajarUsuario",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_EjerciciosRutina_EjercicioIdEjercicio",
                table: "EjerciciosRutina",
                column: "EjercicioIdEjercicio");

            migrationBuilder.CreateIndex(
                name: "IX_EjerciciosRutina_RutinaIdRutina",
                table: "EjerciciosRutina",
                column: "RutinaIdRutina");

            migrationBuilder.CreateIndex(
                name: "IX_EnfermedadesProhibidasEjercicios_EjercicioIdEjercicio",
                table: "EnfermedadesProhibidasEjercicios",
                column: "EjercicioIdEjercicio");

            migrationBuilder.CreateIndex(
                name: "IX_EnfermedadesProhibidasEjercicios_EnfermedadIdEnfermedad",
                table: "EnfermedadesProhibidasEjercicios",
                column: "EnfermedadIdEnfermedad");

            migrationBuilder.CreateIndex(
                name: "IX_EnfermedadesUsuario_EnfermedadIdEnfermedad",
                table: "EnfermedadesUsuario",
                column: "EnfermedadIdEnfermedad");

            migrationBuilder.CreateIndex(
                name: "IX_EnfermedadesUsuario_UsuarioIdUsuario",
                table: "EnfermedadesUsuario",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Rutina_IdUsuario",
                table: "Rutina",
                column: "IdUsuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreasATrabajarUsuario");

            migrationBuilder.DropTable(
                name: "EjerciciosRutina");

            migrationBuilder.DropTable(
                name: "EnfermedadesProhibidasEjercicios");

            migrationBuilder.DropTable(
                name: "EnfermedadesUsuario");

            migrationBuilder.DropTable(
                name: "Rutina");

            migrationBuilder.DropTable(
                name: "Ejercicios");

            migrationBuilder.DropTable(
                name: "Enfermedades");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
