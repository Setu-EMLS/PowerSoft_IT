using EMSLWebSite.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using PowerSoft_IT.Areas.Admin.Models;
using PowerSoft_IT.Areas.Student.Models;
using PowerSoft_IT.Areas.Teacher.Models;
using PowerSoft_IT.Models;

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
        //public DbSet<AboutUs> AboutUs { get; set; }
        //public DbSet<Career> Careers { get; set; }
        //public DbSet<Course> Courses { get; set; }
        //public DbSet<FAQ> FAQs { get; set; }
        //public DbSet<Hero> Heroes { get; set; }
        //public DbSet<Home> Homes { get; set; }
        //public DbSet<HeaderNav> HeaderNavs  { get; set; }
        //public DbSet<HeaderNavChild> HeaderNavChilds { get; set; }
        //public DbSet<FooterNav> FooterNavs { get; set; }
        //public DbSet<FooterNavChild> FooterNavChilds { get; set; }
        //public DbSet<HomePopup> HomePopups { get; set; }
        //public DbSet<SeminarCategory> SeminarCategorys { get; set; }
        //public DbSet<Seminar> Seminars { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }


    }
}