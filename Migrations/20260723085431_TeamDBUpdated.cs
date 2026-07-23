using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class TeamDBUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Teams_CreatedById",
                table: "Teams",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_UpdatedById",
                table: "Teams",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_CreatedById",
                table: "Teams",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_UpdatedById",
                table: "Teams",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_CreatedById",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_UpdatedById",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CreatedById",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_UpdatedById",
                table: "Teams");
        }
    }
}
