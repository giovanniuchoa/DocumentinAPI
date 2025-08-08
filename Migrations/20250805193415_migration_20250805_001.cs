using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentinAPI.Migrations
{
    /// <inheritdoc />
    public partial class migration_20250805_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ValidatorId",
                table: "Folders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "Documents",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DocumentValidations",
                columns: table => new
                {
                    DocumentValidationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    FolderId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentValidations", x => x.DocumentValidationId);
                    table.ForeignKey(
                        name: "FK_DocumentValidations_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                    table.ForeignKey(
                        name: "FK_DocumentValidations_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "FolderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folders_ValidatorId",
                table: "Folders",
                column: "ValidatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentValidations_DocumentId",
                table: "DocumentValidations",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentValidations_FolderId",
                table: "DocumentValidations",
                column: "FolderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Users_ValidatorId",
                table: "Folders",
                column: "ValidatorId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Users_ValidatorId",
                table: "Folders");

            migrationBuilder.DropTable(
                name: "DocumentValidations");

            migrationBuilder.DropIndex(
                name: "IX_Folders_ValidatorId",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "ValidatorId",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "Documents");
        }
    }
}
