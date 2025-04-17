using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentinAPI.Migrations
{
    /// <inheritdoc />
    public partial class migration_20250417_004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsValidated",
                table: "PasswordRecoveries",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsValidated",
                table: "PasswordRecoveries");
        }
    }
}
