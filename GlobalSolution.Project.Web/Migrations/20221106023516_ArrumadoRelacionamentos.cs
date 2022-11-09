using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalSolution.Project.Web.Migrations
{
    public partial class ArrumadoRelacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_ENDERECO_T_BAIRRO_BairroId",
                table: "T_ENDERECO");

            migrationBuilder.DropIndex(
                name: "IX_T_ENDERECO_BairroId",
                table: "T_ENDERECO");

            migrationBuilder.DropColumn(
                name: "BairroId",
                table: "T_ENDERECO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BairroId",
                table: "T_ENDERECO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_T_ENDERECO_BairroId",
                table: "T_ENDERECO",
                column: "BairroId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_ENDERECO_T_BAIRRO_BairroId",
                table: "T_ENDERECO",
                column: "BairroId",
                principalTable: "T_BAIRRO",
                principalColumn: "id_bairro",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
