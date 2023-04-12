using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Whammy.DataAccess.Migrations
{
    public partial class RenameInOrderHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "orderHeaders",
                newName: "SessionId");

            migrationBuilder.AddColumn<string>(
                name: "PaymentIntentId",
                table: "orderHeaders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentIntentId",
                table: "orderHeaders");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "orderHeaders",
                newName: "TransactionId");
        }
    }
}
