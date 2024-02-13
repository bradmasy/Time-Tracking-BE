using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appapi.Migrations
{
    /// <inheritdoc />
    public partial class SeventhMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Projects_ProjectId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_ProjectId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Department");

            migrationBuilder.CreateTable(
                name: "ProjectDepartment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProjectId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DepartmentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectDepartment_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectDepartment_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDepartment_DepartmentId",
                table: "ProjectDepartment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDepartment_ProjectId",
                table: "ProjectDepartment",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectDepartment");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Department",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Department_ProjectId",
                table: "Department",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Projects_ProjectId",
                table: "Department",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
