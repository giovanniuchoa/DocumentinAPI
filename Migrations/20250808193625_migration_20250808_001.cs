using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentinAPI.Migrations
{
    /// <inheritdoc />
    public partial class migration_20250808_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "DocumentValidations",
                type: "varchar(500)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "DocumentValidations");
        }
    }
}
