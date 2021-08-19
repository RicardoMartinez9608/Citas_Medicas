using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Citas_Medicas.Migrations
{
    public partial class Fecha_Cita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_Cita",
                table: "Citas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha_Cita",
                table: "Citas");
        }
    }
}
