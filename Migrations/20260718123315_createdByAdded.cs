using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class createdByAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedById",
                table: "Users",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UpdatedById",
                table: "Users",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_CreatedById",
                table: "Users",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UpdatedById",
                table: "Users",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_CreatedById",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UpdatedById",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CreatedById",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UpdatedById",
                table: "Users");
        }
    }
}
