using Chirper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chirper.Data.Repositories
{
    public interface IChirpRepository
    {
        public List<Chirp> GetAllChirps();

        public void CreateNewChirp(string userName, string message, string pipeTag);

        public void DeleteChirp(int id);

        public void EditChirp(int id, string userName, string message, string pipeTag);
    }
}
