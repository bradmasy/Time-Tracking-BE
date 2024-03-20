using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appapi.Migrations
{
    /// <inheritdoc />
    public partial class Seventeen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReconciledProjectDepartment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectDepartmentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProjectId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Hours = table.Column<double>(type: "double", nullable: true),
                    Actuals = table.Column<double>(type: "double", nullable: true),
                    Forecast = table.Column<double>(type: "double", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReconciledProjectDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReconciledProjectDepartment_ProjectDepartments_ProjectDepart~",
                        column: x => x.ProjectDepartmentId,
                        principalTable: "ProjectDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReconciledProjectDepartment_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ReconciledProjectDepartment_ProjectDepartmentId",
                table: "ReconciledProjectDepartment",
                column: "ProjectDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReconciledProjectDepartment_ProjectId",
                table: "ReconciledProjectDepartment",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReconciledProjectDepartment");
        }
    }
}
