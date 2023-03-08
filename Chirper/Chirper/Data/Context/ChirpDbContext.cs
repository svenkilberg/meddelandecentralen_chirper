using Chirper.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Chirper.Data.Context
{
    public class ChirpDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ChirpDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Chirp> Chirps { get; set; }
    }
}
