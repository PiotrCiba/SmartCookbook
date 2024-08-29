using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartCookbook.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCascadingDeletion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CookingSteps_Recipes_RecipeId",
                table: "CookingSteps");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientInstance_Recipes_RecipeId",
                table: "IngredientInstance");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "IngredientInstance",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "CookingSteps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CookingSteps_Recipes_RecipeId",
                table: "CookingSteps",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientInstance_Recipes_RecipeId",
                table: "IngredientInstance",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CookingSteps_Recipes_RecipeId",
                table: "CookingSteps");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientInstance_Recipes_RecipeId",
                table: "IngredientInstance");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "IngredientInstance",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "CookingSteps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CookingSteps_Recipes_RecipeId",
                table: "CookingSteps",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientInstance_Recipes_RecipeId",
                table: "IngredientInstance",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }
    }
}
