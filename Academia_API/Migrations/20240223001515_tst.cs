using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academia_API.Migrations
{
    public partial class tst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    id_aluno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    data_nascimento = table.Column<DateTime>(type: "date", nullable: true),
                    genero = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    endereco = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    telefone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Aluno__8D231D091D250E59", x => x.id_aluno);
                });

            migrationBuilder.CreateTable(
                name: "Instrutor",
                columns: table => new
                {
                    id_instrutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    especialidade = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    telefone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Instruto__D670DEA1DD0029F3", x => x.id_instrutor);
                });

            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    id_matricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_inicio = table.Column<DateTime>(type: "date", nullable: true),
                    id_aluno = table.Column<int>(type: "int", nullable: true),
                    plano_treinamento = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    status_matricula = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Matricul__1D7CF00B6D847D8B", x => x.id_matricula);
                    table.ForeignKey(
                        name: "FK__Matricula__id_al__403A8C7D",
                        column: x => x.id_aluno,
                        principalTable: "Aluno",
                        principalColumn: "id_aluno");
                });

            migrationBuilder.CreateTable(
                name: "Aula",
                columns: table => new
                {
                    id_aula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_aula = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    horario = table.Column<TimeSpan>(type: "time", nullable: true),
                    id_instrutor = table.Column<int>(type: "int", nullable: true),
                    capacidade_maxima = table.Column<int>(type: "int", nullable: true),
                    descricao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Aula__B19134FE580EC32D", x => x.id_aula);
                    table.ForeignKey(
                        name: "FK__Aula__id_instrut__38996AB5",
                        column: x => x.id_instrutor,
                        principalTable: "Instrutor",
                        principalColumn: "id_instrutor");
                });

            migrationBuilder.CreateTable(
                name: "Presenca",
                columns: table => new
                {
                    id_presenca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_aula = table.Column<DateTime>(type: "date", nullable: true),
                    horario = table.Column<TimeSpan>(type: "time", nullable: true),
                    id_aluno = table.Column<int>(type: "int", nullable: true),
                    id_aula = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Presenca__F3BA19A7289CA42F", x => x.id_presenca);
                    table.ForeignKey(
                        name: "FK__Presenca__id_alu__44FF419A",
                        column: x => x.id_aluno,
                        principalTable: "Aluno",
                        principalColumn: "id_aluno");
                    table.ForeignKey(
                        name: "FK__Presenca__id_aul__45F365D3",
                        column: x => x.id_aula,
                        principalTable: "Aula",
                        principalColumn: "id_aula");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aula_id_instrutor",
                table: "Aula",
                column: "id_instrutor");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_id_aluno",
                table: "Matricula",
                column: "id_aluno");

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_id_aluno",
                table: "Presenca",
                column: "id_aluno");

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_id_aula",
                table: "Presenca",
                column: "id_aula");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matricula");

            migrationBuilder.DropTable(
                name: "Presenca");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Aula");

            migrationBuilder.DropTable(
                name: "Instrutor");
        }
    }
}
