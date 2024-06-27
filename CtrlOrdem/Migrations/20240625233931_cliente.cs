using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CtrlOrdem.Migrations
{
    /// <inheritdoc />
    public partial class cliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CPFCNPJ",
                table: "Cliente",
                type: "nvarchar(18)",
                maxLength: 18,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.CreateIndex(
                name: "IX_Ordem_ClienteId",
                table: "Ordem",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordem_ServicoId",
                table: "Ordem",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordem_TecnicoId",
                table: "Ordem",
                column: "TecnicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordem_Cliente_ClienteId",
                table: "Ordem",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordem_Servico_ServicoId",
                table: "Ordem",
                column: "ServicoId",
                principalTable: "Servico",
                principalColumn: "ServicoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordem_Tecnico_TecnicoId",
                table: "Ordem",
                column: "TecnicoId",
                principalTable: "Tecnico",
                principalColumn: "TecnicoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordem_Cliente_ClienteId",
                table: "Ordem");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordem_Servico_ServicoId",
                table: "Ordem");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordem_Tecnico_TecnicoId",
                table: "Ordem");

            migrationBuilder.DropIndex(
                name: "IX_Ordem_ClienteId",
                table: "Ordem");

            migrationBuilder.DropIndex(
                name: "IX_Ordem_ServicoId",
                table: "Ordem");

            migrationBuilder.DropIndex(
                name: "IX_Ordem_TecnicoId",
                table: "Ordem");

            migrationBuilder.AlterColumn<string>(
                name: "CPFCNPJ",
                table: "Cliente",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(18)",
                oldMaxLength: 18);
        }
    }
}
