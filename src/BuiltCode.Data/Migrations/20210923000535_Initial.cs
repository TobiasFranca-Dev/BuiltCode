using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuiltCode.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "medicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    crm = table.Column<string>(type: "varchar(50)", nullable: false),
                    uf_crm = table.Column<string>(type: "varchar(2)", nullable: false),
                    especialidade = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "parceiros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    api_key = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parceiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", nullable: false),
                    nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    senha = table.Column<string>(type: "varchar(255)", nullable: false),
                    perfil = table.Column<short>(type: "int2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pacientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "varchar(255)", nullable: true),
                    cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    telefone = table.Column<string>(type: "varchar(20)", nullable: true),
                    medico_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pacientes_medicos_medico_id",
                        column: x => x.medico_id,
                        principalTable: "medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "Id", "email", "nome", "perfil", "senha" },
                values: new object[] { new Guid("8d364048-64cd-4bb1-ac8b-341e2d03d170"), "contato@builtcode.com.br", "admin", (short)0, "E10ADC3949BA59ABBE56E057F20F883E" });

            migrationBuilder.CreateIndex(
                name: "IX_medicos_crm",
                table: "medicos",
                column: "crm");

            migrationBuilder.CreateIndex(
                name: "IX_medicos_uf_crm",
                table: "medicos",
                column: "uf_crm");

            migrationBuilder.CreateIndex(
                name: "IX_pacientes_cpf",
                table: "pacientes",
                column: "cpf");

            migrationBuilder.CreateIndex(
                name: "IX_pacientes_medico_id",
                table: "pacientes",
                column: "medico_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_email",
                table: "usuarios",
                column: "email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pacientes");

            migrationBuilder.DropTable(
                name: "parceiros");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "medicos");
        }
    }
}
