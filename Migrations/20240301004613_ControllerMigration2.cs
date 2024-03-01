using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace controller_api_v1.Migrations
{
    /// <inheritdoc />
    public partial class ControllerMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "Entities",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "Entities");
        }
    }
}
