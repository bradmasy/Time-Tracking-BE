using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appapi.Migrations
{
    /// <inheritdoc />
    public partial class Eighteen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReconciledProjectDepartment_Projects_ProjectId",
                table: "ReconciledProjectDepartment");

            migrationBuilder.DropIndex(
                name: "IX_ReconciledProjectDepartment_ProjectId",
                table: "ReconciledProjectDepartment");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ReconciledProjectDepartment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "ReconciledProjectDepartment",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_ReconciledProjectDepartment_ProjectId",
                table: "ReconciledProjectDepartment",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReconciledProjectDepartment_Projects_ProjectId",
                table: "ReconciledProjectDepartment",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
