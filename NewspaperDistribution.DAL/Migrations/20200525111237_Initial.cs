using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewspaperDistribution.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostalOffices",
                columns: table => new
                {
                    PostalOfficeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OfficeNumber = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalOffices", x => x.PostalOfficeId);
                });

            migrationBuilder.CreateTable(
                name: "PrintingHouses",
                columns: table => new
                {
                    PrintingHouseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    MaxCirculation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintingHouses", x => x.PrintingHouseId);
                });

            migrationBuilder.CreateTable(
                name: "Newspapers",
                columns: table => new
                {
                    NewspaperId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    SubscriptionPrice = table.Column<decimal>(nullable: false),
                    PrintingHouseId = table.Column<int>(nullable: false),
                    PostalOfficeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newspapers", x => x.NewspaperId);
                    table.ForeignKey(
                        name: "FK_Newspapers_PostalOffices_PostalOfficeId",
                        column: x => x.PostalOfficeId,
                        principalTable: "PostalOffices",
                        principalColumn: "PostalOfficeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Newspapers_PrintingHouses_PrintingHouseId",
                        column: x => x.PrintingHouseId,
                        principalTable: "PrintingHouses",
                        principalColumn: "PrintingHouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Newspapers_PostalOfficeId",
                table: "Newspapers",
                column: "PostalOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Newspapers_PrintingHouseId",
                table: "Newspapers",
                column: "PrintingHouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Newspapers");

            migrationBuilder.DropTable(
                name: "PostalOffices");

            migrationBuilder.DropTable(
                name: "PrintingHouses");
        }
    }
}
