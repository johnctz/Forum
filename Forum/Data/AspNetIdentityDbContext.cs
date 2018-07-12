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
    public class AspNetIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public AspNetIdentityDbContext(
                DbContextOptions<AspNetIdentityDbContext> options
            )
            : base(options)
        {
        }

    }
}
