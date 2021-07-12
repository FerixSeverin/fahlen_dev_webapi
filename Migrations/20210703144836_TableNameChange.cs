using Microsoft.EntityFrameworkCore.Migrations;

namespace fahlen_dev_webapi.Migrations
{
    public partial class TableNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Measure_MeasureId",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_RecipeGroup_RecipeGroupId",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Accounts_AccountId",
                table: "Recipe");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeGroup_Recipe_RecipeId",
                table: "RecipeGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeGroup",
                table: "RecipeGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Measure",
                table: "Measure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.RenameTable(
                name: "RecipeGroup",
                newName: "RecipeGroups");

            migrationBuilder.RenameTable(
                name: "Recipe",
                newName: "Recipes");

            migrationBuilder.RenameTable(
                name: "Measure",
                newName: "Measures");

            migrationBuilder.RenameTable(
                name: "Ingredient",
                newName: "Ingredients");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeGroup_RecipeId",
                table: "RecipeGroups",
                newName: "IX_RecipeGroups_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipe_AccountId",
                table: "Recipes",
                newName: "IX_Recipes_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredient_RecipeGroupId",
                table: "Ingredients",
                newName: "IX_Ingredients_RecipeGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredient_MeasureId",
                table: "Ingredients",
                newName: "IX_Ingredients_MeasureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeGroups",
                table: "RecipeGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Measures",
                table: "Measures",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Accounts_AccountId",
                table: "Recipes",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Accounts_AccountId",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeGroups",
                table: "RecipeGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Measures",
                table: "Measures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.RenameTable(
                name: "Recipes",
                newName: "Recipe");

            migrationBuilder.RenameTable(
                name: "RecipeGroups",
                newName: "RecipeGroup");

            migrationBuilder.RenameTable(
                name: "Measures",
                newName: "Measure");

            migrationBuilder.RenameTable(
                name: "Ingredients",
                newName: "Ingredient");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_AccountId",
                table: "Recipe",
                newName: "IX_Recipe_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeGroups_RecipeId",
                table: "RecipeGroup",
                newName: "IX_RecipeGroup_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_RecipeGroupId",
                table: "Ingredient",
                newName: "IX_Ingredient_RecipeGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_MeasureId",
                table: "Ingredient",
                newName: "IX_Ingredient_MeasureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeGroup",
                table: "RecipeGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Measure",
                table: "Measure",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Measure_MeasureId",
                table: "Ingredient",
                column: "MeasureId",
                principalTable: "Measure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_RecipeGroup_RecipeGroupId",
                table: "Ingredient",
                column: "RecipeGroupId",
                principalTable: "RecipeGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Accounts_AccountId",
                table: "Recipe",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeGroup_Recipe_RecipeId",
                table: "RecipeGroup",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
