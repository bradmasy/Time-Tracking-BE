using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appapi.Migrations
{
    /// <inheritdoc />
    public partial class ThirteenthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "ProjectDepartments");

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "ProjectDepartments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
