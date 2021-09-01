using Microsoft.EntityFrameworkCore.Migrations;

namespace API.DataLayer.Migrations
{
    public partial class AddTagToTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "LearningTasks",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag",
                table: "LearningTasks");
        }
    }
}
