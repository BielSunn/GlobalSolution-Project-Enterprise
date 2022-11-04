using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalSolution.Project.Web.Migrations
{
    public partial class CriadoTabelas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_ACESSIBILIDADE",
                columns: table => new
                {
                    id_acessibilidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tp_acessibilidade = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ACESSIBILIDADE", x => x.id_acessibilidade);
                });

            migrationBuilder.CreateTable(
                name: "T_LOCAL",
                columns: table => new
                {
                    id_local = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nm_local = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true),
                    tp_local = table.Column<int>(type: "int", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_LOCAL", x => x.id_local);
                });

            migrationBuilder.CreateTable(
                name: "T_LOGRADOURO",
                columns: table => new
                {
                    id_logradouro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ds_logradouro = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true),
                    nr_cep = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_LOGRADOURO", x => x.id_logradouro);
                });

            migrationBuilder.CreateTable(
                name: "T_TELEFONE",
                columns: table => new
                {
                    id_telefone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nr_ddd = table.Column<int>(type: "int", nullable: false),
                    nr_telefone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TELEFONE", x => x.id_telefone);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_ACESSIBILIDADE");

            migrationBuilder.DropTable(
                name: "T_LOCAL");

            migrationBuilder.DropTable(
                name: "T_LOGRADOURO");

            migrationBuilder.DropTable(
                name: "T_TELEFONE");
        }
    }
}
