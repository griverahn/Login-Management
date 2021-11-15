using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginManagemet.Migrations
{
    public partial class alterroleaccesstables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChildSubcategorId",
                table: "RoleAccess");

            migrationBuilder.DropColumn(
                name: "SubcategoryId",
                table: "RoleAccess");

            migrationBuilder.RenameColumn(
                name: "optionId",
                table: "RoleAccess",
                newName: "LevelOptionId");

            migrationBuilder.AddColumn<string>(
                name: "LevelName",
                table: "RoleAccess",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LevelName",
                table: "RoleAccess");

            migrationBuilder.RenameColumn(
                name: "LevelOptionId",
                table: "RoleAccess",
                newName: "optionId");

            migrationBuilder.AddColumn<int>(
                name: "ChildSubcategorId",
                table: "RoleAccess",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubcategoryId",
                table: "RoleAccess",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
