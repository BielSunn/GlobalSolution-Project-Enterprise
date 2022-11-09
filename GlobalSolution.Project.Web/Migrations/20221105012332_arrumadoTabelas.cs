using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalSolution.Project.Web.Migrations
{
    public partial class arrumadoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_LOGRADOURO");

            migrationBuilder.AddColumn<int>(
                name: "TelefoneId",
                table: "T_USUARIO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "T_LOCAL",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "T_CIDADE",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CidadeId",
                table: "T_BAIRRO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AcessibilidadeLocais",
                columns: table => new
                {
                    LocalId = table.Column<int>(type: "int", nullable: false),
                    AcessibilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcessibilidadeLocais", x => new { x.AcessibilidadeId, x.LocalId });
                    table.ForeignKey(
                        name: "FK_AcessibilidadeLocais_T_ACESSIBILIDADE_AcessibilidadeId",
                        column: x => x.AcessibilidadeId,
                        principalTable: "T_ACESSIBILIDADE",
                        principalColumn: "id_acessibilidade",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcessibilidadeLocais_T_LOCAL_LocalId",
                        column: x => x.LocalId,
                        principalTable: "T_LOCAL",
                        principalColumn: "id_local",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_ENDERECO",
                columns: table => new
                {
                    id_logradouro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ds_logradouro = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true),
                    nr_cep = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BairroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ENDERECO", x => x.id_logradouro);
                    table.ForeignKey(
                        name: "FK_T_ENDERECO_T_BAIRRO_BairroId",
                        column: x => x.BairroId,
                        principalTable: "T_BAIRRO",
                        principalColumn: "id_bairro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_USUARIO_TelefoneId",
                table: "T_USUARIO",
                column: "TelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_T_LOCAL_EnderecoId",
                table: "T_LOCAL",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_T_CIDADE_EstadoId",
                table: "T_CIDADE",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_T_BAIRRO_CidadeId",
                table: "T_BAIRRO",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_AcessibilidadeLocais_LocalId",
                table: "AcessibilidadeLocais",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_T_ENDERECO_BairroId",
                table: "T_ENDERECO",
                column: "BairroId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_BAIRRO_T_CIDADE_CidadeId",
                table: "T_BAIRRO",
                column: "CidadeId",
                principalTable: "T_CIDADE",
                principalColumn: "id_cidade",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_CIDADE_T_ESTADO_EstadoId",
                table: "T_CIDADE",
                column: "EstadoId",
                principalTable: "T_ESTADO",
                principalColumn: "id_estado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_LOCAL_T_ENDERECO_EnderecoId",
                table: "T_LOCAL",
                column: "EnderecoId",
                principalTable: "T_ENDERECO",
                principalColumn: "id_logradouro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_USUARIO_T_TELEFONE_TelefoneId",
                table: "T_USUARIO",
                column: "TelefoneId",
                principalTable: "T_TELEFONE",
                principalColumn: "id_telefone",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_BAIRRO_T_CIDADE_CidadeId",
                table: "T_BAIRRO");

            migrationBuilder.DropForeignKey(
                name: "FK_T_CIDADE_T_ESTADO_EstadoId",
                table: "T_CIDADE");

            migrationBuilder.DropForeignKey(
                name: "FK_T_LOCAL_T_ENDERECO_EnderecoId",
                table: "T_LOCAL");

            migrationBuilder.DropForeignKey(
                name: "FK_T_USUARIO_T_TELEFONE_TelefoneId",
                table: "T_USUARIO");

            migrationBuilder.DropTable(
                name: "AcessibilidadeLocais");

            migrationBuilder.DropTable(
                name: "T_ENDERECO");

            migrationBuilder.DropIndex(
                name: "IX_T_USUARIO_TelefoneId",
                table: "T_USUARIO");

            migrationBuilder.DropIndex(
                name: "IX_T_LOCAL_EnderecoId",
                table: "T_LOCAL");

            migrationBuilder.DropIndex(
                name: "IX_T_CIDADE_EstadoId",
                table: "T_CIDADE");

            migrationBuilder.DropIndex(
                name: "IX_T_BAIRRO_CidadeId",
                table: "T_BAIRRO");

            migrationBuilder.DropColumn(
                name: "TelefoneId",
                table: "T_USUARIO");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "T_LOCAL");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "T_CIDADE");

            migrationBuilder.DropColumn(
                name: "CidadeId",
                table: "T_BAIRRO");

            migrationBuilder.CreateTable(
                name: "T_LOGRADOURO",
                columns: table => new
                {
                    id_logradouro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nr_cep = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ds_logradouro = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_LOGRADOURO", x => x.id_logradouro);
                });
        }
    }
}
