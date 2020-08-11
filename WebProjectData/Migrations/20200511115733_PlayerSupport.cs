using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProjectData.Migrations
{
    public partial class PlayerSupport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerSupports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Account = table.Column<int>(nullable: false),
                    InGame = table.Column<int>(nullable: false),
                    Technical = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSupports", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerSupports");
        }
    }
}
