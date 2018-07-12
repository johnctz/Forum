using Forum.Entities;
using Forum.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IUserInfoService _userInfoService;
        public ApplicationDbContext(
                IUserInfoService userInfoService, 
                DbContextOptions<ApplicationDbContext> options
            ) : base(options)
        {
            _userInfoService = userInfoService;
        }

        public DbSet<ForumCategory> ForumCategories { get; set; }
        public DbSet<ForumSubCategory> ForumSubCategories { get; set; }
        public DbSet<ForumTopic> ForumTopics { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // get added or updated entries
            var addedOrUpdatedEntries = ChangeTracker.Entries()
                    .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));

            // fill out the audit fields
            foreach (var entry in addedOrUpdatedEntries)
            {
                var entity = entry.Entity as AuditableEntity;


                if (entry.State == EntityState.Added)
                {
                    entity.CreatedById = _userInfoService.UserId;
                    entity.CreatedOn = DateTimeOffset.UtcNow;
                }

                entity.UpdatedById = _userInfoService.UserId;
                entity.UpdatedOn = DateTimeOffset.UtcNow;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
