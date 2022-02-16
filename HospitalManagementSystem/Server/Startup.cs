using CloudinaryDotNet;
using HospitalManagementSystem.Server.Data;
using HospitalManagementSystem.Server.Models;
using HospitalManagementSystem.Server.Seeders;
using HospitalManagementSystem.Server.Services;
using HospitalManagementSystem.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            Account cloudinaryCredentials = new Account(
               this.Configuration["Cloudinary:CloudName"],
               this.Configuration["Cloudinary:ApiKey"],
               this.Configuration["Cloudinary:ApiSecret"]);

            Cloudinary cloudinaryUtility = new Cloudinary(cloudinaryCredentials);

            services.AddSingleton(cloudinaryUtility);

            services.AddTransient<UsersSeeder>();

            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<ITreatmentsService, TreatmentsService>();
            services.AddTransient<IRecipesService, RecipesService>();
            services.AddTransient<IPaymentsService, PaymentsService>();
            services.AddTransient<IDocumentationsService, DocumentationsService>();
            services.AddTransient<IBloodTypesService, BloodTypesService>();
            services.AddTransient<IMessagesService, MessagesService>();
            services.AddTransient<IAppointmentsService, AppointmentsService>();
            services.AddTransient<IBedsService, BedsService>();
            services.AddTransient<IFloorsService, FloorsService>();
            services.AddTransient<IMedicinesService, MedicinesService>();
            services.AddTransient<IBlogPostsService, BlogPostsService>();
            services.AddTransient<IBlogCategoriesService, BlogCategoriesService>();
            services.AddTransient<ITagsService, TagsService>();
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<ISmsService, SmsService>();
            services.AddTransient<IExportsService, ExportsService>();
            services.AddTransient<IExpensesService, ExpensesService>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UsersSeeder usersSeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseWebAssemblyDebugging();
                usersSeeder.SeedAsync().GetAwaiter().GetResult();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
