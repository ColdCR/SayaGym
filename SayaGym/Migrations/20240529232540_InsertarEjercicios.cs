using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SayaGym.Migrations
{
    /// <inheritdoc />
    public partial class InsertarEjercicios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Ejercicios",
                columns: new[] { "IdEjercicio", "AreaATrabajar", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Brazos", "Levantar mancuernas hacia los lados del cuerpo hasta la altura de los hombros, manteniendo los brazos ligeramente flexionados.", "Elevación Lateral con Mancuernas" },
                    { 2, "Brazos", "Levantar mancuernas hacia los lados del cuerpo, pero con los brazos ligeramente flexionados hacia adelante, trabajando la parte posterior de los hombros.", "Vuelo Posterior del Deltoides con Mancuernas" },
                    { 3, "Brazos", "Levantar una mancuerna desde el muslo hasta la altura de los hombros, manteniendo los brazos extendidos hacia adelante.", "Elevación Frontal con Mancuerna" },
                    { 4, "Brazos", "Realizar estiramientos hacia adelante con una cuerda de cable, manteniendo los brazos extendidos y controlando el movimiento.", "Estiramientos de Rostro con Cuerda de Cable" },
                    { 5, "Brazos", "Sentarse y levantar mancuernas desde los hombros hacia arriba, extendiendo los brazos.", "Press de Hombros Sentado con Mancuernas" },
                    { 6, "Brazos", "Levantar una barra con peso desde los muslos hasta los hombros, flexionando los codos.", "Curl de Barra" },
                    { 7, "Brazos", "Levantar una mancuerna desde el muslo hasta el hombro, flexionando el codo", "Curl con Mancuerna" },
                    { 8, "Brazos", "Levantar mancuernas con las palmas enfrentadas desde los muslos hasta los hombros, flexionando los codos", "Curl de Martillo con Mancuernas" },
                    { 9, "Brazos", "Realizar curls con una pesa kettlebell apoyando los brazos en un banco inclinado", "Curl de Predicador con Kettlebell" },
                    { 10, "Brazos", "Levantar una polea con peso desde abajo hacia el hombro, con la palma hacia abajo.", "Curl Inverso con Cable a un Brazo" },
                    { 11, "Brazos", "Levantar una polea con peso desde abajo hacia el hombro, con las palmas enfrentadas", "Curl de Martillo con Cable a un Brazo" },
                    { 12, "Brazos", "Realizar curls con una banda elástica, flexionando los codos y resistiendo la tensión de la banda.", "Curl con Banda" },
                    { 13, "Brazos", "Sentarse en un banco inclinado y levantar una mancuerna desde el muslo hasta el hombro, flexionando el codo.", "Curl de Concentración con Mancuerna" },
                    { 14, "Brazos", "Realizar fondos con los codos cerca del cuerpo, flexionando los brazos.", "Fondos con codos estrechos" },
                    { 15, "Brazos", "Sentarse en un banco y levantar una mancuerna desde detrás de la cabeza hasta estirar el brazo.", "Extensión de Tríceps con Mancuerna Sentado y con los Brazos Elevados" },
                    { 16, "Brazos", "Realizar extensiones de tríceps con una barra V en una máquina de poleas, desde arriba hacia abajo.", "Empujes hacia Abajo con Barra V en Máquina de Poleas" },
                    { 17, "Brazos", "Acostarse en un banco y realizar fondos con los brazos extendidos detrás de la cabeza.", "Fondos en Banco" },
                    { 18, "Brazos", "Acostarse en un banco y levantar una barra desde detrás de la cabeza hasta estirar el brazo.", "Extensiones de Tríceps Acostado con Barra" },
                    { 19, "Brazos", "Realizar extensiones de tríceps con un cable cruzado, desde arriba hacia abajo.", "Empuje Hacia Abajo con Cable Cruzado" },
                    { 20, "Brazos", "Realizar extensiones de tríceps con una cuerda de cable, desde arriba hacia abajo.", "Empuje hacia abajo con cuerda de cable" },
                    { 21, "Piernas", "Posición inicial: Ajuste la barra a la altura adecuada, pase debajo de la barra y sosténgala en la parte posterior de los hombros.", "Sentadilla con Barra" },
                    { 22, "Piernas", "Realizar una zancada hacia atrás con una pierna apoyada en un banco, flexionando ambas rodillas. Levantar el cuerpo de vuelta a la posición inicial.", "Sentadilla Búlgara con Mancuernas" },
                    { 23, "Piernas", "Dar un paso hacia adelante flexionando ambas rodillas hasta que formen ángulos de 90 grados. Volver a la posición inicial.", "Zancadas hacia adelante" },
                    { 24, "Piernas", "Realizar una zancada hacia atrás con una pierna, manteniendo la otra extendida y flexionando ambas rodillas. Volver a la posición inicial.", "Zancada de Reverencia con Barra" },
                    { 25, "Piernas", "Realizar una sentadilla con una barra olímpica, manteniendo la espalda recta y bajando hasta que los muslos estén paralelos al suelo. Volver a la posición inicial.", "Sentadilla con Barra Olímpica en Pivote" },
                    { 26, "Piernas", "Saltar con ambos pies sobre un cajón y aterrizar suavemente. Subir y bajar del cajón de forma controlada", "Salto al Cajón" },
                    { 27, "Piernas", "Sostener una pelota medicinal sobre la cabeza y realizar una sentadilla manteniendo la espalda recta. Volver a la posición inicial.", "Sentadilla con Pelota Medicinal en la Cabeza" },
                    { 28, "Piernas", "Ajustar la máquina a la altura adecuada, sostener la barra en la parte posterior de los hombros y realizar una sentadilla controlada.", "Sentadilla en Máquina Smith" },
                    { 29, "Piernas", "Realizar zancadas hacia atrás alternando las piernas, manteniendo la espalda recta y flexionando ambas rodillas. Volver a la posición inicial.", "Zancada de reverencia alternada con peso corporal" },
                    { 30, "Piernas", "De pie en una máquina específica, levanta los talones tanto como puedas mientras exhalas, luego baja lentamente.", "Elevaciones de Pantorrilla en Máquina de Pie" },
                    { 31, "Piernas", "Sentado en una máquina, levanta los talones tanto como puedas mientras exhalas, luego baja lentamente.", "Elevaciones de Pantorrilla Sentado en Máquina" },
                    { 32, "Piernas", "Camina sobre las puntas de los pies, manteniendo los talones elevados del suelo. Puedes hacerlo en el lugar o desplazándote.", "Caminata de Puntas de Pie" },
                    { 33, "Piernas", "De pie, levanta los talones tanto como puedas, manteniendo el equilibrio, y luego baja lentamente.", "Elevaciones de Pantorrilla" },
                    { 34, "Piernas", "Utilizando una barra sobre los hombros, levanta los talones tanto como puedas, manteniendo el equilibrio, y luego baja lentamente.", "Elevaciones de Pantorrilla con Barra" },
                    { 35, "Piernas", "Con un cable, levanta los talones tanto como puedas, manteniendo el equilibrio, y luego baja lentamente.", "Elevación de Pantorrilla con Cable" },
                    { 36, "Pecho", "Acostarse en un banco plano, tomar la barra con un agarre ligeramente más ancho que los hombros, bajar la barra controladamente hasta el pecho y empujar hacia arriba para extender los brazos", "Press de Banca con Barra" },
                    { 37, "Pecho", "Apoyar las manos en una caja o banco, extender los brazos para levantar el cuerpo y luego flexionar los codos para bajar el cuerpo hasta que los brazos formen un ángulo de 90 grados", "Fondos en Caja" },
                    { 38, "Pecho", "Acostarse en un banco inclinado, sostener mancuernas con las palmas hacia adentro, abrir los brazos hasta que estén paralelos al suelo y volver a la posición inicial", "Aperturas de Pecho con Mancuernas en Banco Inclinado" },
                    { 39, "Pecho", "Acostarse en un banco inclinado, tomar la barra con un agarre ligeramente más ancho que los hombros, bajar la barra controladamente hasta el pecho y empujar hacia arriba para extender los brazos", "Press de Banca Inclinado con Barra" },
                    { 40, "Pecho", "Acostarse boca abajo en un banco, extender los brazos hacia adelante con las manos en el suelo y realizar un estiramiento de pecho", "Variación Cuatro de Estiramiento de Pecho" },
                    { 41, "Pecho", "Colocarse en posición de flexión con las manos y pies apoyados en el suelo, bajar el cuerpo flexionando los codos hasta que el pecho casi toque el suelo, y luego empujar para volver a la posición inicial", "Lagartija" },
                    { 42, "Pecho", "Realizar flexiones con el cuerpo inclinado a 45 grados, manteniendo la espalda recta y flexionando los codos para bajar el pecho hacia el suelo", "Flexión Inclinada" },
                    { 43, "Pecho", "Realizar flexiones con el cuerpo inclinado hacia abajo a 90 grados, manteniendo la espalda recta y flexionando los codos para bajar el pecho hacia el suelo", "Flexión inclinado hacia abajo" },
                    { 44, "Pecho", "De pie frente a una polea alta, tomar el agarre con ambas manos y abrir los brazos hacia los lados, manteniendo los codos ligeramente flexionados", "Apertura de Pecho con Polea" },
                    { 45, "Pecho", "De pie entre dos poleas a la altura del pecho, empujar las manos hacia adelante extendiendo los brazos", "Press de Pecho con Cable" },
                    { 46, "Abdomen", "Acostado boca arriba, con las piernas extendidas, eleva las piernas hasta formar un ángulo recto con el cuerpo y luego baja lentamente", "Elevaciones de Pierna Acostado" },
                    { 47, "Abdomen", "En una máquina específica, acostado boca arriba, eleva el tronco flexionando el abdomen y luego baja lentamente.", "Despliegues con Máquina" },
                    { 48, "Abdomen", "\"Acostado boca abajo, con los brazos extendidos, eleva el tronco y las piernas, formando una \"\"V\"\" con el cuerpo.\"", "Variante Cuatro del Estiramiento Abdominal" },
                    { 49, "Abdomen", "En posición de plancha, apoyado en los antebrazos y pies, mantén la posición contraído el abdomen", "Plancha de Antebrazo" },
                    { 50, "Abdomen", "Colgado de una barra, eleva las rodillas hacia el pecho, manteniendo el abdomen contraído", "Elevaciones de Rodilla Colgando" },
                    { 51, "Abdomen", "Sentado con las piernas extendidas y una barra en el pecho, eleva el tronco flexionando el abdomen y luego baja lentamente.", "Despliegues con Barra" },
                    { 52, "Abdomen", "De pie frente a una polea baja, toma el agarre con ambas manos y realiza un crunch, flexionando el abdomen", "Crunch de Pie con Cable" },
                    { 53, "Abdomen", "Sentado con las rodillas flexionadas y una barra en el pecho, realiza un crunch flexionando el abdomen.", "Crunch de Rodillas con Barra en Polea" },
                    { 54, "Abdomen", "Acostado boca arriba con una mancuerna en el pecho, realiza un crunch flexionando el abdomen.", "Abdominales con Mancuerna" },
                    { 55, "Abdomen", "En posición de plancha, pasa una mancuerna de un lado a otro por debajo del pecho, manteniendo el abdomen contraído.", "Plancha con Pase de Mancuerna" },
                    { 56, "Abdomen", "En posición de plancha, alterna flexionar las rodillas hacia el pecho, manteniendo el abdomen contraído.", "Escalador de Montañas" },
                    { 57, "Abdomen", "Suspendido en un TRX, eleva las rodillas hacia el pecho, manteniendo el abdomen contraído.", "Rodillas al Pecho con TRX" },
                    { 58, "Abdomen", "Acostado de lado con una mancuerna en el pecho, realiza un giro llevando la mancuerna hacia el suelo, manteniendo las piernas juntas.", "Giro Ruso con Mancuerna" },
                    { 59, "Cardio", "Realizar jacks verticales con una banda de resistencia sobre los tobillos, separando y juntando las piernas mientras mueves los brazos en dirección opuesta", "Bandas de Cardio para Martillo y Flexiones de Brazos Jacks" },
                    { 60, "Cardio", "Simular el movimiento de remo en un ergómetro, utilizando solo los brazos para impulsar el deslizador hacia atrás y luego volver a la posición inicial.", "Cardio Remo Ergo con Brazos Solamente" },
                    { 61, "Cardio", "Saltar y tocar los dedos de los pies con las manos, manteniendo las piernas extendidas.", "Toque de Dedo del Pie" },
                    { 62, "Cardio", "Dar pasos grandes hacia adelante alternando las piernas, manteniendo el torso erguido.", "Tijera Cardio hacia Delante" },
                    { 63, "Cardio", "Realizar movimientos de boxeo con los pies, dando pequeños saltos y pasos laterales rápidos.", "Cardio Box Pies Rápidos" },
                    { 64, "Cardio", "Saltar cruzando las piernas hacia adelante y hacia atrás, manteniendo el torso erguido.", "Cardio Cruces de Saltos" },
                    { 65, "Cardio", "Correr en una figura de ocho, cambiando de dirección rápidamente.", "Cardio Sprint en Figura de Ocho" },
                    { 66, "Cardio", "Saltar hacia adelante lo más lejos posible, aterrizando con las rodillas flexionadas.", "Salto Largo Cardio" },
                    { 67, "Cardio", "Correr a máxima velocidad durante un período corto de tiempo, seguido de un período de recuperación.", "Esprint de Carrera Cardiovascular" },
                    { 68, "Cardio", "Realizar movimientos de pedaleo en el aire, alternando las piernas rápidamente.", "Bicicleta de Asalto Cardiovascular" },
                    { 69, "Cardio", "Dar pasos grandes hacia adelante alternando las piernas, manteniendo el torso erguido.", "Tijera Cardio hacia Delante" },
                    { 70, "Cardio", "Saltar cruzando las piernas hacia adelante y hacia atrás, manteniendo el torso erguido.", "Cardio Cruces de Saltos" },
                    { 71, "Cardio", "Realizar jacks verticales, saltando y separando las piernas hacia los lados mientras mueves los brazos en dirección opuesta.", "Saltos de Jacks Cardio" },
                    { 72, "Cardio", "Realizar caminatas diarias unos tres kilómetros como mínimo. ", "Caminar 3 kilometros" },
                    { 73, "Espalda", "Agárrate a una barra horizontal con las manos más separadas que el ancho de los hombros. Levanta el cuerpo hasta que la barbilla supere la barra. Baja lentamente hasta la posición inicial.", "Dominadas" },
                    { 74, "Espalda", "De pie, con los pies separados a la anchura de los hombros, sostenga una barra sobre la parte delantera de los muslos. Flexione las rodillas y la cadera hacia adelante, manteniendo la espalda recta. Tire de la barra hacia el pecho, manteniendo los codos cerca del cuerpo. Extienda los brazos para volver a la posición inicial.", "Remo con barra" },
                    { 75, "Espalda", "Siéntese en la máquina de jalón al pecho y agarre la barra con las manos a la anchura de los hombros. Tire de la barra hacia el pecho, manteniendo la espalda recta y los codos cerca del cuerpo. Extienda los brazos para volver a la posición inicial.", "Jalón al pecho" },
                    { 76, "Espalda", "Incline el torso hacia adelante desde la cintura, manteniendo la espalda recta. Sostenga una mancuerna en cada mano con las palmas hacia adentro. Tire de las mancuernas hacia la cadera, manteniendo los codos cerca del cuerpo. Baje las mancuernas lentamente a la posición inicial.", "Remo con mancuernas" },
                    { 77, "Espalda", "Siéntese en una máquina de poleas con un accesorio de agarre frontal. Agarre las manijas con las palmas una frente a la otra. Tire de las manijas hacia la cara, manteniendo los codos cerca del cuerpo. Extienda los brazos para volver a la posición inicial.", "Face pulls" }
                });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "FechaDeNacimiento",
                value: new DateTime(2024, 5, 29, 17, 25, 38, 492, DateTimeKind.Local).AddTicks(2281));

            migrationBuilder.InsertData(
                table: "EnfermedadesProhibidasEjercicios",
                columns: new[] { "IdEjercicio", "IdEnfermedad", "EjercicioIdEjercicio", "EnfermedadIdEnfermedad" },
                values: new object[,]
                {
                    { 4, 7, 4, 7 },
                    { 8, 7, 8, 7 },
                    { 10, 7, 10, 7 },
                    { 12, 7, 12, 7 },
                    { 17, 3, 17, 3 },
                    { 17, 7, 17, 7 },
                    { 18, 7, 18, 7 },
                    { 21, 1, 21, 1 },
                    { 21, 3, 21, 3 },
                    { 21, 4, 21, 4 },
                    { 22, 1, 22, 1 },
                    { 22, 2, 22, 2 },
                    { 22, 4, 22, 4 },
                    { 23, 4, 23, 4 },
                    { 24, 4, 24, 4 },
                    { 25, 4, 25, 4 },
                    { 26, 4, 26, 4 },
                    { 26, 5, 26, 5 },
                    { 27, 4, 27, 4 },
                    { 28, 4, 28, 4 },
                    { 29, 4, 29, 4 },
                    { 39, 5, 39, 5 },
                    { 41, 1, 41, 1 },
                    { 41, 2, 41, 2 },
                    { 41, 3, 41, 3 },
                    { 41, 6, 41, 6 },
                    { 46, 6, 46, 6 },
                    { 49, 1, 49, 1 },
                    { 49, 2, 49, 2 },
                    { 49, 5, 49, 5 },
                    { 50, 1, 50, 1 },
                    { 50, 2, 50, 2 },
                    { 50, 3, 50, 3 },
                    { 50, 6, 50, 6 },
                    { 54, 3, 54, 3 },
                    { 54, 8, 54, 8 },
                    { 55, 1, 55, 1 },
                    { 55, 2, 55, 2 },
                    { 55, 5, 55, 5 },
                    { 56, 1, 56, 1 },
                    { 56, 2, 56, 2 },
                    { 56, 5, 56, 5 },
                    { 57, 3, 57, 3 },
                    { 58, 3, 58, 3 },
                    { 59, 1, 59, 1 },
                    { 60, 1, 60, 1 },
                    { 63, 1, 63, 1 },
                    { 63, 5, 63, 5 },
                    { 64, 4, 64, 4 },
                    { 65, 4, 65, 4 },
                    { 66, 4, 66, 4 },
                    { 67, 4, 67, 4 },
                    { 67, 5, 67, 5 },
                    { 70, 4, 70, 4 },
                    { 71, 4, 71, 4 },
                    { 73, 3, 73, 3 },
                    { 73, 8, 73, 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 10, 7 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 12, 7 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 17, 3 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 17, 7 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 18, 7 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 21, 1 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 21, 3 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 21, 4 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 22, 1 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 22, 2 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 22, 4 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 23, 4 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 24, 4 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 25, 4 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 26, 4 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 26, 5 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 27, 4 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 28, 4 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 29, 4 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 39, 5 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 41, 1 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 41, 2 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 41, 3 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 41, 6 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 46, 6 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 49, 1 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 49, 2 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 49, 5 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 50, 1 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 50, 2 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 50, 3 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 50, 6 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 54, 3 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 54, 8 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 55, 1 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 55, 2 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 55, 5 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 56, 1 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 56, 2 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 56, 5 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 57, 3 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 58, 3 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 59, 1 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 60, 1 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 63, 1 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 63, 5 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 64, 4 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 65, 4 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 66, 4 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 67, 4 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 67, 5 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 70, 4 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 71, 4 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 73, 3 });

            migrationBuilder.DeleteData(
                table: "EnfermedadesProhibidasEjercicios",
                keyColumns: new[] { "IdEjercicio", "IdEnfermedad" },
                keyValues: new object[] { 73, 8 });

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Ejercicios",
                keyColumn: "IdEjercicio",
                keyValue: 73);

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "FechaDeNacimiento",
                value: new DateTime(2024, 5, 27, 16, 7, 44, 498, DateTimeKind.Local).AddTicks(3641));
        }
    }
}
