using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace controller_api_v1.Migrations
{
    /// <inheritdoc />
    public partial class addIsActives : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Collaborators",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Collaborators");
        }
    }
}
