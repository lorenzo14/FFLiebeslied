using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using FFLiebeslied.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FFLiebeslied.API
{
    public class Api
    {
        static HttpClient cliente = new HttpClient();

        /*static async Task RunAsync()
        {
            cliente.BaseAddress = new Uri("https://api.musixmatch.com/ws/1.1/");
            cliente.DefaultRequestHeaders.Accept.Clear();
            //apikey / 
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("apikey", "9e7110145522bfa2bf3eb372b19e0ac9");

            //Indicamos el tipo de archivo devuelto
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }*/

        //Realizamos la busqueda de una cancion
        static async Task<RootObject> GetSong(string path)
        {
            //Lanzamos la petición
            string respuesta= await cliente.GetAsync(path).Result.Content.ReadAsStringAsync();
            
            //Deserializamos el JSON
            RootObject cancion = JsonSerializer.Deserialize<RootObject>(respuesta);

            return cancion;
        }

        //Realizamos la busqueda de un artista
        static async Task<RootObject> GetArtist(string path)
        {
            //Lanzamos la petición
            string respuesta = await cliente.GetAsync(path).Result.Content.ReadAsStringAsync();

            //Deserializamos el JSON
            RootObject cancion = JsonSerializer.Deserialize<RootObject>(respuesta);

            return cancion;
        }

        public RootObject cargaCancion(string parametros)
        {
            //Llamamos al método encargado de realizar la petición
            RootObject busquedaCancion = GetArtist("http://api.musixmatch.com/ws/1.1/track.search" + parametros).Result;
            Song cancion = new Song
            {
                Author = new Models.Artist
                {
                    idAuthor = busquedaCancion.message.body.track_list[0].track.artist_id,
                    Name = busquedaCancion.message.body.track_list[0].track.track_name,
                    CreationDate = busquedaCancion.message.body.track_list[0].track.
        }
            }
            
            string a = busquedaCancion.message.body.track_list[0].track.track_name;
            string b = busquedaCancion.message.body.track_list[0].track.artist_name;

            return busquedaCancion;
        }
    }
}