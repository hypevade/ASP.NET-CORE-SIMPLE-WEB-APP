using Instahach.Domain;
using Instahach.Services;
using Microsoft.EntityFrameworkCore;

namespace Instahach;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddTransient<IImageService, ImageService>();
        services.AddTransient<IUserService, UserService>();
        services.AddControllers();
        services.AddControllersWithViews();
        
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(Configuration["DefaultConnection"]));

        /*services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();*/

        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = "YourAppNameAuthCookie";
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Account/AccessDenied";
            options.SlidingExpiration = true;
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseStatusCodePages();
        app.UseStaticFiles();
        
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=ImageControllers}");
        });
        

        /*string externalFolderPath = @"F:\images"; // Укажите путь к папке с файлами
        string externalUrlPath = "/external-files"; // Укажите URL-путь для виртуальной директории

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(externalFolderPath),
            RequestPath = externalUrlPath,
            ServeUnknownFileTypes = true // Если вы хотите обслуживать неизвестные типы файлов
        });*/
        
        
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            
        }
    }
}