using Chirper.Data.Context;
using Chirper.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        

        public async Task CreateNewChirpAsync(Chirp chirp)
        {

            try
            {
                await _chirpContext.Chirps.AddAsync(chirp);
                await _chirpContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
             
                      
            
        }

        public async Task DeleteChirpAsync(int id)
        {
            var chirp = await _chirpContext.Chirps.FirstOrDefaultAsync(s => s.Id == id);
            if (chirp != null)
            {
                _chirpContext.Chirps.Remove(chirp);
                await _chirpContext.SaveChangesAsync();
            }
        }

        public async Task EditChirpAsync(Chirp chirp)
        {
            _chirpContext.Entry(chirp).State = EntityState.Modified;
            await _chirpContext.SaveChangesAsync();
        }
    }
}
