using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalSolution.Project.Web.Migrations
{
    public partial class CriadoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_BAIRRO",
                columns: table => new
                {
                    id_bairro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nm_bairro = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_BAIRRO", x => x.id_bairro);
                });

            migrationBuilder.CreateTable(
                name: "T_CIDADE",
                columns: table => new
                {
                    id_cidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nm_cidade = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CIDADE", x => x.id_cidade);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_BAIRRO");

            migrationBuilder.DropTable(
                name: "T_CIDADE");

            migrationBuilder.DropTable(
                name: "T_ESTADO");
        }
    }
}
