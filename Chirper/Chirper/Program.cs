using Chirper.Data.Repositories;
using Chirper.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chirper
{
    public class Program
    {
        public static List<Chirp> AllChirps = new List<Chirp>
            {
                new Chirp
                {
                    Id = 1,
                    UserName = "Kalle",
                    Message = "Polsk�taren kommer imorgon. Beh�ver bli insl�ppt",
                    Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    PipeTag = "Polen",
                },
                new Chirp
                {
                    Id = 2,
                    UserName = "Kalle",
                    Message = "Rena handukar beh�ver fyllas p� i f�r�det.",
                    Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    PipeTag = "Polen",
                },
                new Chirp
                {
                    Id = 3,
                    UserName = "Bertil",
                    Message = "Best�ll mer juice.",
                    Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    PipeTag = "Baren",
                },                
            };
        public static void Main(string[] args)
        {
            
        CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
