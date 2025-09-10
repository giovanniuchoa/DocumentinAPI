using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentinAPI.Migrations
{
    /// <inheritdoc />
    public partial class migration_20250823_002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OpenAIConfigs_CompanyId",
                table: "OpenAIConfigs",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_OpenAIConfigs_Companies_CompanyId",
                table: "OpenAIConfigs",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OpenAIConfigs_Companies_CompanyId",
                table: "OpenAIConfigs");

            migrationBuilder.DropIndex(
                name: "IX_OpenAIConfigs_CompanyId",
                table: "OpenAIConfigs");
        }
    }
}
