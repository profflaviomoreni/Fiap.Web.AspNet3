using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Web.AspNet3.Migrations
{
    public partial class GerenteModelCorrigindoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Gerente",
                table: "Gerente");

            migrationBuilder.DropColumn(
                name: "GerenteId",
                table: "Gerente");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Gerente",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gerente",
                table: "Gerente",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Gerente",
                table: "Gerente");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Gerente");

            migrationBuilder.AddColumn<string>(
                name: "GerenteId",
                table: "Gerente",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gerente",
                table: "Gerente",
                column: "GerenteId");
        }
    }
}
