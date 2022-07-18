using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Web.AspNet3.Migrations
{
    public partial class FornecedorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    FornecedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FornecedorNome = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.FornecedorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fornecedor");
        }
    }
}
