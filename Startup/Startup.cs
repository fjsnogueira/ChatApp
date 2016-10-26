
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TeamOfOne 
{
    public class Startup 
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR(options => 
            {
                options.Hubs.EnableDetailedErrors = true;
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseWebSockets();
            app.UseSignalR();
        }
    }
}