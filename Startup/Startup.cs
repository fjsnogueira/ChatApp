
using System.Collections.Generic;
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
            //http://www.wipdeveloper.com/2016/01/09/asp-net-5-static-files-enable-default-files/
            var options = new DefaultFilesOptions {  
                DefaultFileNames = new List<string> { "index.html" } 
            };
            app.UseDefaultFiles(options);  

            app.UseStaticFiles();
            app.UseWebSockets();
            app.UseSignalR();
        }
    }
}