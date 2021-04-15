using System;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Hosting;

namespace ServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World!");
                //var certificatePath = Directory.GetCurrentDirectory() + @"\certificate\foxai.info.pfx"; ;
                //var certificatePassword = "pass123$";
                //IPAddress ipAddress = IPAddress.Parse("*");
                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .UseKestrel(options =>
                    {
                        options.Listen(IPAddress.Any, 5002);
                        //options.Listen(IPAddress.Any, 443, listenOptions =>
                        //{
                        //    listenOptions.UseHttps(certificatePath, certificatePassword);
                        //} );
                    })
                    //  .UseUrls("https://*:5002")
                    .Build();

                host.Run();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // throw;
            }
        }
    }
}
