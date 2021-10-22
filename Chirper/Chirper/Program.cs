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
                    Message = "Reng�r polen.",
                    Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    PipeTag = "Polen",
                },
                new Chirp
                {
                    Id = 2,
                    UserName = "Kalle",
                    Message = "L�gg dit rena handdukar.",
                    Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    PipeTag = "Polen",
                },
                new Chirp
                {
                    Id = 3,
                    UserName = "Bertil",
                    Message = "G�sten p� rum 301 vill ha sina �gg l�skokta.",
                    Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    PipeTag = "Rum 301",
                },
                new Chirp
                {
                    Id = 4,
                    UserName = "Lennart",
                    Message = "Fyll p� mer is i baren.",
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
