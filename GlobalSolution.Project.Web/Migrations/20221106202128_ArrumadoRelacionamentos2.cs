using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalSolution.Project.Web.Migrations
{
    public partial class ArrumadoRelacionamentos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "tp_local",
                table: "T_LOCAL",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 30);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "tp_local",
                table: "T_LOCAL",
                type: "int",
                maxLength: 30,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
