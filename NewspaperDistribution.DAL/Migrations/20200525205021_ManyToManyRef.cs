using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewspaperDistribution.DAL.Migrations
{
    public partial class ManyToManyRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Newspapers_PostalOffices_PostalOfficeId",
                table: "Newspapers");

            migrationBuilder.DropForeignKey(
                name: "FK_Newspapers_PrintingHouses_PrintingHouseId",
                table: "Newspapers");

            migrationBuilder.DropIndex(
                name: "IX_Newspapers_PostalOfficeId",
                table: "Newspapers");

            migrationBuilder.DropIndex(
                name: "IX_Newspapers_PrintingHouseId",
                table: "Newspapers");

            migrationBuilder.DropColumn(
                name: "PostalOfficeId",
                table: "Newspapers");

            migrationBuilder.DropColumn(
                name: "PrintingHouseId",
                table: "Newspapers");

            migrationBuilder.CreateTable(
                name: "NewspaperPostalOfficeRelation",
                columns: table => new
                {
                    NewspaperPostalOfficeRelationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NewspaperId = table.Column<int>(nullable: false),
                    PostOfficeId = table.Column<int>(nullable: false),
                    PostalOfficeModelPostalOfficeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewspaperPostalOfficeRelation", x => x.NewspaperPostalOfficeRelationId);
                    table.ForeignKey(
                        name: "FK_NewspaperPostalOfficeRelation_Newspapers_NewspaperId",
                        column: x => x.NewspaperId,
                        principalTable: "Newspapers",
                        principalColumn: "NewspaperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewspaperPostalOfficeRelation_PostalOffices_PostalOfficeModelPostalOfficeId",
                        column: x => x.PostalOfficeModelPostalOfficeId,
                        principalTable: "PostalOffices",
                        principalColumn: "PostalOfficeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NewspaperPrintingHouseRelation",
                columns: table => new
                {
                    NewspaperPrintingHouseRelationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NewspaperId = table.Column<int>(nullable: false),
                    PrintingHouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewspaperPrintingHouseRelation", x => x.NewspaperPrintingHouseRelationId);
                    table.ForeignKey(
                        name: "FK_NewspaperPrintingHouseRelation_Newspapers_NewspaperId",
                        column: x => x.NewspaperId,
                        principalTable: "Newspapers",
                        principalColumn: "NewspaperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewspaperPrintingHouseRelation_PrintingHouses_PrintingHouseId",
                        column: x => x.PrintingHouseId,
                        principalTable: "PrintingHouses",
                        principalColumn: "PrintingHouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewspaperPostalOfficeRelation_NewspaperId",
                table: "NewspaperPostalOfficeRelation",
                column: "NewspaperId");

            migrationBuilder.CreateIndex(
                name: "IX_NewspaperPostalOfficeRelation_PostalOfficeModelPostalOfficeId",
                table: "NewspaperPostalOfficeRelation",
                column: "PostalOfficeModelPostalOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_NewspaperPrintingHouseRelation_NewspaperId",
                table: "NewspaperPrintingHouseRelation",
                column: "NewspaperId");

            migrationBuilder.CreateIndex(
                name: "IX_NewspaperPrintingHouseRelation_PrintingHouseId",
                table: "NewspaperPrintingHouseRelation",
                column: "PrintingHouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewspaperPostalOfficeRelation");

            migrationBuilder.DropTable(
                name: "NewspaperPrintingHouseRelation");

            migrationBuilder.AddColumn<int>(
                name: "PostalOfficeId",
                table: "Newspapers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrintingHouseId",
                table: "Newspapers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Newspapers_PostalOfficeId",
                table: "Newspapers",
                column: "PostalOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Newspapers_PrintingHouseId",
                table: "Newspapers",
                column: "PrintingHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Newspapers_PostalOffices_PostalOfficeId",
                table: "Newspapers",
                column: "PostalOfficeId",
                principalTable: "PostalOffices",
                principalColumn: "PostalOfficeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Newspapers_PrintingHouses_PrintingHouseId",
                table: "Newspapers",
                column: "PrintingHouseId",
                principalTable: "PrintingHouses",
                principalColumn: "PrintingHouseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
