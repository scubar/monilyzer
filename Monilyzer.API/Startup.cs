using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Monilyzer.API.Filters;
using Monilyzer.Data;
using Newtonsoft.Json.Serialization;

namespace Monilyzer.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure Database Context
            services.AddDbContext<MonilyzerContext>(options =>
                                                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Configure MVC
            // Assign Custom Exception Filter
            services.AddMvc(config => { config.Filters.Add(typeof(CustomExceptionFilter)); })
                    // Configure JSON Resolver
                    .AddJsonOptions( opt => {var resolver = opt.SerializerSettings.ContractResolver;
                if (resolver != null)
                {
                    var res = resolver as DefaultContractResolver;
                    res.NamingStrategy = null;
                }
            });

            // Configure Authentication
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })
            .AddJwtBearer("JwtBearer", jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SymmetricSecurityKey"])),
                    ValidateIssuer = true,
                    ValidIssuer = "monilyzer.api",
                    ValidateAudience = true,
                    ValidAudience = "monilyzer.api clients",
                    ValidateLifetime = true, 
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });

            services.AddSingleton<IConfiguration>(Configuration); 
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication(); 

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
