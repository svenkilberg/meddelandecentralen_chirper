using Chirper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chirper.Data.Repositories
{
    public class ChirpRepository : IChirpRepository
    {
        public List<Chirp> GetAllChirps()
        {
            return Program.AllChirps;
        }

        

        public void CreateNewChirp(string userName, string message)
        {
            {
                Program.AllChirps.Add(new Chirp
                {
                    Id = Program.AllChirps.Count + 1,
                    UserName = userName,
                    Message = message,
                    Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                });
            }           
            
        }
    }
}
