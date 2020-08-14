using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefNDishes.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChefId1",
                table: "Chefs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chefs_ChefId1",
                table: "Chefs",
                column: "ChefId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Chefs_Chefs_ChefId1",
                table: "Chefs",
                column: "ChefId1",
                principalTable: "Chefs",
                principalColumn: "ChefId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chefs_Chefs_ChefId1",
                table: "Chefs");

            migrationBuilder.DropIndex(
                name: "IX_Chefs_ChefId1",
                table: "Chefs");

            migrationBuilder.DropColumn(
                name: "ChefId1",
                table: "Chefs");
        }
    }
}
