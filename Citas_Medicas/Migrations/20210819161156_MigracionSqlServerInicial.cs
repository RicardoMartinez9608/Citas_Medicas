using Microsoft.EntityFrameworkCore.Migrations;

namespace Citas_Medicas.Migrations
{
    public partial class MigracionSqlServerInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id_Especialidades = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Especialidad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id_Especialidades);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id_Paciente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Domicilio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id_Paciente);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id_Doctor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Id_Especialidades = table.Column<int>(nullable: false),
                    EspecialidadesId_Especialidades = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id_Doctor);
                    table.ForeignKey(
                        name: "FK_Doctor_Especialidades_EspecialidadesId_Especialidades",
                        column: x => x.EspecialidadesId_Especialidades,
                        principalTable: "Especialidades",
                        principalColumn: "Id_Especialidades",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    Id_Cita = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Doctor = table.Column<int>(nullable: false),
                    DoctorId_Doctor = table.Column<int>(nullable: true),
                    Id_Paciente = table.Column<int>(nullable: false),
                    PacienteId_Paciente = table.Column<int>(nullable: true),
                    Id_Especialidades = table.Column<int>(nullable: false),
                    EspecialidadesId_Especialidades = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Id_Cita);
                    table.ForeignKey(
                        name: "FK_Citas_Doctor_DoctorId_Doctor",
                        column: x => x.DoctorId_Doctor,
                        principalTable: "Doctor",
                        principalColumn: "Id_Doctor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citas_Especialidades_EspecialidadesId_Especialidades",
                        column: x => x.EspecialidadesId_Especialidades,
                        principalTable: "Especialidades",
                        principalColumn: "Id_Especialidades",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citas_Paciente_PacienteId_Paciente",
                        column: x => x.PacienteId_Paciente,
                        principalTable: "Paciente",
                        principalColumn: "Id_Paciente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_DoctorId_Doctor",
                table: "Citas",
                column: "DoctorId_Doctor");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_EspecialidadesId_Especialidades",
                table: "Citas",
                column: "EspecialidadesId_Especialidades");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_PacienteId_Paciente",
                table: "Citas",
                column: "PacienteId_Paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_EspecialidadesId_Especialidades",
                table: "Doctor",
                column: "EspecialidadesId_Especialidades");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Especialidades");
        }
    }
}
