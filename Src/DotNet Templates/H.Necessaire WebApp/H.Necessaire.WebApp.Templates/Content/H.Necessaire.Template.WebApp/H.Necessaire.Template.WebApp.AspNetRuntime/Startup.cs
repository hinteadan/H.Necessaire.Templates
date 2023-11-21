using H.Necessaire;
using H.Necessaire.Runtime.Integration.NetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace H.Necessaire.Template.WebApp.AspNetRuntime
{
    public class Startup : DefaultStartup
    {
        readonly IConfiguration configuration;
        public Startup(IConfiguration configuration, ImADependencyRegistry dependencyRegistry, ILogger<DefaultStartup> logger) : base(dependencyRegistry, logger)
        {
            this.configuration = configuration;
        }

        protected override IServiceCollection ConfigureExtraServices(IServiceCollection services)
        {
            return
                base
                .ConfigureExtraServices(services)
                ;
        }

        protected override IServiceCollection ConfigureControllers(IServiceCollection services)
        {
            base.ConfigureControllers(services);

            services
                .AddControllers()
                .AddApplicationPart(typeof(H.Necessaire.Runtime.Integration.NetCore.Controllers.PingController).Assembly)
                .AddControllersAsServices()
                .AddNewtonsoftJson()
                ;

            return services;
        }

        protected override IApplicationBuilder ConfigureAppRouting(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseWhen(IsSocialMediaGraphRequest, app =>
            {
                app.Run(async httpContext =>
                {
                    httpContext.Response.Headers.ContentType = "text/html; charset=utf-8";
                    await httpContext.Response.WriteAsync(socialMediaGraphDefaultResponse);
                });
            });

            return
                base
                .ConfigureAppRouting(app, env)
                .UseRouting()
                ;
        }

        protected override IApplicationBuilder ConfigureAppEndpoints(IApplicationBuilder app, IHostEnvironment env)
        {
            return
                base
                .ConfigureAppEndpoints(app, env)
                .UseEndpoints(x =>
                {
                    x.MapControllers();
                })
                ;
        }

        private bool IsSocialMediaGraphRequest(HttpContext httpContext)
        {
            string? userAgent = httpContext.Request.Headers?.FirstOrDefault(x => string.Equals(x.Key, "User-Agent", StringComparison.InvariantCultureIgnoreCase)).Value;

            if (string.IsNullOrWhiteSpace(userAgent))
                return false;

            return
                userAgent.StartsWith("facebook", StringComparison.InvariantCultureIgnoreCase)
                || userAgent.StartsWith("Twitterbot", StringComparison.InvariantCultureIgnoreCase)
                ;
        }

        private string socialMediaGraphDefaultResponse = @$"
<meta property=""fb:app_id"" content=""XXXXXXXXXXXXX"" />
<meta property=""og:type"" content=""article"" />
<meta property=""og:title"" content=""H.Necessaire.Template.WebApp"" />
<meta property=""og:description""  content=""H.Necessaire.Template.WebApp"" />
<meta property=""og:image""  content=""https://h.necessaire.dev/Assets/necessaire_logo.png"" />
";
    }
}
