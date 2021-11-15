using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginManagemet.Migrations
{
    public partial class adding_menu_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChildSubMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subcategory_id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuOptionId = table.Column<int>(type: "int", nullable: true),
                    MenuSubcategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildSubMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildSubMenu_MenuOptions_MenuOptionId",
                        column: x => x.MenuOptionId,
                        principalTable: "MenuOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChildSubMenu_MenuSubcategories_MenuSubcategoryId",
                        column: x => x.MenuSubcategoryId,
                        principalTable: "MenuSubcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildSubMenu_MenuOptionId",
                table: "ChildSubMenu",
                column: "MenuOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildSubMenu_MenuSubcategoryId",
                table: "ChildSubMenu",
                column: "MenuSubcategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildSubMenu");
        }
    }
}
