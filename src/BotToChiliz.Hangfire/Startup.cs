using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotToChiliz.Hangfire.Jobs;
using Hangfire;
using Hangfire.Firebase;
using HangfireBasicAuthenticationFilter;

namespace BotToChiliz.Hangfire
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
            services.AddControllersWithViews();
            //var firebaseOptions = new FirebaseStorageOptions
            //{
            //    Queues = new[] { "default", "critical" },
            //    RequestTimeout = System.TimeSpan.FromSeconds(30),
            //    ExpirationCheckInterval = TimeSpan.FromMinutes(15),
            //    CountersAggregateInterval = TimeSpan.FromMinutes(1),
            //    QueuePollInterval = TimeSpan.FromSeconds(2)
            //};
            //services.AddHangfire(c => c.UseFirebaseStorage(FIREBASE_URL, FIREBASE_SECRET,firebaseOptions));
            //var firebaseStorage = new FirebaseStorage(FIREBASE_URL, FIREBASE_SECRET, firebaseOptions);
            //GlobalConfiguration.Configuration.UseStorage(firebaseStorage);
            services.AddHangfireServer();
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
            }

            #region Configure Hangfire

            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                AppPath = "hasanural.com",
                DashboardTitle = "Bot Chiliz Dashboard",
                Authorization = new[]
                {
                    new HangfireCustomBasicAuthenticationFilter
                    {
                        User = Configuration.GetSection("HangfireCredentials:UserName").Value,
                        Pass = Configuration.GetSection("HangfireCredentials:Password").Value,
                    }
                }
            });

            #endregion

            #region Job Schedule Tasks

            RecurringJob.AddOrUpdate("Runs Every 1 Min",()=>new BiJob().JobAsync(),"*/5 * * * *");
            var jId=BackgroundJob.Enqueue(()=>new BiJob().JobAsync());
            

            #endregion

            //app.UseStaticFiles();

            //app.UseRouting();

            //app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers();});
            
        }
    }
}
