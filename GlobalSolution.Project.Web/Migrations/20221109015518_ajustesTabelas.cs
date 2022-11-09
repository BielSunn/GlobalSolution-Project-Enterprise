using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalSolution.Project.Web.Migrations
{
    public partial class ajustesTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_LOCAL_T_ENDERECO_EnderecoId",
                table: "T_LOCAL");

            migrationBuilder.DropTable(
                name: "T_ENDERECO");

            migrationBuilder.DropIndex(
                name: "IX_T_LOCAL_EnderecoId",
                table: "T_LOCAL");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "T_LOCAL");

            migrationBuilder.AddColumn<string>(
                name: "ds_acessibilidade",
                table: "T_ACESSIBILIDADE",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ds_acessibilidade",
                table: "T_ACESSIBILIDADE");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "T_LOCAL",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "T_ENDERECO",
                columns: table => new
                {
                    id_logradouro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nr_cep = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ds_logradouro = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ENDERECO", x => x.id_logradouro);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_LOCAL_EnderecoId",
                table: "T_LOCAL",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_LOCAL_T_ENDERECO_EnderecoId",
                table: "T_LOCAL",
                column: "EnderecoId",
                principalTable: "T_ENDERECO",
                principalColumn: "id_logradouro",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
