using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByC.REST.Migrations
{
    public partial class adding_relationship_transaction_cnab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CnabId",
                table: "Transactions",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CnabId",
                table: "Transactions",
                column: "CnabId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Cnabs_CnabId",
                table: "Transactions",
                column: "CnabId",
                principalTable: "Cnabs",
                principalColumn: "Value",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Cnabs_CnabId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CnabId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CnabId",
                table: "Transactions");
        }
    }
}
