using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseStudy.Migrations
{
    public partial class _2may : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Companies_CompanyEntityCompanyId",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "CompanyEntityCompanyId",
                table: "Jobs",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_CompanyEntityCompanyId",
                table: "Jobs",
                newName: "IX_Jobs_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Companies_CompanyId",
                table: "Jobs",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Companies_CompanyId",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Jobs",
                newName: "CompanyEntityCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_CompanyId",
                table: "Jobs",
                newName: "IX_Jobs_CompanyEntityCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Companies_CompanyEntityCompanyId",
                table: "Jobs",
                column: "CompanyEntityCompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
