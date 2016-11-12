using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    public class Artist
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ArtistType Type { get; set; }

        public string Nationality { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }

    public enum ArtistType
    {
        Male,
        Female,
        Band
    }
}

