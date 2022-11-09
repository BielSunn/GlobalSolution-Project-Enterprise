using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalSolution.Project.Web.Migrations
{
    public partial class CriadoTabelas_Relacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_BAIRRO");

            migrationBuilder.DropTable(
                name: "T_CIDADE");

            migrationBuilder.DropTable(
                name: "T_ESTADO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_ESTADO",
                columns: table => new
                {
                    id_estado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nm_estado = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    sg_estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ESTADO", x => x.id_estado);
                });

            migrationBuilder.CreateTable(
                name: "T_CIDADE",
                columns: table => new
                {
                    id_cidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    nm_cidade = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CIDADE", x => x.id_cidade);
                    table.ForeignKey(
                        name: "FK_T_CIDADE_T_ESTADO_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "T_ESTADO",
                        principalColumn: "id_estado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_BAIRRO",
                columns: table => new
                {
                    id_bairro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CidadeId = table.Column<int>(type: "int", nullable: false),
                    nm_bairro = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_BAIRRO", x => x.id_bairro);
                    table.ForeignKey(
                        name: "FK_T_BAIRRO_T_CIDADE_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "T_CIDADE",
                        principalColumn: "id_cidade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_BAIRRO_CidadeId",
                table: "T_BAIRRO",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_T_CIDADE_EstadoId",
                table: "T_CIDADE",
                column: "EstadoId");
        }
    }
}
