﻿using Chirper.Data.Repositories;
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
        public async Task SendAllChirps()
        {
            var allChirps = _chirpRepository.AllChirps;

            await Clients.All.SendAsync("RecieveAllChirps", allChirps);
        }
    }
}