using AutoMapper;
using DotNetCore.Domain.Domain;
using eService.API.Logging;
using eService.API.Services;
using eService.Common;
using eService.Common.Constants;
using eService.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApp
{
    public class Startup
    {
        private readonly NLog.ILogger _Nlogger;
        public IWebHostEnvironment HostingEnvironment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
            _Nlogger = LogManager.GetCurrentClassLogger();
        }

        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";//"_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();


            services.AddConnections();
            var tokenKey = "";

            var appSettings = new AppSettings();
            Configuration.GetSection("ApplicationSettings").Bind(appSettings);


            services.Configure<AppEnvSettings>(this.Configuration.GetSection("ApplicationSettings"));

            var ApplicationUrl = Configuration.GetValue<string>("ApplicationSettings:ApplicationUrl");  
            var ClientUrl = Configuration.GetValue<string>("ApplicationSettings:ClientUrl");

            services.AddTransient<TokenManagerMiddleware>();
            services.AddTransient<ITokenManager, eService.API.Services.TokenManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddSingleton<IJwtAuthenticationManager>(new JwtAuthenticationManager(tokenKey));

            RegisterDependency(services);

        }

        

        private void RegisterDependency(IServiceCollection services)
        {
            var appSettings = new AppSettings();
            Configuration.GetSection("ApplicationSettings").Bind(appSettings);
            var connection = Configuration.GetSection("dbConnectionString");
            services.AddSingleton(appSettings);
            services.AddSingleton<IWebHostEnvironment>(HostingEnvironment);

            services.AddSingleton<ILoggerManager, LoggerManager>();

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            var refactory = new RepositoryFactory(appSettings);
            services.AddSingleton(refactory);
            services.AddHttpContextAccessor();


            AppConstants.SetUtilityConfiguration(appSettings);
            //register dependency
            //services.AddScoped<ILookUpRespository, LookUpRespository>();          

            //services.AddScoped<IFlsWorkPermitRepository, FlsWorkPermitRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseIpRateLimiting();

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 && !System.IO.Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseCors(options =>

               options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<TokenManagerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllers()
                    .RequireCors(MyAllowSpecificOrigins);
            });
        }
    }
}
