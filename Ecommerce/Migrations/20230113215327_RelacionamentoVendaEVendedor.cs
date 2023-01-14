using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Migrations
{
    public partial class RelacionamentoVendaEVendedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Vendedores_VendedorIdVendedor",
                table: "Vendas");

            migrationBuilder.RenameColumn(
                name: "IdVendedor",
                table: "Vendedores",
                newName: "VendedorId");

            migrationBuilder.RenameColumn(
                name: "VendedorIdVendedor",
                table: "Vendas",
                newName: "VendedorId");

            migrationBuilder.RenameColumn(
                name: "IdVenda",
                table: "Vendas",
                newName: "VendaId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_VendedorIdVendedor",
                table: "Vendas",
                newName: "IX_Vendas_VendedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Vendedores_VendedorId",
                table: "Vendas",
                column: "VendedorId",
                principalTable: "Vendedores",
                principalColumn: "VendedorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Vendedores_VendedorId",
                table: "Vendas");

            migrationBuilder.RenameColumn(
                name: "VendedorId",
                table: "Vendedores",
                newName: "IdVendedor");

            migrationBuilder.RenameColumn(
                name: "VendedorId",
                table: "Vendas",
                newName: "VendedorIdVendedor");

            migrationBuilder.RenameColumn(
                name: "VendaId",
                table: "Vendas",
                newName: "IdVenda");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_VendedorId",
                table: "Vendas",
                newName: "IX_Vendas_VendedorIdVendedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Vendedores_VendedorIdVendedor",
                table: "Vendas",
                column: "VendedorIdVendedor",
                principalTable: "Vendedores",
                principalColumn: "IdVendedor",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
