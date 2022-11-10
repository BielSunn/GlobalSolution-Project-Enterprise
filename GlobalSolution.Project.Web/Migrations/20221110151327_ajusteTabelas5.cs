using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalSolution.Project.Web.Migrations
{
    public partial class ajusteTabelas5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_USUARIO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_USUARIO",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelefoneId = table.Column<int>(type: "int", nullable: false),
                    dt_nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ds_email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nm_usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ds_senha = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USUARIO", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_T_USUARIO_T_TELEFONE_TelefoneId",
                        column: x => x.TelefoneId,
                        principalTable: "T_TELEFONE",
                        principalColumn: "id_telefone",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_USUARIO_TelefoneId",
                table: "T_USUARIO",
                column: "TelefoneId");
        }
    }
}
