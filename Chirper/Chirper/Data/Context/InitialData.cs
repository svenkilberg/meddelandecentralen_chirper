using Chirper.Entities;
using System;
using System.Linq;

namespace Chirper.Data.Context
{
    public static class InitialData
    {
        public static void Seed(this ChirpDbContext dbContext)
        {
            if (!dbContext.Chirps.Any())
            {
                dbContext.Chirps.Add(new Chirp
                {
                    UserName = "Kalle",
                    Message = "Fint väder idag!! 😎",
                    Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    PipeTag = "Allmänt",
                });
                dbContext.Chirps.Add(new Chirp
                {
                    UserName = "Bertil",
                    Message = "Ja, verkligen! 👍",
                    Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    PipeTag = "Allmänt",
                });

                dbContext.SaveChanges();
            }
        }
    }
}
