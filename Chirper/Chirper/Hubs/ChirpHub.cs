using Chirper.Data.Repositories;
using Chirper.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chirper.Hubs
{
    public class ChirpHub : Hub
    {
        private readonly IChirpRepository _chirpRepository;

        public ChirpHub(IChirpRepository chirpRepository)
        {
            _chirpRepository = chirpRepository;
        }
        public async Task SendMessage()
        {
            //var allChirps = _chirpRepository.AllChirps;
            //var allChirps = "Test message";

            await Clients.All.SendAsync("RecieveAllChirps", _chirpRepository.GetAllChirps());
        }

        public async Task CreateNewChirp(string userName, string message, string pipeTag)
        {
            Console.WriteLine("In CreateNewChirp hub");
            // TODO: Change this to an object direct from the API endpoint
            var chirp = new Chirp
            {
                UserName = userName,
                Message = message,
                PipeTag = pipeTag
            };

            _chirpRepository.CreateNewChirp(chirp);

            await SendMessage();
        }

        public async Task DeleteChirp(int id)
        {
            Console.WriteLine("In DeleteChirp hub " + id);
            _chirpRepository.DeleteChirp(id);

            await SendMessage();
        }

        public async Task EditChirp(int id, string userName, string message, string pipeTag)
        {
            Console.WriteLine("In EditChirp hub " + id);
            // TODO: Change this to an object direct from the API endpoint
            var chirp = new Chirp
            {
                Id = id,
                UserName = userName,
                Message = message,
                PipeTag = pipeTag
            };

            _chirpRepository.EditChirp(chirp);

            await SendMessage();
        }

        public override async Task OnConnectedAsync()
        {
            await SendMessage();
        }

       
    }
}
