using System.IO;
using GossipBoard.Database;
using GossipBoard.Models.Client;
using GossipBoard.Repositories;
using GossipBoard.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace GossipBoard
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c => c.SwaggerDoc("gossip_demo_application", new Info()));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 1;
                })
                .AddEntityFrameworkStores<DemoDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add framework services.
            services.AddScoped<IDemoService, CarsService>();
            services.AddScoped<ICarRepository, CarsRepository>();
            services.AddScoped<IMailService, DummyMailService>();
            services.AddScoped<IFileSaveService, FileSaveService>();
            services.AddScoped<ITextPostService, TextPostService>();
            services.AddScoped<ITextPostRepository, TextPostRepository>();
            services.AddScoped<IMediaPostService, MediaPostService>();
            services.AddScoped<IMediaPostRepository, MediaPostRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPollPostRepository, PollPostRepository>();
            services.AddScoped<IPollPostService, PollPostService>();
            services.AddEntityFrameworkSqlite().AddDbContext<DemoDbContext>(options => options.UseSqlite("Filename=./demo.db"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors("CorsPolicy");

            var imagesDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "images");
            Directory.CreateDirectory(imagesDirectoryPath);

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    imagesDirectoryPath),
                RequestPath = new PathString("/images")
            });

            app.UseIdentity();
            app.UseMvc();

            var dbContext = app.ApplicationServices.GetService<DemoDbContext>();
            dbContext.Database.EnsureCreated();

            var swaggerUrl = "/swagger/gossip_demo_application/swagger.json";
            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.DocExpansion("none");
                    c.SwaggerEndpoint(swaggerUrl, "Gossip Demo Application");
                });

        }
    }
}
