using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Data.Migrations.Application
{
    public partial class InitialApplicationDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForumCategories",
                columns: table => new
                {
                    CreatedById = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedById = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    ForumCategoryTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ForumSubCategories",
                columns: table => new
                {
                    CreatedById = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedById = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    SubCategoryId = table.Column<Guid>(nullable: false),
                    ForumSubCategoryTitle = table.Column<string>(nullable: true),
                    ForumCategoryCategoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumSubCategories", x => x.SubCategoryId);
                    table.ForeignKey(
                        name: "FK_ForumSubCategories_ForumCategories_ForumCategoryCategoryId",
                        column: x => x.ForumCategoryCategoryId,
                        principalTable: "ForumCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ForumTopics",
                columns: table => new
                {
                    CreatedById = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedById = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TopicId = table.Column<Guid>(nullable: false),
                    TopicTitle = table.Column<string>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false),
                    ForumSubCategorySubCategoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumTopics", x => x.TopicId);
                    table.ForeignKey(
                        name: "FK_ForumTopics_ForumCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ForumCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForumTopics_ForumSubCategories_ForumSubCategorySubCategoryId",
                        column: x => x.ForumSubCategorySubCategoryId,
                        principalTable: "ForumSubCategories",
                        principalColumn: "SubCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ForumPosts",
                columns: table => new
                {
                    CreatedById = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedById = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PostId = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    TopicId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumPosts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_ForumPosts_ForumTopics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "ForumTopics",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumPosts_TopicId",
                table: "ForumPosts",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumSubCategories_ForumCategoryCategoryId",
                table: "ForumSubCategories",
                column: "ForumCategoryCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumTopics_CategoryId",
                table: "ForumTopics",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumTopics_ForumSubCategorySubCategoryId",
                table: "ForumTopics",
                column: "ForumSubCategorySubCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForumPosts");

            migrationBuilder.DropTable(
                name: "ForumTopics");

            migrationBuilder.DropTable(
                name: "ForumSubCategories");

            migrationBuilder.DropTable(
                name: "ForumCategories");
        }
    }
}
