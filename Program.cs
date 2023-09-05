using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ITIProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddTransient<IOperationTransient, Operation>();
            //builder.Services.AddScoped<IOperationScoped, Operation>();
            //builder.Services.AddSingleton<IOperationSingleton, Operation>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }


        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //Host.CreateDefaultBuilder(args)
        //    .ConfigureWebHostDefaults(webBuilder =>
        //    {
        //        webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
        //        {
        //            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //            config.AddEnvironmentVariables();
        //        });

        //        webBuilder.ConfigureServices((hostingContext, services) =>
        //        {
        //            // Services setup

        //            services.AddControllersWithViews();
        //            services.AddTransient<IService, MyService>();
        //        });
        //    });
    }

}

