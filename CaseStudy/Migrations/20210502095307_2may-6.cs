using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseStudy.Migrations
{
    public partial class _2may6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Companies_CompanyId",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Jobs",
                newName: "CurrentCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_CompanyId",
                table: "Jobs",
                newName: "IX_Jobs_CurrentCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Companies_CurrentCompanyId",
                table: "Jobs",
                column: "CurrentCompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Companies_CurrentCompanyId",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "CurrentCompanyId",
                table: "Jobs",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_CurrentCompanyId",
                table: "Jobs",
                newName: "IX_Jobs_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Companies_CompanyId",
                table: "Jobs",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
