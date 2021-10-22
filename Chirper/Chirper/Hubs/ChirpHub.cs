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
        public async Task SendMessage(List<Chirp> allChirps)
        {
            //var allChirps = _chirpRepository.AllChirps;
            //var allChirps = "Test message";

            await Clients.All.SendAsync("RecieveAllChirps", allChirps);
        }

        public async Task CreateNewChirp(string userName, string message, string pipeTag)
        {
            Console.WriteLine("In CreateNewChirp hub");
            _chirpRepository.CreateNewChirp(userName, message, pipeTag);

            await SendMessage(_chirpRepository.GetAllChirps());
        }

        public override async Task OnConnectedAsync()
        {
            await SendMessage(_chirpRepository.GetAllChirps());
        }

       
    }
}
