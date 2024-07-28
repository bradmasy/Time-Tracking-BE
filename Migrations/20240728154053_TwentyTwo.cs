using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appapi.Migrations
{
    /// <inheritdoc />
    public partial class TwentyTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "TimeBlocks",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "TimeBlocks");
        }
    }
}
