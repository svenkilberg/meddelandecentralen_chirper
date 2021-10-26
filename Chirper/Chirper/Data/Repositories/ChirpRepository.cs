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

        

        public void CreateNewChirp(string userName, string message, string pipeTag)
        {
            var maxId = Program.AllChirps.Max(chirp => chirp.Id);
            
            Program.AllChirps.Add(new Chirp
            {
                Id = maxId + 1,
                UserName = userName,
                Message = message,
                Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                PipeTag = pipeTag,
            });
                      
            
        }

        public void DeleteChirp(int id)
        {
            Program.AllChirps.RemoveAll(chirp => chirp.Id == id);
        }

        public void EditChirp(int id, string userName, string message, string pipeTag)
        {
            var obj = Program.AllChirps.SingleOrDefault(x => x.Id == id);

            if (obj != null)
            {
                obj.UserName = userName;
                obj.Message = message;
                obj.PipeTag = pipeTag;                
            }
        }
    }
}
