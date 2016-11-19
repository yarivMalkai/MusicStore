using MusicStore.Data.ws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace MusicStore.Data
{
    public class ArtistInfoClient
    {
        public const string keyAPI = "44e5a1b2a074bb564d4b04f1baa88f16";
        public static HttpClient client = new HttpClient();

        public static async Task<string> getArtistInfo(string artistName)
        {
            try
            {
                string path = string.Format("http://ws.audioscrobbler.com/2.0/?method=artist.getinfo&artist={0}&api_key={1}&format=json", artistName, keyAPI);

                // Syncronious Consumption
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    RootObject obj =  (RootObject) new DataContractJsonSerializer(typeof(RootObject)).ReadObject( response.Content.ReadAsStreamAsync().Result);
                    return obj.artist.bio.summary;
                }
                return "";

            }
            catch
            {
                return "";
            }
        }
    }
}
