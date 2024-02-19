using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appapi.Migrations
{
    /// <inheritdoc />
    public partial class EleventhMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Actuals",
                table: "ProjectDepartments",
                type: "double",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Forecast",
                table: "ProjectDepartments",
                type: "double",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actuals",
                table: "ProjectDepartments");

            migrationBuilder.DropColumn(
                name: "Forecast",
                table: "ProjectDepartments");
        }
    }
}
