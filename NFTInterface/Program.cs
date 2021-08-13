using System;
using System.Net;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace NFTInterface
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var client = new WebClient();

            for (var i = 1; i < 360; i++)
            {
                try
                {
                    client.DownloadFile(@$"https://purple11.com/images/texture-overlays/full/{i.ToString().PadLeft(3, '0')}.jpg", @$"C:\NFTGeneratorData\textures\{i}.jpg");
                }
                catch
                {
                    Console.WriteLine($"Failed {i}");
                }
            }    

            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Returns b to the power of e (b^e).
        /// </summary>
        /// <param name="b">The base.</param>
        /// <param name="e">The exponent.</param>
        /// <returns>(b^e)</returns>
        public static int Power(int b, int e)
        {
            if (e == 0) { return 1; }
            if (e == 1) { return b; }
            if (e < 0) { throw new ArgumentException("e cannot be negative."); }
            for (var i = 0; i < e - 1; i++)
            {
                b *= b;
            }
            return b;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
