using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PF.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class activityrefactored : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportType",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Reports");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Activities",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Activities");

            migrationBuilder.AddColumn<int>(
                name: "ReportType",
                table: "Reports",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Reports",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
