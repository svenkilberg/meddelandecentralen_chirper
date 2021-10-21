using Chirper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chirper.Data.Repositories
{
    public interface IChirpRepository
    {
        public void CreateNewChirp(string userName, string message);

        public List<Chirp> GetAllChirps();
    }
}
