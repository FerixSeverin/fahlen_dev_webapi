using Microsoft.EntityFrameworkCore.Migrations;

namespace fahlen_dev_webapi.Migrations
{
    public partial class AccountAddList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Accounts_AccountId",
                table: "Recipes");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Recipes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Accounts_AccountId",
                table: "Recipes",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Accounts_AccountId",
                table: "Recipes");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Recipes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Accounts_AccountId",
                table: "Recipes",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
