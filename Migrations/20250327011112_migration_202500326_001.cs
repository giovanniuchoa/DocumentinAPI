using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentinAPI.Migrations
{
    /// <inheritdoc />
    public partial class migration_202500326_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Folders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Folders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CompanyId",
                table: "Groups",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_UserId",
                table: "Groups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_CompanyId",
                table: "Folders",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_UserId",
                table: "Folders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Company_CompanyId",
                table: "Folders",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Users_UserId",
                table: "Folders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Company_CompanyId",
                table: "Groups",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Users_UserId",
                table: "Groups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Company_CompanyId",
                table: "Users",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Company_CompanyId",
                table: "Folders");

            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Users_UserId",
                table: "Folders");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Company_CompanyId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_UserId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Company_CompanyId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompanyId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CompanyId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_UserId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Folders_CompanyId",
                table: "Folders");

            migrationBuilder.DropIndex(
                name: "IX_Folders_UserId",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Folders");
        }
    }
}
