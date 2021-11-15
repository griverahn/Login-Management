using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginManagemet.Migrations
{
    public partial class fix_child_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildSubMenu_MenuOptions_MenuOptionId",
                table: "ChildSubMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildSubMenu_MenuSubcategories_MenuSubcategoryId",
                table: "ChildSubMenu");

            migrationBuilder.DropIndex(
                name: "IX_ChildSubMenu_MenuSubcategoryId",
                table: "ChildSubMenu");

            migrationBuilder.DropColumn(
                name: "MenuSubcategoryId",
                table: "ChildSubMenu");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildSubMenu_MenuSubcategories_MenuOptionId",
                table: "ChildSubMenu",
                column: "MenuOptionId",
                principalTable: "MenuSubcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildSubMenu_MenuSubcategories_MenuOptionId",
                table: "ChildSubMenu");

            migrationBuilder.AddColumn<int>(
                name: "MenuSubcategoryId",
                table: "ChildSubMenu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChildSubMenu_MenuSubcategoryId",
                table: "ChildSubMenu",
                column: "MenuSubcategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildSubMenu_MenuOptions_MenuOptionId",
                table: "ChildSubMenu",
                column: "MenuOptionId",
                principalTable: "MenuOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildSubMenu_MenuSubcategories_MenuSubcategoryId",
                table: "ChildSubMenu",
                column: "MenuSubcategoryId",
                principalTable: "MenuSubcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
