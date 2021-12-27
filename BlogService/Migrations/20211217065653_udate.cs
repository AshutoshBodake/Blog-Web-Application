using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogService.Migrations
{
    public partial class udate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogName",
                table: "BlogCategories",
                newName: "Category");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "BlogCategories",
                newName: "BlogName");
        }
    }
}
