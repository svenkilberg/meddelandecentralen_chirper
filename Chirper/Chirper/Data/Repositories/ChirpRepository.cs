using Chirper.Entities;
using System.Collections.Generic;

namespace Chirper.Data.Repositories
{
    public class ChirpRepository : IChirpRepository
    {
        public IEnumerable<Chirp> AllChirps =>
            new List<Chirp>
            {
                new Chirp
                {
                    Id = 1,
                    UserName = "Kalle",
                    Message = "Rengör polen."
                },
                new Chirp
                {
                    Id = 2,
                    UserName = "Kalle",
                    Message = "Lägg dit rena handdukar."
                },
                new Chirp
                {
                    Id = 3,
                    UserName = "Bertil",
                    Message = "Gästen på rum 301 vill ha sina ägg löskokta."
                }
            };
    }
}
