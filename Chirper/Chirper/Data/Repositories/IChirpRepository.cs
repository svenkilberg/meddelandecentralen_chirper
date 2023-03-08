using Chirper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chirper.Data.Repositories
{
    public interface IChirpRepository
    {
        Task<List<Chirp>> GetAllChirpsAsync();

        Task CreateNewChirpAsync(Chirp chirp);

        Task DeleteChirpAsync(int id);

        void EditChirp(Chirp chirp);
    }
}
