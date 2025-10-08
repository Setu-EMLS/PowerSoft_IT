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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Tbl_Users { get; set; }
        public DbSet<Roles> tbl_roles { get; set; }
        public DbSet<Information> Information { get; set; }
        public DbSet<SMLinks> SMLinks { get; set; }

		//=======================Hero====================//
		public DbSet<HomeHero> HomeHero { get; set; }
		public DbSet<AboutUsHero> AboutUsHero { get; set; }
		public DbSet<ServiceHero> ServiceHero { get; set; }
		public DbSet<ProductHero> ProductHero { get; set; }
		public DbSet<FeedbackHero> FeedbackHero { get; set; }
		public DbSet<ContactHero> ContactHero { get; set; }


		//=======================Home====================//
		public DbSet<Home> Homes { get; set; }
		public DbSet<HeaderNav> HeaderNavs { get; set; }
		public DbSet<HeaderNavChild> HeaderNavChilds { get; set; }
		public DbSet<Slider> Sliders { get; set; }
		public DbSet<SliderBtn> SliderBtns { get; set; }
		public DbSet<FooterNav> FooterNavs { get; set; }
		public DbSet<FooterNavChild> FooterNavChilds { get; set; }


		//=================Popups================//
		public DbSet<Popup> Popups { get; set; }
		public DbSet<SitePopup> SitePopups { get; set; }


		//=====================AboutUs====================//
		public DbSet<AboutUs> AboutUs { get; set; }
		public DbSet<Counter> Counters { get; set; }
		public DbSet<Mission> Missions { get; set; }
		public DbSet<Vision> Visions { get; set; }
		public DbSet<WhyITBest> WhyITBest { get; set; }
		public DbSet<Career> Careers { get; set; }


		//=====================Course====================//
		public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCategory> CourseCategorys { get; set; }
        public DbSet<BoosterCategories> BoosterCategories { get; set; }


		//=====================Product====================//
		public DbSet<Product> Products { get; set; }
		public DbSet<WhyChooseOurProduct> WhyChooseOurProduct { get; set; }


		//=====================Payment====================//
		public DbSet<Payment> Payments { get; set; }
		public DbSet<PaymentGetway> PaymentGetways { get; set; }


		//=====================Seminar====================//
		public DbSet<Seminar> Seminars { get; set; }
		public DbSet<SeminarCategory> SeminarCategorys { get; set; }


		//=====================Service====================//
		public DbSet<Service> Services { get; set; }
		public DbSet<FAQ> FAQs { get; set; }


		//=====================Student====================//
		public DbSet<Student> Students { get; set; }
		public DbSet<StudentFeedback> StudentFeedbacks { get; set; }

		//=====================Teacher====================//
		public DbSet<Teacher> Teachers { get; set; }
	}
}