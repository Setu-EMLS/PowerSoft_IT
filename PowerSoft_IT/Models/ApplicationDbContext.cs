using PowerSoft_IT.Models;
using Microsoft.EntityFrameworkCore;

namespace PowerSoft_IT.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Tbl_Users { get; set; }
        public DbSet<Roles> tbl_roles { get; set; }
        public DbSet<Information> Information { get; set; }
        public DbSet<SMLinks> SMLinks { get; set; }
    }
}