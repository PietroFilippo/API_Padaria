using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trabalho.Migrations
{
    /// <inheritdoc />
    public partial class MudançaModelsControllers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "ItensPedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "Preço",
                table: "Salgado",
                newName: "PreçoSalgado");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Salgado",
                newName: "NomeSalgado");

            migrationBuilder.RenameColumn(
                name: "Preço",
                table: "Doce",
                newName: "PreçoDoce");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Doce",
                newName: "NomeDoce");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreçoSalgado",
                table: "Salgado",
                newName: "Preço");

            migrationBuilder.RenameColumn(
                name: "NomeSalgado",
                table: "Salgado",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "PreçoDoce",
                table: "Doce",
                newName: "Preço");

            migrationBuilder.RenameColumn(
                name: "NomeDoce",
                table: "Doce",
                newName: "Nome");

            migrationBuilder.CreateTable(
                name: "ItensPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PedidoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPedido_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_PedidoId",
                table: "ItensPedido",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
