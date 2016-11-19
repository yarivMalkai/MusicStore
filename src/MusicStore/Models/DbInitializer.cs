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
            context.Genres.Add(new Genre() { Id = 7, Name = "Soul" });
            context.Genres.Add(new Genre() { Id = 8, Name = "Trance" });
            context.Genres.Add(new Genre() { Id = 9, Name = "Hip Hop" });
            context.SaveChanges();
            context.Database.CloseConnection();

            context.Database.OpenConnection();
            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Artists ON");
            context.Artists.Add(new Artist() { Id = 1, Name = "Beyonce", Type = ArtistType.Female, Nationality = "USA", Description = "gdflgfs sfdkbnsdf sdfkdbfjldsbf dkfbsdjkf sd fksdbfkjsd fsdj fjdks fjksd fjkds fjskd fjksdbfjksdbfkjsd fjksd fj", Picture = "beyonce.jpg" });
            context.Artists.Add(new Artist() { Id = 2, Name = "Rihanna", Type = ArtistType.Female, Nationality = "Barbados" });
            context.Artists.Add(new Artist() { Id = 3, Name = "Bob Marley", Type = ArtistType.Male, Nationality = "Jamaica", Picture = "marley.jpg" });
            context.Artists.Add(new Artist() { Id = 4, Name = "The Rolling Stones", Type = ArtistType.Band, Nationality = "UK" });
            context.Artists.Add(new Artist() { Id = 5, Name = "The Beatles", Type = ArtistType.Band, Nationality = "UK" });
            context.Artists.Add(new Artist() { Id = 6, Name = "Arctic Monkeys", Type = ArtistType.Band, Nationality = "UK", Picture = "arctic.jpg"});
            context.Artists.Add(new Artist() { Id = 7, Name = "Avicii", Type = ArtistType.Male, Nationality = "Sweden", Picture = "aviciijpg.jpg", Description = "Tim Bergling, better known by his stage name Avicii, is a Swedish musician, DJ, remixer and record producer" });
            context.Artists.Add(new Artist() { Id = 8, Name = "Infected Mushroom", Type = ArtistType.Band, Nationality = "Israel" });
            context.Artists.Add(new Artist() { Id = 9, Name = "Bruno Mars", Type = ArtistType.Male, Nationality = "USA", Picture = "Bruno_Mars,_Las_Vegas_2010.jpg"  });
            context.Artists.Add(new Artist() { Id = 10, Name = "Eminem", Type = ArtistType.Male, Nationality = "USA" });
            context.SaveChanges();
            context.Database.CloseConnection();

            context.Database.OpenConnection();
            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Albums ON");
            context.Albums.Add(new Album() { Id = 1, ArtistID = 1, GenreID = 7, Name = "Lemonade", Year = 2016, Price = 9.90, Picture = "Lemonade.jpg" });
            context.Albums.Add(new Album() { Id = 2, ArtistID = 1, GenreID = 1, Name = "Dangerously in Love", Year = 2003, Price = 9.90, Picture = "Dangerously_in_Love.jpg" });
            context.Albums.Add(new Album() { Id = 3, ArtistID = 6, GenreID = 3, Name = "AM", Year = 2013, Price = 9.90, Picture = "AM.jpg" });
            context.Albums.Add(new Album() { Id = 4, ArtistID = 6, GenreID = 3, Name = "Suck It And See", Year = 2011, Price = 9.90, Picture = "Suck_it_and_see.jpg" });
            context.Albums.Add(new Album() { Id = 5, ArtistID = 7, GenreID = 5, Name = "True", Year = 2013, Price = 9.90, Picture = "True.jpg" });
            context.Albums.Add(new Album() { Id = 6, ArtistID = 3, GenreID = 6, Name = "Kaya", Year = 1978, Price = 9.90, Picture = "Kaya.jpg" });
            context.Albums.Add(new Album() { Id = 7, ArtistID = 8, GenreID = 8, Name = "Converting Vegetarians", Year = 2003, Price = 9.90, Picture = "Converting_Vegetarians.jpg" });
            context.Albums.Add(new Album() { Id = 8, ArtistID = 8, GenreID = 8, Name = "Legend of the Black Shawarma", Year = 2009, Price = 9.90, Picture = "legendOfBlack.jpg" });
            context.Albums.Add(new Album() { Id = 9, ArtistID = 9, GenreID = 7, Name = "24K Magic", Year = 2016, Price = 9.90, Picture = "24K_Magic.jpg" });
            context.Albums.Add(new Album() { Id = 10, ArtistID = 5, GenreID = 3, Name = "Abbey Road", Year = 1969, Price = 9.90, Picture = "AbbeyRoad.jpg" });
            context.Albums.Add(new Album() { Id = 11, ArtistID = 2, GenreID = 1, Name = "Loud", Year = 2010, Price = 9.90, Picture = "Loud.jpg" });
            context.Albums.Add(new Album() { Id = 12, ArtistID = 4, GenreID = 3, Name = "Let It Bleed", Year = 1969, Price = 9.90, Picture = "LetItBleed.jpg" });
            context.Albums.Add(new Album() { Id = 13, ArtistID = 10, GenreID = 9, Name = "Encore", Year = 2004, Price = 9.90, Picture = "Encore.jpg" });
            context.SaveChanges();
            context.Database.CloseConnection();

            context.Songs.Add(new Song() { AlbumId = 1, Name = "Pray You Catch Me", Duration = "3:16", Order = 1 });
            context.Songs.Add(new Song() { AlbumId = 1, Name = "Hold Up", Duration = "3:41", Order = 2 });
            context.Songs.Add(new Song() { AlbumId = 1, Name = "Don’t Hurt Yourself", Duration = "3:54", Order = 3 });
            context.Songs.Add(new Song() { AlbumId = 1, Name = "Sorry", Duration = "3:53", Order = 4 });
            context.Songs.Add(new Song() { AlbumId = 1, Name = "6 Inch", Duration = "4:20", Order = 5 });
            context.Songs.Add(new Song() { AlbumId = 1, Name = "Daddy Lessons", Duration = "4:48", Order = 6 });
            context.Songs.Add(new Song() { AlbumId = 1, Name = "Love Drought", Duration = "3:57", Order = 7 });
            context.Songs.Add(new Song() { AlbumId = 1, Name = "Sandcastles", Duration = "3:03", Order = 8 });
            context.Songs.Add(new Song() { AlbumId = 1, Name = "Forward", Duration = "1:19", Order = 9 });
            context.Songs.Add(new Song() { AlbumId = 1, Name = "Freedom", Duration = "4:50", Order = 10 });
            context.Songs.Add(new Song() { AlbumId = 1, Name = "All Night", Duration = "5:22", Order = 11 });
            context.Songs.Add(new Song() { AlbumId = 1, Name = "Formation", Duration = "3:26", Order = 12 });

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

            context.Songs.Add(new Song() { AlbumId = 3, Name = "Do I Wanna Know?", Duration = "4:32", Order = 1 });
            context.Songs.Add(new Song() { AlbumId = 3, Name = "R U Mine?", Duration = "3:21", Order = 2 });
            context.Songs.Add(new Song() { AlbumId = 3, Name = "One for the Road", Duration = "3:26", Order = 3 });
            context.Songs.Add(new Song() { AlbumId = 3, Name = "Arabella", Duration = "3:27", Order = 4 });
            context.Songs.Add(new Song() { AlbumId = 3, Name = "I Want It All", Duration = "3:04", Order = 5 });
            context.Songs.Add(new Song() { AlbumId = 3, Name = "No. 1 Party Anthem", Duration = "4:03", Order = 6 });
            context.Songs.Add(new Song() { AlbumId = 3, Name = "Mad Sounds", Duration = "3:35", Order = 7 });
            context.Songs.Add(new Song() { AlbumId = 3, Name = "Fireside", Duration = "3:01", Order = 8 });
            context.Songs.Add(new Song() { AlbumId = 3, Name = "Why'd You Only Call Me When You're High?", Duration = "2:41", Order = 9 });
            context.Songs.Add(new Song() { AlbumId = 3, Name = "Snap Out of It", Duration = "3:12", Order = 10 });
            context.Songs.Add(new Song() { AlbumId = 3, Name = "Knee Socks", Duration = "4:17", Order = 11 });
            context.Songs.Add(new Song() { AlbumId = 3, Name = "I Wanna Be Yours", Duration = "3:04", Order = 12 });

            context.Songs.Add(new Song() { AlbumId = 4, Name = "She's Thunderstorms", Duration = "3:54", Order = 1 });
            context.Songs.Add(new Song() { AlbumId = 4, Name = "Black Treacle", Duration = "3:35", Order = 2 });
            context.Songs.Add(new Song() { AlbumId = 4, Name = "Brick by Brick", Duration = "2:59", Order = 3 });
            context.Songs.Add(new Song() { AlbumId = 4, Name = "The Hellcat Spangled Shalalala", Duration = "3:00", Order = 4 });
            context.Songs.Add(new Song() { AlbumId = 4, Name = "Don't Sit Down 'Cause I've Moved Your Chair", Duration = "3:03", Order = 5 });
            context.Songs.Add(new Song() { AlbumId = 4, Name = "Library Pictures", Duration = "2:22", Order = 6 });
            context.Songs.Add(new Song() { AlbumId = 4, Name = "All My Own Stunts", Duration = "3:52", Order = 7 });
            context.Songs.Add(new Song() { AlbumId = 4, Name = "Reckless Serenade", Duration = "2:42", Order = 8 });
            context.Songs.Add(new Song() { AlbumId = 4, Name = "Piledriver Waltz", Duration = "3:23", Order = 9 });
            context.Songs.Add(new Song() { AlbumId = 4, Name = "Love Is a Laserquest", Duration = "3:11", Order = 10 });
            context.Songs.Add(new Song() { AlbumId = 4, Name = "Suck It and See", Duration = "3:46", Order = 11 });
            context.Songs.Add(new Song() { AlbumId = 4, Name = "That's Where You're Wrong", Duration = "4:16", Order = 12 });
            context.Songs.Add(new Song() { AlbumId = 4, Name = "The Blond-O-Sonic Shimmer Trap", Duration = "3:24", Order = 13 });

            context.Songs.Add(new Song() { AlbumId = 5, Name = "Wake Me Up", Duration = "4:07", Order = 1 });
            context.Songs.Add(new Song() { AlbumId = 5, Name = "You Make Me", Duration = "3:53", Order = 2 });
            context.Songs.Add(new Song() { AlbumId = 5, Name = "Hey Brother", Duration = "4:15", Order = 3 });
            context.Songs.Add(new Song() { AlbumId = 5, Name = "Addicted to You", Duration = "2:28", Order = 4 });
            context.Songs.Add(new Song() { AlbumId = 5, Name = "Dear Boy", Duration = "7:59", Order = 5 });
            context.Songs.Add(new Song() { AlbumId = 5, Name = "Liar Liar", Duration = "3:59", Order = 6 });
            context.Songs.Add(new Song() { AlbumId = 5, Name = "Shame On Me", Duration = "4:13", Order = 7 });
            context.Songs.Add(new Song() { AlbumId = 5, Name = "Lay Me Down", Duration = "5:00", Order = 8 });
            context.Songs.Add(new Song() { AlbumId = 5, Name = "Hope There's Someone", Duration = "6:21", Order = 9 });
            context.Songs.Add(new Song() { AlbumId = 5, Name = "Heart Upon My Sleeve", Duration = "4:43", Order = 10 });
            context.Songs.Add(new Song() { AlbumId = 5, Name = "All You Need Is Love", Duration = "6:21", Order = 11 });
            context.Songs.Add(new Song() { AlbumId = 5, Name = "Always on the Run", Duration = "4:55", Order = 12 });
            context.Songs.Add(new Song() { AlbumId = 5, Name = "Canyons", Duration = "7:29", Order = 13 });
            context.Songs.Add(new Song() { AlbumId = 5, Name = "Long Road To Hell", Duration = "3:43", Order = 14 });
            context.Songs.Add(new Song() { AlbumId = 5, Name = "Levels - Radio Edit", Duration = "3:19", Order = 15 });

            context.Songs.Add(new Song() { AlbumId = 6, Name = "Easy Skanking", Duration = "2:56", Order = 1 });
            context.Songs.Add(new Song() { AlbumId = 6, Name = "Kaya", Duration = "3:16", Order = 2 });
            context.Songs.Add(new Song() { AlbumId = 6, Name = "Is This Love", Duration = "3:52", Order = 3 });
            context.Songs.Add(new Song() { AlbumId = 6, Name = "Sun Is Shining", Duration = "4:58", Order = 4 });
            context.Songs.Add(new Song() { AlbumId = 6, Name = "Satisfy My Soul", Duration = "4:33", Order = 5 });
            context.Songs.Add(new Song() { AlbumId = 6, Name = "She's Gone", Duration = "2:25", Order = 6 });
            context.Songs.Add(new Song() { AlbumId = 6, Name = "Misty Morning", Duration = "3:34", Order = 7 });
            context.Songs.Add(new Song() { AlbumId = 6, Name = "Crisis", Duration = "3:55", Order = 8 });
            context.Songs.Add(new Song() { AlbumId = 6, Name = "Running Away", Duration = "4:15", Order = 9 });
            context.Songs.Add(new Song() { AlbumId = 6, Name = "Time Will Tell", Duration = "3:29", Order = 10 });

            context.Songs.Add(new Song() { AlbumId = 7, Name = "Albibeno", Duration = "7:03", Order = 1 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Hush Mail", Duration = "7:01", Order = 2 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Apogiffa Night", Duration = "8:08", Order = 3 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Song Pong", Duration = "8:37", Order = 4 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Chaplin", Duration = "6:55", Order = 5 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Echonomix", Duration = "7:44", Order = 6 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Scorpion Frog", Duration = "8:00", Order = 7 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Deeply Disturbed", Duration = "8:26", Order = 8 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Semi Nice", Duration = "6:10", Order = 9 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Yanko Pitch", Duration = "8:13", Order = 10 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Converting Vegetarians", Duration = "5:40", Order = 11 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Elation Station", Duration = "5:36", Order = 12 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Drop Out", Duration = "5:15", Order = 13 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Avratz", Duration = "10:24", Order = 14 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Blink", Duration = "5:32", Order = 15 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Shakawkaw", Duration = "4:09", Order = 16 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Pletzturra", Duration = "6:45", Order = 17 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "I Wish", Duration = "3:01", Order = 18 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Ballerium", Duration = "7:18", Order = 19 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Selecta", Duration = "5:22", Order = 20 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Illuminaughty", Duration = "4:50", Order = 21 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Jeenge", Duration = "7:03", Order = 22 });
            context.Songs.Add(new Song() { AlbumId = 7, Name = "Elevation", Duration = "5:15", Order = 23 });

            context.Songs.Add(new Song() { AlbumId = 8, Name = "Poquito Mas", Duration = "3:40", Order = 1 });
            context.Songs.Add(new Song() { AlbumId = 8, Name = "Saeed", Duration = "7:04", Order = 2 });
            context.Songs.Add(new Song() { AlbumId = 8, Name = "End Of The Road", Duration = "6:47", Order = 3 });
            context.Songs.Add(new Song() { AlbumId = 8, Name = "Smashing The Opponent (feat. Jonathan Davis)", Duration = "4:10", Order = 4 });
            context.Songs.Add(new Song() { AlbumId = 8, Name = "Can't Stop", Duration = "7:24", Order = 5 });
            context.Songs.Add(new Song() { AlbumId = 8, Name = "Herbert The Pervert", Duration = "7:18", Order = 6 });
            context.Songs.Add(new Song() { AlbumId = 8, Name = "Killing Time (feat. Perry Farrell)", Duration = "3:05", Order = 7 });
            context.Songs.Add(new Song() { AlbumId = 8, Name = "Project 100", Duration = "9:38", Order = 8 });
            context.Songs.Add(new Song() { AlbumId = 8, Name = "Franks", Duration = "8:05", Order = 9 });
            context.Songs.Add(new Song() { AlbumId = 8, Name = "Slowly", Duration = "9:00", Order = 10 });
            context.Songs.Add(new Song() { AlbumId = 8, Name = "The Legend Of The Black Shawarma", Duration = "7:12", Order = 11 });
            context.Songs.Add(new Song() { AlbumId = 8, Name = "Riders On The Storm (Infected Mushroom Remix)", Duration = "4:29", Order = 12 });

            context.Songs.Add(new Song() { AlbumId = 9, Name = "24K Magic", Duration = "3:46", Order = 1 });
            context.Songs.Add(new Song() { AlbumId = 9, Name = "Track 2", Duration = "3:00", Order = 2 });
            context.Songs.Add(new Song() { AlbumId = 9, Name = "Track 3", Duration = "3:00", Order = 3 });
            context.Songs.Add(new Song() { AlbumId = 9, Name = "Track 4", Duration = "3:00", Order = 4 });
            context.Songs.Add(new Song() { AlbumId = 9, Name = "Versace On The Floor", Duration = "4:21", Order = 5 });
            context.Songs.Add(new Song() { AlbumId = 9, Name = "Track 6", Duration = "3:00", Order = 6 });
            context.Songs.Add(new Song() { AlbumId = 9, Name = "Track 7", Duration = "3:00", Order = 7 });
            context.Songs.Add(new Song() { AlbumId = 9, Name = "Track 8", Duration = "3:00", Order = 8 });
            context.Songs.Add(new Song() { AlbumId = 9, Name = "Track 9", Duration = "3:00", Order = 9 });

            context.Songs.Add(new Song() { AlbumId = 10, Name = "Come Together", Duration = "4:19", Order = 1 });
            context.Songs.Add(new Song() { AlbumId = 10, Name = "Something", Duration = "3:03", Order = 2 });
            context.Songs.Add(new Song() { AlbumId = 10, Name = "Maxwell's Silver Hammer", Duration = "3:27", Order = 3 });
            context.Songs.Add(new Song() { AlbumId = 10, Name = "Oh! Darling", Duration = "3:27", Order = 4 });
            context.Songs.Add(new Song() { AlbumId = 10, Name = "Octopus's Garden", Duration = "2:51", Order = 5 });
            context.Songs.Add(new Song() { AlbumId = 10, Name = "I Want You (She's So Heavy)", Duration = "7:47", Order = 6 });
            context.Songs.Add(new Song() { AlbumId = 10, Name = "Here Comes the Sun", Duration = "3:06", Order = 7 });
            context.Songs.Add(new Song() { AlbumId = 10, Name = "Because", Duration = "2:46", Order = 8 });
            context.Songs.Add(new Song() { AlbumId = 10, Name = "You Never Give Me Your Money", Duration = "4:02", Order = 9 });
            context.Songs.Add(new Song() { AlbumId = 10, Name = "Sun King", Duration = "2:26", Order = 10 });
            context.Songs.Add(new Song() { AlbumId = 10, Name = "Mean Mr. Mustard", Duration = "1:06", Order = 11 });
            context.Songs.Add(new Song() { AlbumId = 10, Name = "Polythene Pam", Duration = "1:13", Order = 12 });
            context.Songs.Add(new Song() { AlbumId = 10, Name = "She Came In Through the Bathroom Window", Duration = "1:58", Order = 13 });
            context.Songs.Add(new Song() { AlbumId = 10, Name = "Golden Slumbers", Duration = "1:32", Order = 14 });
            context.Songs.Add(new Song() { AlbumId = 10, Name = "Carry That Weight", Duration = "1:37", Order = 15 });
            context.Songs.Add(new Song() { AlbumId = 10, Name = "The End", Duration = "2:20", Order = 16 });
            context.Songs.Add(new Song() { AlbumId = 10, Name = "Her Majesty", Duration = "0:23", Order = 17 });

            context.Songs.Add(new Song() { AlbumId = 11, Name = "S&M", Duration = "4:03", Order = 1 });
            context.Songs.Add(new Song() { AlbumId = 11, Name = "What's My Name?", Duration = "4:23", Order = 2 });
            context.Songs.Add(new Song() { AlbumId = 11, Name = "Cheers (Drink to That)", Duration = "4:22", Order = 3 });
            context.Songs.Add(new Song() { AlbumId = 11, Name = "Fading", Duration = "3:20", Order = 4 });
            context.Songs.Add(new Song() { AlbumId = 11, Name = "Only Girl (In the World)", Duration = "3:55", Order = 5 });
            context.Songs.Add(new Song() { AlbumId = 11, Name = "California King Bed", Duration = "4:12", Order = 6 });
            context.Songs.Add(new Song() { AlbumId = 11, Name = "Man Down", Duration = "4:27", Order = 7 });
            context.Songs.Add(new Song() { AlbumId = 11, Name = "Raining Men", Duration = "3:45", Order = 8 });
            context.Songs.Add(new Song() { AlbumId = 11, Name = "Complicated", Duration = "4:18", Order = 9 });
            context.Songs.Add(new Song() { AlbumId = 11, Name = "Skin", Duration = "5:04", Order = 10 });
            context.Songs.Add(new Song() { AlbumId = 11, Name = "Love the Way You Lie (Part II)", Duration = "4:56", Order = 11 });

            context.Songs.Add(new Song() { AlbumId = 11, Name = "Gimme Shelter", Duration = "4:33", Order = 1 });
            context.Songs.Add(new Song() { AlbumId = 11, Name = "Love in Vain", Duration = "4:19", Order = 2 });
            context.Songs.Add(new Song() { AlbumId = 11, Name = "Country Honk", Duration = "3:07", Order = 3 });
            context.Songs.Add(new Song() { AlbumId = 11, Name = "Live With Me", Duration = "3:33", Order = 4 });
            context.Songs.Add(new Song() { AlbumId = 11, Name = "Let It Bleed", Duration = "5:28", Order = 5 });
            context.Songs.Add(new Song() { AlbumId = 11, Name = "Midnight Rambler", Duration = "6:53", Order = 6 });
            context.Songs.Add(new Song() { AlbumId = 11, Name = "You Got the Silver", Duration = "2:51", Order = 7 });
            context.Songs.Add(new Song() { AlbumId = 11, Name = "Monkey Man", Duration = "4:11", Order = 8 });
            context.Songs.Add(new Song() { AlbumId = 11, Name = "You Can’t Always Get What You Want", Duration = "7:30", Order = 9 });

            context.Songs.Add(new Song() { AlbumId = 13, Name = "Curtains Up", Duration = "0:47", Order = 1 });
            context.Songs.Add(new Song() { AlbumId = 13, Name = "Evil Deeds", Duration = "4:20", Order = 2 });
            context.Songs.Add(new Song() { AlbumId = 13, Name = "Never Enough", Duration = "2:40", Order = 3 });
            context.Songs.Add(new Song() { AlbumId = 13, Name = "Yellow Brick Road", Duration = "5:46", Order = 4 });
            context.Songs.Add(new Song() { AlbumId = 13, Name = "Like Toy Soldiers", Duration = "4:56", Order = 5 });
            context.Songs.Add(new Song() { AlbumId = 13, Name = "Mosh", Duration = "5:18", Order = 6 });
            context.Songs.Add(new Song() { AlbumId = 13, Name = "Puke [Explicit]", Duration = "4:08", Order = 7 });
            context.Songs.Add(new Song() { AlbumId = 13, Name = "My 1st Single", Duration = "5:03", Order = 8 });
            context.Songs.Add(new Song() { AlbumId = 13, Name = "Paul (skit)", Duration = "0:32", Order = 9 });
            context.Songs.Add(new Song() { AlbumId = 13, Name = "Rain Man", Duration = "5:14", Order = 10 });
            context.Songs.Add(new Song() { AlbumId = 13, Name = "Big Weenie", Duration = "4:27", Order = 11 });
            context.Songs.Add(new Song() { AlbumId = 13, Name = "Em Calls Paul (skit)", Duration = "1:12", Order = 12 });
            context.Songs.Add(new Song() { AlbumId = 13, Name = "Just Lose It [Explicit]", Duration = "4:08", Order = 13 });
            context.Songs.Add(new Song() { AlbumId = 13, Name = "Ass Like That [Explicit]", Duration = "4:26", Order = 14 });
            context.Songs.Add(new Song() { AlbumId = 13, Name = "Spend Some Time", Duration = "5:11", Order = 15 });
            context.Songs.Add(new Song() { AlbumId = 13, Name = "Mockingbird", Duration = "4:11", Order = 16 });
            context.Songs.Add(new Song() { AlbumId = 13, Name = "Crazy in Love", Duration = "4:02", Order = 17 });
            context.Songs.Add(new Song() { AlbumId = 13, Name = "One Shot 2 Shot", Duration = "4:27", Order = 18 });
            context.Songs.Add(new Song() { AlbumId = 13, Name = "Final Thought (skit)", Duration = "0:30", Order = 19 });
            context.Songs.Add(new Song() { AlbumId = 13, Name = "Encore / (Curtains)", Duration = "5:48", Order = 20 });

            context.SaveChanges();

        }
        
    }
}
