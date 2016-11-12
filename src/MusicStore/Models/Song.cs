using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    public class Song
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Duration { get; set; }

        public  int Order { get; set; }

        public int AlbumId { get; set; }

        [ForeignKey("AlbumId")]
        public Album Album { get; set; }
    }
}
