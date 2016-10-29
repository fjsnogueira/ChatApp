using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace TeamOfOne
{
    public class ChatApp
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseWebRoot("www")
                .Build();

            host.Run();
        }
    }
}
