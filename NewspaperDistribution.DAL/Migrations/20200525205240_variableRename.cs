using Microsoft.EntityFrameworkCore.Migrations;

namespace NewspaperDistribution.DAL.Migrations
{
    public partial class variableRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewspaperPostalOfficeRelation_PostalOffices_PostalOfficeModelPostalOfficeId",
                table: "NewspaperPostalOfficeRelation");

            migrationBuilder.DropIndex(
                name: "IX_NewspaperPostalOfficeRelation_PostalOfficeModelPostalOfficeId",
                table: "NewspaperPostalOfficeRelation");

            migrationBuilder.DropColumn(
                name: "PostalOfficeModelPostalOfficeId",
                table: "NewspaperPostalOfficeRelation");

            migrationBuilder.RenameColumn(
                name: "PostOfficeId",
                table: "NewspaperPostalOfficeRelation",
                newName: "PostalOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_NewspaperPostalOfficeRelation_PostalOfficeId",
                table: "NewspaperPostalOfficeRelation",
                column: "PostalOfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewspaperPostalOfficeRelation_PostalOffices_PostalOfficeId",
                table: "NewspaperPostalOfficeRelation",
                column: "PostalOfficeId",
                principalTable: "PostalOffices",
                principalColumn: "PostalOfficeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewspaperPostalOfficeRelation_PostalOffices_PostalOfficeId",
                table: "NewspaperPostalOfficeRelation");

            migrationBuilder.DropIndex(
                name: "IX_NewspaperPostalOfficeRelation_PostalOfficeId",
                table: "NewspaperPostalOfficeRelation");

            migrationBuilder.RenameColumn(
                name: "PostalOfficeId",
                table: "NewspaperPostalOfficeRelation",
                newName: "PostOfficeId");

            migrationBuilder.AddColumn<int>(
                name: "PostalOfficeModelPostalOfficeId",
                table: "NewspaperPostalOfficeRelation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewspaperPostalOfficeRelation_PostalOfficeModelPostalOfficeId",
                table: "NewspaperPostalOfficeRelation",
                column: "PostalOfficeModelPostalOfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewspaperPostalOfficeRelation_PostalOffices_PostalOfficeModelPostalOfficeId",
                table: "NewspaperPostalOfficeRelation",
                column: "PostalOfficeModelPostalOfficeId",
                principalTable: "PostalOffices",
                principalColumn: "PostalOfficeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
