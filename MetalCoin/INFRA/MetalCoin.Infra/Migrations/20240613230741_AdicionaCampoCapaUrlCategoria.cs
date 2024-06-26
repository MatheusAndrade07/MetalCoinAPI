using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetalCoin.Infra.Migrations
{
    public partial class AdicionaCampoCapaUrlCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CapaUrl",
                table: "Categorias",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CapaUrl",
                table: "Categorias");
        }
    }
}
