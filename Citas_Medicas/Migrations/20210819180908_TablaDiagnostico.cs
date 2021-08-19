using Microsoft.EntityFrameworkCore.Migrations;

namespace Citas_Medicas.Migrations
{
    public partial class TablaDiagnostico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diagnosticos",
                columns: table => new
                {
                    Id_Diagnostico = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Paciente = table.Column<int>(nullable: false),
                    PacienteId_Paciente = table.Column<int>(nullable: true),
                    Id_Doctor = table.Column<int>(nullable: false),
                    DoctorId_Doctor = table.Column<int>(nullable: true),
                    Diagnostico_Paciente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosticos", x => x.Id_Diagnostico);
                    table.ForeignKey(
                        name: "FK_Diagnosticos_Doctor_DoctorId_Doctor",
                        column: x => x.DoctorId_Doctor,
                        principalTable: "Doctor",
                        principalColumn: "Id_Doctor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diagnosticos_Paciente_PacienteId_Paciente",
                        column: x => x.PacienteId_Paciente,
                        principalTable: "Paciente",
                        principalColumn: "Id_Paciente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosticos_DoctorId_Doctor",
                table: "Diagnosticos",
                column: "DoctorId_Doctor");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosticos_PacienteId_Paciente",
                table: "Diagnosticos",
                column: "PacienteId_Paciente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnosticos");
        }
    }
}
