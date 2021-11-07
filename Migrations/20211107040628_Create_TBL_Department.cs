using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppCore.Migrations
{
    public partial class Create_TBL_Department : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepId",
                table: "TBL_User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TBL_Department",
                columns: table => new
                {
                    DepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Department", x => x.DepId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_User_DepId",
                table: "TBL_User",
                column: "DepId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_User_TBL_Department_DepId",
                table: "TBL_User",
                column: "DepId",
                principalTable: "TBL_Department",
                principalColumn: "DepId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_User_TBL_Department_DepId",
                table: "TBL_User");

            migrationBuilder.DropTable(
                name: "TBL_Department");

            migrationBuilder.DropIndex(
                name: "IX_TBL_User_DepId",
                table: "TBL_User");

            migrationBuilder.DropColumn(
                name: "DepId",
                table: "TBL_User");
        }
    }
}
