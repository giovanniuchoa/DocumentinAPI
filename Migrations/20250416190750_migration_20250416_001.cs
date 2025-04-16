using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentinAPI.Migrations
{
    /// <inheritdoc />
    public partial class migration_20250416_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Companies_CompanyId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CompanyId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Groups");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CompanyId",
                table: "Groups",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Companies_CompanyId",
                table: "Groups",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId");
        }
    }
}
