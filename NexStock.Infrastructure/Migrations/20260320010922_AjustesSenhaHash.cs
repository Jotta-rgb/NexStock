using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexStock.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustesSenhaHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuarios",
                newName: "SenhaHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenhaHash",
                table: "Usuarios",
                newName: "Senha");
        }
    }
}
