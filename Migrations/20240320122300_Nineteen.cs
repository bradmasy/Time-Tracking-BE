using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appapi.Migrations
{
    /// <inheritdoc />
    public partial class Nineteen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReconciledProjectDepartment_ProjectDepartments_ProjectDepart~",
                table: "ReconciledProjectDepartment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReconciledProjectDepartment",
                table: "ReconciledProjectDepartment");

            migrationBuilder.RenameTable(
                name: "ReconciledProjectDepartment",
                newName: "ReconciledProjectDepartments");

            migrationBuilder.RenameIndex(
                name: "IX_ReconciledProjectDepartment_ProjectDepartmentId",
                table: "ReconciledProjectDepartments",
                newName: "IX_ReconciledProjectDepartments_ProjectDepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReconciledProjectDepartments",
                table: "ReconciledProjectDepartments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReconciledProjectDepartments_ProjectDepartments_ProjectDepar~",
                table: "ReconciledProjectDepartments",
                column: "ProjectDepartmentId",
                principalTable: "ProjectDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReconciledProjectDepartments_ProjectDepartments_ProjectDepar~",
                table: "ReconciledProjectDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReconciledProjectDepartments",
                table: "ReconciledProjectDepartments");

            migrationBuilder.RenameTable(
                name: "ReconciledProjectDepartments",
                newName: "ReconciledProjectDepartment");

            migrationBuilder.RenameIndex(
                name: "IX_ReconciledProjectDepartments_ProjectDepartmentId",
                table: "ReconciledProjectDepartment",
                newName: "IX_ReconciledProjectDepartment_ProjectDepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReconciledProjectDepartment",
                table: "ReconciledProjectDepartment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReconciledProjectDepartment_ProjectDepartments_ProjectDepart~",
                table: "ReconciledProjectDepartment",
                column: "ProjectDepartmentId",
                principalTable: "ProjectDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
