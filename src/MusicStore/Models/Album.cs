using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    public class Album
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public int ArtistID { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public string Picture { get; set; }

        [ForeignKey("ArtistID")]
        public Artist Artist { get; set; }

        public int GenreID { get; set; }

        [ForeignKey("GenreID")]
        public Genre Genre { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
