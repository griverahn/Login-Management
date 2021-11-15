using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginManagemet.Migrations
{
    public partial class addingreferencefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChildSubcategorId",
                table: "RoleAccess",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "optionId",
                table: "RoleAccess",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "MenuSubcategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "MenuOptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "ChildSubMenu",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChildSubcategorId",
                table: "RoleAccess");

            migrationBuilder.DropColumn(
                name: "optionId",
                table: "RoleAccess");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "MenuSubcategories");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "MenuOptions");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "ChildSubMenu");
        }
    }
}
