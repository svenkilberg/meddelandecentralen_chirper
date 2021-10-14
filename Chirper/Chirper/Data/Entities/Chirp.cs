﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chirper.Entities
{
    public class Chirp
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public List<PipeTag> PipeTags = new List<PipeTag>(); 
    }
}