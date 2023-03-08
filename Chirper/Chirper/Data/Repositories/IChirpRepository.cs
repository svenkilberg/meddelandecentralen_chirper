using Chirper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chirper.Data.Repositories
{
    public interface IChirpRepository
    {
        public Task<List<Chirp>> GetAllChirpsAsync();

        public void CreateNewChirp(Chirp chirp);

        public void DeleteChirp(int id);

        public void EditChirp(Chirp chirp);
    }
}
