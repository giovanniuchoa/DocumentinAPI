using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentinAPI.Migrations
{
    /// <inheritdoc />
    public partial class migration_20250814_002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "DocumentXTags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentXTags_UserId",
                table: "DocumentXTags",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentXTags_Users_UserId",
                table: "DocumentXTags",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentXTags_Users_UserId",
                table: "DocumentXTags");

            migrationBuilder.DropIndex(
                name: "IX_DocumentXTags_UserId",
                table: "DocumentXTags");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DocumentXTags");
        }
    }
}
