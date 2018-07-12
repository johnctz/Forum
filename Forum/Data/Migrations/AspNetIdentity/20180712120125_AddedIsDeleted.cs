using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Data.Migrations.AspNetIdentity
{
    public partial class AddedIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ForumTopics",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ForumSubCategories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ForumPosts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ForumCategories",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ForumTopics");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ForumSubCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ForumPosts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ForumCategories");
        }
    }
}
