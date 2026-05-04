using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplyTrack.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantidadeEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Tipo",
                table: "Movimentacoes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeEstoque",
                table: "Mercadorias",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeEstoque",
                table: "Mercadorias");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Movimentacoes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
