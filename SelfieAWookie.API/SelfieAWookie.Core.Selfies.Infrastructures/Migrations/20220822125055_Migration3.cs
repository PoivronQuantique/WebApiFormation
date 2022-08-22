using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SelfieAWookie.Core.Selfies.Infrastructures.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Selfie_Photo_PhotoId",
                table: "Selfie");

            migrationBuilder.DropForeignKey(
                name: "FK_Selfie_Wookie_WookieId",
                table: "Selfie");

            migrationBuilder.AddForeignKey(
                name: "FK_Selfie_Photo_PhotoId",
                table: "Selfie",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Selfie_Wookie_WookieId",
                table: "Selfie",
                column: "WookieId",
                principalTable: "Wookie",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Selfie_Photo_PhotoId",
                table: "Selfie");

            migrationBuilder.DropForeignKey(
                name: "FK_Selfie_Wookie_WookieId",
                table: "Selfie");

            migrationBuilder.AddForeignKey(
                name: "FK_Selfie_Photo_PhotoId",
                table: "Selfie",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Selfie_Wookie_WookieId",
                table: "Selfie",
                column: "WookieId",
                principalTable: "Wookie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
