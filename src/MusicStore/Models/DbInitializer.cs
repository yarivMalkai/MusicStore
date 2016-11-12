using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    public class DbInitializer
    {
        public static void Init(MusicContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Albums.Any())
            {
                return;   // DB has been seeded
            }


            context.Database.OpenConnection();
            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Genres ON");
            
            context.Genres.Add(new Genre() { Id = 1, Name = "Pop" });
            context.Genres.Add(new Genre() { Id = 2, Name = "Rap" });
            context.Genres.Add(new Genre() { Id = 3, Name = "Rock" });
            context.Genres.Add(new Genre() { Id = 4, Name = "Techno" });
            context.Genres.Add(new Genre() { Id = 5, Name = "House" });
            context.Genres.Add(new Genre() { Id = 6, Name = "Reggae" });
            context.SaveChanges();
            context.Database.CloseConnection();

            context.Database.OpenConnection();
            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Artists ON");
            context.Artists.Add(new Artist() { Id = 1, Name = "Beyonce", Type = ArtistType.Female, Nationality = "USA" });
            context.Artists.Add(new Artist() { Id = 2, Name = "Rihanna", Type = ArtistType.Female, Nationality = "Barbados" });
            context.Artists.Add(new Artist() { Id = 3, Name = "Bob Marley", Type = ArtistType.Male, Nationality = "Jamaica" });
            context.Artists.Add(new Artist() { Id = 4, Name = "The Rolling Stones", Type = ArtistType.Band, Nationality = "UK" });
            context.Artists.Add(new Artist() { Id = 5, Name = "The Beatles", Type = ArtistType.Band, Nationality = "UK" });
            context.Artists.Add(new Artist() { Id = 6, Name = "Arctic Monkeys", Type = ArtistType.Band, Nationality = "UK" });
            context.Artists.Add(new Artist() { Id = 7, Name = "Avicii", Type = ArtistType.Male, Nationality = "Sweden" });
            context.SaveChanges();
            context.Database.CloseConnection();

            context.Database.OpenConnection();
            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Albums ON");
            context.Albums.Add(new Album() { Id = 1, ArtistID = 1, GenreID = 1, Name = "Lemonade", Year = 2016, Price = 9.90, Picture = "Lemonade.jpg" });
            context.Albums.Add(new Album() { Id = 2, ArtistID = 1, GenreID = 1, Name = "Dangerously in Love", Year = 2003, Price = 9.90, Picture = "Dangerously_in_Love.jpg" });
            context.Albums.Add(new Album() { Id = 3, ArtistID = 6, GenreID = 3, Name = "AM", Year = 2013, Price = 9.90, Picture = "AM.jpg" });
            context.Albums.Add(new Album() { Id = 4, ArtistID = 6, GenreID = 3, Name = "Suck It And See", Year = 2011, Price = 9.90, Picture = "Suck_it_and_see.jpg" });
            context.Albums.Add(new Album() { Id = 5, ArtistID = 7, GenreID = 5, Name = "True", Year = 2013, Price = 9.90, Picture = "True.jpg" });
            context.Albums.Add(new Album() { Id = 6, ArtistID = 3, GenreID = 6, Name = "Kaya", Year = 1978, Price = 9.90, Picture = "Kaya.jpg" });
            context.SaveChanges();
            context.Database.CloseConnection();

            context.Songs.Add(new Song() { AlbumId = 2, Name = "Crazy in Love", Duration = "3:56", Order = 1 });
            context.Songs.Add(new Song() { AlbumId = 2, Name = "Naughty Girl", Duration = "3:29", Order = 2 });
            context.Songs.Add(new Song() { AlbumId = 2, Name = "Baby Boy", Duration = "4:04", Order = 3 });
            context.Songs.Add(new Song() { AlbumId = 2, Name = "Hip Hop Star", Duration = "3:43", Order = 4 });
            context.Songs.Add(new Song() { AlbumId = 2, Name = "Be with You", Duration = "4:20", Order = 5 });
            context.Songs.Add(new Song() { AlbumId = 2, Name = "Me, Myself and I", Duration = "5:01", Order = 6 });
            context.Songs.Add(new Song() { AlbumId = 2, Name = "Yes", Duration = "4:19", Order = 7 });
            context.Songs.Add(new Song() { AlbumId = 2, Name = "Signs", Duration = "4:59", Order = 8 });
            context.Songs.Add(new Song() { AlbumId = 2, Name = "Speechless", Duration = "6:00", Order = 9 });
            context.Songs.Add(new Song() { AlbumId = 2, Name = "That's How You Like It", Duration = "3:40", Order = 10 });
            context.Songs.Add(new Song() { AlbumId = 2, Name = "The Closer I Get to You", Duration = "4:57", Order = 11 });
            context.Songs.Add(new Song() { AlbumId = 2, Name = "Dangerously in Love 2", Duration = "4:54", Order = 12 });
            context.Songs.Add(new Song() { AlbumId = 2, Name = "Beyoncé Interlude", Duration = "0:16", Order = 13 });
            context.Songs.Add(new Song() { AlbumId = 2, Name = "Gift from Virgo", Duration = "2:46", Order = 14 });
            context.Songs.Add(new Song() { AlbumId = 2, Name = "Daddy", Duration = "5:00", Order = 15 });
            context.SaveChanges();

        }
        
    }
}
