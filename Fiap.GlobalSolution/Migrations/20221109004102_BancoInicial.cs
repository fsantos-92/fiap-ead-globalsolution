using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.GlobalSolution.Migrations
{
    public partial class BancoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_FB_PASSAGEIRO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm_passageiro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nr_cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nr_rg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ds_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ds_senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FB_PASSAGEIRO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_FB_PRONTO_TRABALHO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ds_nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ds_endereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FB_PRONTO_TRABALHO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_FB_TELEFONE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nr_ddd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nr_telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FB_TELEFONE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_FB_MOTORISTA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm_motorista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nr_cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nr_cnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    St_ativo = table.Column<bool>(type: "bit", nullable: false),
                    Ds_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ds_senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TelefoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FB_MOTORISTA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_FB_MOTORISTA_TB_FB_TELEFONE_TelefoneId",
                        column: x => x.TelefoneId,
                        principalTable: "TB_FB_TELEFONE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotoristaPontoTrabalhos",
                columns: table => new
                {
                    MotoristaId = table.Column<int>(type: "int", nullable: false),
                    PontoTrabalhoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotoristaPontoTrabalhos", x => new { x.PontoTrabalhoId, x.MotoristaId });
                    table.ForeignKey(
                        name: "FK_MotoristaPontoTrabalhos_TB_FB_MOTORISTA_MotoristaId",
                        column: x => x.MotoristaId,
                        principalTable: "TB_FB_MOTORISTA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotoristaPontoTrabalhos_TB_FB_PRONTO_TRABALHO_PontoTrabalhoId",
                        column: x => x.PontoTrabalhoId,
                        principalTable: "TB_FB_PRONTO_TRABALHO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_FB_CORRIDA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ds_origem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ds_destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vl_corrida = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Dt_corrida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    st_finalizado = table.Column<bool>(type: "bit", nullable: false),
                    PassageiroId = table.Column<int>(type: "int", nullable: false),
                    MotoristaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FB_CORRIDA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_FB_CORRIDA_TB_FB_MOTORISTA_MotoristaId",
                        column: x => x.MotoristaId,
                        principalTable: "TB_FB_MOTORISTA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_FB_CORRIDA_TB_FB_PASSAGEIRO_PassageiroId",
                        column: x => x.PassageiroId,
                        principalTable: "TB_FB_PASSAGEIRO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_FB_VEICULO",
                columns: table => new
                {
                    VeiculoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ds_modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ds_ano = table.Column<int>(type: "int", nullable: false),
                    Ds_cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nr_placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotoristaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FB_VEICULO", x => x.VeiculoId);
                    table.ForeignKey(
                        name: "FK_TB_FB_VEICULO_TB_FB_MOTORISTA_MotoristaId",
                        column: x => x.MotoristaId,
                        principalTable: "TB_FB_MOTORISTA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MotoristaPontoTrabalhos_MotoristaId",
                table: "MotoristaPontoTrabalhos",
                column: "MotoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_FB_CORRIDA_MotoristaId",
                table: "TB_FB_CORRIDA",
                column: "MotoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_FB_CORRIDA_PassageiroId",
                table: "TB_FB_CORRIDA",
                column: "PassageiroId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_FB_MOTORISTA_TelefoneId",
                table: "TB_FB_MOTORISTA",
                column: "TelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_FB_VEICULO_MotoristaId",
                table: "TB_FB_VEICULO",
                column: "MotoristaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MotoristaPontoTrabalhos");

            migrationBuilder.DropTable(
                name: "TB_FB_CORRIDA");

            migrationBuilder.DropTable(
                name: "TB_FB_VEICULO");

            migrationBuilder.DropTable(
                name: "TB_FB_PRONTO_TRABALHO");

            migrationBuilder.DropTable(
                name: "TB_FB_PASSAGEIRO");

            migrationBuilder.DropTable(
                name: "TB_FB_MOTORISTA");

            migrationBuilder.DropTable(
                name: "TB_FB_TELEFONE");
        }
    }
}
