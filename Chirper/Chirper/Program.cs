﻿using Chirper.Data.Repositories;
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
                    Message = "Fint väder idag!! 😎",
                    Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    PipeTag = "Allmänt",
                },
                new Chirp
                {
                    Id = 2,
                    UserName = "Bertil",
                    Message = "Ja, verkligen! 👍",
                    Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    PipeTag = "Allmänt",
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
