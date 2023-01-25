using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Migrations
{
    public partial class AdicionandoValorTotalemVendaseValorTotalVendasemVendedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ValorTotalVendas",
                table: "Vendedores",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ValorTotal",
                table: "Vendas",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorTotalVendas",
                table: "Vendedores");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Vendas");
        }
    }
}
