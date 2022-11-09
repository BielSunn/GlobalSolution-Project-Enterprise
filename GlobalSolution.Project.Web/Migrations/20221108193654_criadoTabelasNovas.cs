using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalSolution.Project.Web.Migrations
{
    public partial class criadoTabelasNovas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "tp_local",
                table: "T_LOCAL",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogradouroId",
                table: "T_LOCAL",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TelefoneId",
                table: "T_LOCAL",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "tp_acessibilidade",
                table: "T_ACESSIBILIDADE",
                type: "nvarchar(90)",
                maxLength: 90,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(90)",
                oldMaxLength: 90,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "T_ESTADO",
                columns: table => new
                {
                    id_estado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nm_estado = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
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
                    nm_cidade = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
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
                    nm_cidade = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    CidadeId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "T_LOGRADOURO",
                columns: table => new
                {
                    id_logradouro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ds_logradouro = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    nr_cep = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BairroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_LOGRADOURO", x => x.id_logradouro);
                    table.ForeignKey(
                        name: "FK_T_LOGRADOURO_T_BAIRRO_BairroId",
                        column: x => x.BairroId,
                        principalTable: "T_BAIRRO",
                        principalColumn: "id_bairro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_LOCAL_LogradouroId",
                table: "T_LOCAL",
                column: "LogradouroId");

            migrationBuilder.CreateIndex(
                name: "IX_T_LOCAL_TelefoneId",
                table: "T_LOCAL",
                column: "TelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_T_BAIRRO_CidadeId",
                table: "T_BAIRRO",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_T_CIDADE_EstadoId",
                table: "T_CIDADE",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_T_LOGRADOURO_BairroId",
                table: "T_LOGRADOURO",
                column: "BairroId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_LOCAL_T_LOGRADOURO_LogradouroId",
                table: "T_LOCAL",
                column: "LogradouroId",
                principalTable: "T_LOGRADOURO",
                principalColumn: "id_logradouro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_LOCAL_T_TELEFONE_TelefoneId",
                table: "T_LOCAL",
                column: "TelefoneId",
                principalTable: "T_TELEFONE",
                principalColumn: "id_telefone",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_LOCAL_T_LOGRADOURO_LogradouroId",
                table: "T_LOCAL");

            migrationBuilder.DropForeignKey(
                name: "FK_T_LOCAL_T_TELEFONE_TelefoneId",
                table: "T_LOCAL");

            migrationBuilder.DropTable(
                name: "T_LOGRADOURO");

            migrationBuilder.DropTable(
                name: "T_BAIRRO");

            migrationBuilder.DropTable(
                name: "T_CIDADE");

            migrationBuilder.DropTable(
                name: "T_ESTADO");

            migrationBuilder.DropIndex(
                name: "IX_T_LOCAL_LogradouroId",
                table: "T_LOCAL");

            migrationBuilder.DropIndex(
                name: "IX_T_LOCAL_TelefoneId",
                table: "T_LOCAL");

            migrationBuilder.DropColumn(
                name: "LogradouroId",
                table: "T_LOCAL");

            migrationBuilder.DropColumn(
                name: "TelefoneId",
                table: "T_LOCAL");

            migrationBuilder.AlterColumn<int>(
                name: "tp_local",
                table: "T_LOCAL",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "tp_acessibilidade",
                table: "T_ACESSIBILIDADE",
                type: "nvarchar(90)",
                maxLength: 90,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(90)",
                oldMaxLength: 90);
        }
    }
}
