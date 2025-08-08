using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentinAPI.Migrations
{
    /// <inheritdoc />
    public partial class migration_20250807_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "DocumentValidations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentValidations_UserId",
                table: "DocumentValidations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentValidations_Users_UserId",
                table: "DocumentValidations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentValidations_Users_UserId",
                table: "DocumentValidations");

            migrationBuilder.DropIndex(
                name: "IX_DocumentValidations_UserId",
                table: "DocumentValidations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DocumentValidations");
        }
    }
}
