using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using NixMdm.Data;
using Google.Apis.Auth.AspNetCore3;
    
namespace NixMdm
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env; 
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        static readonly string _RequireAuthenticatedUserPolicy = 
                            "RequireAuthenticatedUserPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<MDMContext>(options => 
            {
                if(Environment.IsDevelopment())
                    options.UseSqlite(Configuration.GetConnectionString("MDMContext"));
                else
                    options.UseSqlServer(Configuration.GetConnectionString("MDMContext"));
            });

            services.AddDefaultIdentity<IdentityUser>()
            .AddEntityFrameworkStores<MDMContext>()
            .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(_RequireAuthenticatedUserPolicy, builder => builder.RequireAuthenticatedUser());
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Pages/Account/Login";
                options.AccessDeniedPath = "/Identity/Pages/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            // Register the Swagger Generator
            services.AddSwaggerGen();

            // This configures Google.Apis.Auth.AspNetCore3 for use in this app.
            services
                .AddAuthentication(o =>
                {
                    // This forces challenge results to be handled by Google OpenID Handler, so there's no
                    // need to add an AccountController that emits challenges for Login.
                    o.DefaultChallengeScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
                    // This forces forbid results to be handled by Google OpenID Handler, which checks if
                    // extra scopes are required and does automatic incremental auth.
                    o.DefaultForbidScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
                    // Default scheme that will handle everything else.
                    // Once a user is authenticated, the OAuth2 token info is stored in cookies.
                    o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie()
                .AddGoogleOpenIdConnect(options =>
                {
                    ClientInfo client = ClientInfo.Load();
                    options.ClientId = client.ClientId;
                    options.ClientSecret = client.ClientSecret;                                  
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(ops =>
            {
                ops.SwaggerEndpoint("/swagger/v1/swagger.json", "NixMDMAPI V1");
            });

            app.UseEndpoints(endpoints =>
            {
                 endpoints.MapControllerRoute("default", "{controller=Device}/{action=Index}/{id?}");
                 endpoints.MapRazorPages();
                //endpoints.MapDefaultControllerRoute();
            });            
        }
    }
}
