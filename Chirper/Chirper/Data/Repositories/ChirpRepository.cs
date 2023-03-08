using Chirper.Data.Context;
using Chirper.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chirper.Data.Repositories
{
    public class ChirpRepository : IChirpRepository
    {
        private readonly ChirpContext _chirpContext;

        public ChirpRepository(ChirpContext chirpContext)
        {
            _chirpContext = chirpContext;
        }
        public async Task<List<Chirp>> GetAllChirpsAsync()
        {
            return await _chirpContext.Chirps.ToListAsync();
        }

        

        public void CreateNewChirp(Chirp chirp)
        {

            try
            {
                _chirpContext.Chirps.Add(chirp);
                _chirpContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
             
                      
            
        }

        public void DeleteChirp(int id)
        {
            var chirp = _chirpContext.Chirps.FirstOrDefault(s => s.Id == id);
            if (chirp != null)
            {
                _chirpContext.Chirps.Remove(chirp);
                _chirpContext.SaveChanges();
            }
        }

        public void EditChirp(Chirp chirp)
        {
            _chirpContext.Entry(chirp).State = EntityState.Modified;
            _chirpContext.SaveChanges();
        }
    }
}
