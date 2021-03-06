﻿// <auto-generated />
using System;
using Forum.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Forum.Data.Migrations.Application
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180712140736_InitialApplicationDbContext")]
    partial class InitialApplicationDbContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Forum.Entities.ForumCategory", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedById");

                    b.Property<DateTimeOffset>("CreatedOn");

                    b.Property<string>("ForumCategoryTitle");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("UpdatedById");

                    b.Property<DateTimeOffset>("UpdatedOn");

                    b.HasKey("CategoryId");

                    b.ToTable("ForumCategories");
                });

            modelBuilder.Entity("Forum.Entities.ForumPost", b =>
                {
                    b.Property<Guid>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<string>("CreatedById");

                    b.Property<DateTimeOffset>("CreatedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid>("TopicId");

                    b.Property<string>("UpdatedById");

                    b.Property<DateTimeOffset>("UpdatedOn");

                    b.HasKey("PostId");

                    b.HasIndex("TopicId");

                    b.ToTable("ForumPosts");
                });

            modelBuilder.Entity("Forum.Entities.ForumSubCategory", b =>
                {
                    b.Property<Guid>("SubCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedById");

                    b.Property<DateTimeOffset>("CreatedOn");

                    b.Property<Guid?>("ForumCategoryCategoryId");

                    b.Property<string>("ForumSubCategoryTitle");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("UpdatedById");

                    b.Property<DateTimeOffset>("UpdatedOn");

                    b.HasKey("SubCategoryId");

                    b.HasIndex("ForumCategoryCategoryId");

                    b.ToTable("ForumSubCategories");
                });

            modelBuilder.Entity("Forum.Entities.ForumTopic", b =>
                {
                    b.Property<Guid>("TopicId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<string>("CreatedById");

                    b.Property<DateTimeOffset>("CreatedOn");

                    b.Property<Guid?>("ForumSubCategorySubCategoryId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("TopicTitle");

                    b.Property<string>("UpdatedById");

                    b.Property<DateTimeOffset>("UpdatedOn");

                    b.HasKey("TopicId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ForumSubCategorySubCategoryId");

                    b.ToTable("ForumTopics");
                });

            modelBuilder.Entity("Forum.Entities.ForumPost", b =>
                {
                    b.HasOne("Forum.Entities.ForumTopic", "ForumTopic")
                        .WithMany("ForumPosts")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Forum.Entities.ForumSubCategory", b =>
                {
                    b.HasOne("Forum.Entities.ForumCategory")
                        .WithMany("ForumSubCategories")
                        .HasForeignKey("ForumCategoryCategoryId");
                });

            modelBuilder.Entity("Forum.Entities.ForumTopic", b =>
                {
                    b.HasOne("Forum.Entities.ForumCategory", "ForumCategory")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Forum.Entities.ForumSubCategory")
                        .WithMany("ForumTopics")
                        .HasForeignKey("ForumSubCategorySubCategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
