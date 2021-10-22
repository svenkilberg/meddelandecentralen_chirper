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
        public static List<Chirp> AllChirps = new List<Chirp>()
            {
                new Chirp
                {
                    Id = 1,
                    UserName = "Kalle",
                    Message = "Rengör polen.",
                    Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    PipeTag = "Polen",
                },
                new Chirp
                {
                    Id = 2,
                    UserName = "Kalle",
                    Message = "Lägg dit rena handdukar.",
                    Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    PipeTag = "Polen",
                },
                new Chirp
                {
                    Id = 3,
                    UserName = "Bertil",
                    Message = "Gästen på rum 301 vill ha sina ägg löskokta.",
                    Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    PipeTag = "Rum 301",
                },
                new Chirp
                {
                    Id = 4,
                    UserName = "Lennart",
                    Message = "Fyll på mer is i baren.",
                    Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    PipeTag = "Baren",
                }
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
