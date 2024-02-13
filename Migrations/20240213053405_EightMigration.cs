using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appapi.Migrations
{
    /// <inheritdoc />
    public partial class EightMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Company_CompanyId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectDepartment_Department_DepartmentId",
                table: "ProjectDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectDepartment_Projects_ProjectId",
                table: "ProjectDepartment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectDepartment",
                table: "ProjectDepartment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "ProjectDepartment",
                newName: "ProjectDepartments");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectDepartment_ProjectId",
                table: "ProjectDepartments",
                newName: "IX_ProjectDepartments_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectDepartment_DepartmentId",
                table: "ProjectDepartments",
                newName: "IX_ProjectDepartments_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Department_CompanyId",
                table: "Departments",
                newName: "IX_Departments_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectDepartments",
                table: "ProjectDepartments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailAddress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Companies_CompanyId",
                table: "Departments",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDepartments_Departments_DepartmentId",
                table: "ProjectDepartments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDepartments_Projects_ProjectId",
                table: "ProjectDepartments",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Companies_CompanyId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectDepartments_Departments_DepartmentId",
                table: "ProjectDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectDepartments_Projects_ProjectId",
                table: "ProjectDepartments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectDepartments",
                table: "ProjectDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "ProjectDepartments",
                newName: "ProjectDepartment");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectDepartments_ProjectId",
                table: "ProjectDepartment",
                newName: "IX_ProjectDepartment_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectDepartments_DepartmentId",
                table: "ProjectDepartment",
                newName: "IX_ProjectDepartment_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_CompanyId",
                table: "Department",
                newName: "IX_Department_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectDepartment",
                table: "ProjectDepartment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Company_CompanyId",
                table: "Department",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDepartment_Department_DepartmentId",
                table: "ProjectDepartment",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDepartment_Projects_ProjectId",
                table: "ProjectDepartment",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
