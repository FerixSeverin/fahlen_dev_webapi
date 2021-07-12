using Microsoft.EntityFrameworkCore.Migrations;

namespace fahlen_dev_webapi.Migrations
{
    public partial class FKFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Measures_MeasureId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_RecipeGroups_RecipeGroupId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeGroups_Recipes_RecipeId",
                table: "RecipeGroups");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "RecipeGroups",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecipeGroupId",
                table: "Ingredients",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MeasureId",
                table: "Ingredients",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Measures_MeasureId",
                table: "Ingredients",
                column: "MeasureId",
                principalTable: "Measures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_RecipeGroups_RecipeGroupId",
                table: "Ingredients",
                column: "RecipeGroupId",
                principalTable: "RecipeGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeGroups_Recipes_RecipeId",
                table: "RecipeGroups",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Measures_MeasureId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_RecipeGroups_RecipeGroupId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeGroups_Recipes_RecipeId",
                table: "RecipeGroups");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "RecipeGroups",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeGroupId",
                table: "Ingredients",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "MeasureId",
                table: "Ingredients",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Measures_MeasureId",
                table: "Ingredients",
                column: "MeasureId",
                principalTable: "Measures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_RecipeGroups_RecipeGroupId",
                table: "Ingredients",
                column: "RecipeGroupId",
                principalTable: "RecipeGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeGroups_Recipes_RecipeId",
                table: "RecipeGroups",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
