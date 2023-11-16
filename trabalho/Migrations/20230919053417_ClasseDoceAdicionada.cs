using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trabalho.Migrations
{
    /// <inheritdoc />
    public partial class ClasseDoceAdicionada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Salgado",
                table: "Salgado");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Salgado");

            migrationBuilder.AlterColumn<string>(
                name: "Preço",
                table: "Salgado",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Salgado",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salgado",
                table: "Salgado",
                column: "Nome");

            migrationBuilder.CreateTable(
                name: "Doce",
                columns: table => new
                {
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Preço = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doce", x => x.Nome);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doce");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salgado",
                table: "Salgado");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Salgado");

            migrationBuilder.AlterColumn<string>(
                name: "Preço",
                table: "Salgado",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Salgado",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salgado",
                table: "Salgado",
                column: "Preço");
        }
    }
}
