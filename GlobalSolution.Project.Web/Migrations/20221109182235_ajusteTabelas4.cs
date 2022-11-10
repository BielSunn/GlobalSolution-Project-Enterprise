using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalSolution.Project.Web.Migrations
{
    public partial class ajusteTabelas4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_BAIRRO_T_CIDADE_CidadeId",
                table: "T_BAIRRO");

            migrationBuilder.DropForeignKey(
                name: "FK_T_CIDADE_T_ESTADO_EstadoId",
                table: "T_CIDADE");

            migrationBuilder.DropForeignKey(
                name: "FK_T_LOCAL_T_LOGRADOURO_LogradouroId",
                table: "T_LOCAL");

            migrationBuilder.DropForeignKey(
                name: "FK_T_LOCAL_T_TELEFONE_TelefoneId",
                table: "T_LOCAL");

            migrationBuilder.DropForeignKey(
                name: "FK_T_LOGRADOURO_T_BAIRRO_BairroId",
                table: "T_LOGRADOURO");

            migrationBuilder.RenameColumn(
                name: "BairroId",
                table: "T_LOGRADOURO",
                newName: "id_bairro");

            migrationBuilder.RenameIndex(
                name: "IX_T_LOGRADOURO_BairroId",
                table: "T_LOGRADOURO",
                newName: "IX_T_LOGRADOURO_id_bairro");

            migrationBuilder.RenameColumn(
                name: "TelefoneId",
                table: "T_LOCAL",
                newName: "id_telefone");

            migrationBuilder.RenameColumn(
                name: "LogradouroId",
                table: "T_LOCAL",
                newName: "id_logradouro");

            migrationBuilder.RenameIndex(
                name: "IX_T_LOCAL_TelefoneId",
                table: "T_LOCAL",
                newName: "IX_T_LOCAL_id_telefone");

            migrationBuilder.RenameIndex(
                name: "IX_T_LOCAL_LogradouroId",
                table: "T_LOCAL",
                newName: "IX_T_LOCAL_id_logradouro");

            migrationBuilder.RenameColumn(
                name: "EstadoId",
                table: "T_CIDADE",
                newName: "id_estado");

            migrationBuilder.RenameIndex(
                name: "IX_T_CIDADE_EstadoId",
                table: "T_CIDADE",
                newName: "IX_T_CIDADE_id_estado");

            migrationBuilder.RenameColumn(
                name: "CidadeId",
                table: "T_BAIRRO",
                newName: "id_cidade");

            migrationBuilder.RenameIndex(
                name: "IX_T_BAIRRO_CidadeId",
                table: "T_BAIRRO",
                newName: "IX_T_BAIRRO_id_cidade");

            migrationBuilder.AddForeignKey(
                name: "FK_T_BAIRRO_T_CIDADE_id_cidade",
                table: "T_BAIRRO",
                column: "id_cidade",
                principalTable: "T_CIDADE",
                principalColumn: "id_cidade",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_CIDADE_T_ESTADO_id_estado",
                table: "T_CIDADE",
                column: "id_estado",
                principalTable: "T_ESTADO",
                principalColumn: "id_estado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_LOCAL_T_LOGRADOURO_id_logradouro",
                table: "T_LOCAL",
                column: "id_logradouro",
                principalTable: "T_LOGRADOURO",
                principalColumn: "id_logradouro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_LOCAL_T_TELEFONE_id_telefone",
                table: "T_LOCAL",
                column: "id_telefone",
                principalTable: "T_TELEFONE",
                principalColumn: "id_telefone",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_LOGRADOURO_T_BAIRRO_id_bairro",
                table: "T_LOGRADOURO",
                column: "id_bairro",
                principalTable: "T_BAIRRO",
                principalColumn: "id_bairro",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_BAIRRO_T_CIDADE_id_cidade",
                table: "T_BAIRRO");

            migrationBuilder.DropForeignKey(
                name: "FK_T_CIDADE_T_ESTADO_id_estado",
                table: "T_CIDADE");

            migrationBuilder.DropForeignKey(
                name: "FK_T_LOCAL_T_LOGRADOURO_id_logradouro",
                table: "T_LOCAL");

            migrationBuilder.DropForeignKey(
                name: "FK_T_LOCAL_T_TELEFONE_id_telefone",
                table: "T_LOCAL");

            migrationBuilder.DropForeignKey(
                name: "FK_T_LOGRADOURO_T_BAIRRO_id_bairro",
                table: "T_LOGRADOURO");

            migrationBuilder.RenameColumn(
                name: "id_bairro",
                table: "T_LOGRADOURO",
                newName: "BairroId");

            migrationBuilder.RenameIndex(
                name: "IX_T_LOGRADOURO_id_bairro",
                table: "T_LOGRADOURO",
                newName: "IX_T_LOGRADOURO_BairroId");

            migrationBuilder.RenameColumn(
                name: "id_telefone",
                table: "T_LOCAL",
                newName: "TelefoneId");

            migrationBuilder.RenameColumn(
                name: "id_logradouro",
                table: "T_LOCAL",
                newName: "LogradouroId");

            migrationBuilder.RenameIndex(
                name: "IX_T_LOCAL_id_telefone",
                table: "T_LOCAL",
                newName: "IX_T_LOCAL_TelefoneId");

            migrationBuilder.RenameIndex(
                name: "IX_T_LOCAL_id_logradouro",
                table: "T_LOCAL",
                newName: "IX_T_LOCAL_LogradouroId");

            migrationBuilder.RenameColumn(
                name: "id_estado",
                table: "T_CIDADE",
                newName: "EstadoId");

            migrationBuilder.RenameIndex(
                name: "IX_T_CIDADE_id_estado",
                table: "T_CIDADE",
                newName: "IX_T_CIDADE_EstadoId");

            migrationBuilder.RenameColumn(
                name: "id_cidade",
                table: "T_BAIRRO",
                newName: "CidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_T_BAIRRO_id_cidade",
                table: "T_BAIRRO",
                newName: "IX_T_BAIRRO_CidadeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_T_LOGRADOURO_T_BAIRRO_BairroId",
                table: "T_LOGRADOURO",
                column: "BairroId",
                principalTable: "T_BAIRRO",
                principalColumn: "id_bairro",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
