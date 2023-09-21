using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cursos.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADM",
                columns: table => new
                {
                    IDADM = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADM", x => x.IDADM);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    IDPROFESSOR = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDADM = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.IDPROFESSOR);
                    table.ForeignKey(
                        name: "FK_Professor_ADM_IDADM",
                        column: x => x.IDADM,
                        principalTable: "ADM",
                        principalColumn: "IDADM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CURSO",
                columns: table => new
                {
                    IDCURSO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VALOR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DATA = table.Column<DateTime>(type: "date", nullable: false),
                    IDADM = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDPROFESSOR = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CURSO", x => x.IDCURSO);
                    table.ForeignKey(
                        name: "FK_CURSO_ADM_IDADM",
                        column: x => x.IDADM,
                        principalTable: "ADM",
                        principalColumn: "IDADM",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CURSO_Professor_IDPROFESSOR",
                        column: x => x.IDPROFESSOR,
                        principalTable: "Professor",
                        principalColumn: "IDPROFESSOR",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADM_EMAIL",
                table: "ADM",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CURSO_IDADM",
                table: "CURSO",
                column: "IDADM");

            migrationBuilder.CreateIndex(
                name: "IX_CURSO_IDPROFESSOR",
                table: "CURSO",
                column: "IDPROFESSOR");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_IDADM",
                table: "Professor",
                column: "IDADM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CURSO");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "ADM");
        }
    }
}
