using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ThePrayer.Common.Config;

namespace ThePrayer.Api
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
            var appSettings = new ThePrayerSettings();

            services
                .AddAuthentication()
                .AddFacebook(options =>
                {
                    options.AppId = appSettings.OAuth.Facebook.ClientId;
                    options.AppSecret = appSettings.OAuth.Facebook.ClientSecret;
                })
                .AddGoogle(options =>
                {
                    options.ClientId = appSettings.OAuth.Google.ClientId;
                    options.ClientSecret = appSettings.OAuth.Google.ClientSecret;
                })
                .AddTwitter(options =>
                {
                    options.ConsumerKey = appSettings.OAuth.Twitter.ClientId;
                    options.ConsumerSecret = appSettings.OAuth.Twitter.ClientSecret;
                })
                .AddMicrosoftAccount(options =>
                {
                    options.ClientId = appSettings.OAuth.Microsoft.ClientId;
                    options.ClientSecret = appSettings.OAuth.Microsoft.ClientSecret;
                });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
