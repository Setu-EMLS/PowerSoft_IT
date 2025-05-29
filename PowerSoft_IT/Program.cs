using Microsoft.EntityFrameworkCore;
using PowerSoft_IT.Models;
using PowerSoft_IT.Services.Implementations;
using PowerSoft_IT.Services.Interfaces;

namespace PowerSoft_IT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddHttpContextAccessor(); // ✅ IHttpContextAccessor registration

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IIdentityService, IdentityService>();

            builder.Services.AddAuthentication("MyCookieAuth")
                .AddCookie("MyCookieAuth", options =>
                {
                    options.LoginPath = "/Home/Login";
                    options.LogoutPath = "/Home/Logout";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // ✅ Serve static files

            app.UseRouting();

            app.UseAuthentication(); // ✅ Authentication middleware
            app.UseAuthorization();

            // Optional static assets extensions, if they exist
            app.MapStaticAssets(); // make sure this method exists
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            ).WithStaticAssets(); // make sure this extension is defined

            app.Run();
        }
    }
}
