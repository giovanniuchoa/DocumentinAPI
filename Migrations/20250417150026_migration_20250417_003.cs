using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentinAPI.Migrations
{
    /// <inheritdoc />
    public partial class migration_20250417_003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Companies_TaxId",
                table: "Companies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_TaxId",
                table: "Companies",
                column: "TaxId",
                unique: true);
        }
    }
}
