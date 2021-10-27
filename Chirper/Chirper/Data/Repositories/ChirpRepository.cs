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

            try
            {
                if(Program.AllChirps.Any())
                {
                    var maxId = Program.AllChirps.Max(chirp => chirp.Id);


                    Console.WriteLine(Program.AllChirps);

                    Program.AllChirps.Add(new Chirp
                    {
                        Id = maxId + 1,
                        UserName = userName,
                        Message = message,
                        Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        PipeTag = pipeTag,
                    });
                }
                else
                {
                    Program.AllChirps.Add(new Chirp
                    {
                        Id = 1,
                        UserName = userName,
                        Message = message,
                        Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        PipeTag = pipeTag,
                    });
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
             
                      
            
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
