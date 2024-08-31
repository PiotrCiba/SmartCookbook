using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartCookbook.Data.Migrations
{
    /// <inheritdoc />
    public partial class Commentsusernames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Ratings",
                newName: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Ratings",
                newName: "UserId");
        }
    }
}
