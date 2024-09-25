using CCD_SHARE2TEACH.Models;
using Microsoft.EntityFrameworkCore;

namespace CCD_SHARE2TEACH.Models
{
    public class RolesDbContext : DbContext
    {
        public RolesDbContext(DbContextOptions<RolesDbContext> options) : base(options)
        {

        }
        public DbSet<ROLES> ROLES { get; set; } = null!;
    }

}