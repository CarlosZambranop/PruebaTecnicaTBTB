using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PruebaTecnicaTbTb.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "medico",
                columns: table => new
                {
                    MedicoID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Especialidad = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medico", x => x.MedicoID);
                });

            migrationBuilder.CreateTable(
                name: "paciente",
                columns: table => new
                {
                    PacienteID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    MedicoID = table.Column<int>(type: "integer", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paciente", x => x.PacienteID);
                    table.ForeignKey(
                        name: "FK_paciente_medico_MedicoID",
                        column: x => x.MedicoID,
                        principalTable: "medico",
                        principalColumn: "MedicoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "citaMedica",
                columns: table => new
                {
                    CitaID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacienteID = table.Column<int>(type: "integer", nullable: false),
                    MedicoID = table.Column<int>(type: "integer", nullable: false),
                    FechaCita = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MotivoConsulta = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citaMedica", x => x.CitaID);
                    table.ForeignKey(
                        name: "FK_citaMedica_medico_MedicoID",
                        column: x => x.MedicoID,
                        principalTable: "medico",
                        principalColumn: "MedicoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_citaMedica_paciente_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "paciente",
                        principalColumn: "PacienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_citaMedica_MedicoID",
                table: "citaMedica",
                column: "MedicoID");

            migrationBuilder.CreateIndex(
                name: "IX_citaMedica_PacienteID",
                table: "citaMedica",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_paciente_MedicoID",
                table: "paciente",
                column: "MedicoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "citaMedica");

            migrationBuilder.DropTable(
                name: "paciente");

            migrationBuilder.DropTable(
                name: "medico");
        }
    }
}
