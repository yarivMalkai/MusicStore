﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    public class Genre
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
