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
        string APIKEY = "&apikey=9e7110145522bfa2bf3eb372b19e0ac9";

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

        #region MetodosAPI
        //Método que realiza la petición para obtener una canción
        static async Task<ApiSong.RootObject> GetSong(string path)
        {
            //Lanzamos la petición
            string respuesta = await cliente.GetAsync(path).Result.Content.ReadAsStringAsync();

            //Deserializamos el JSON
            ApiSong.RootObject cancion = JsonSerializer.Deserialize<ApiSong.RootObject>(respuesta);

            return cancion;
        }

        //Método que realiza la petición para obtener un artista
        static async Task<ApiArtist.RootObject> GetArtist(string path)
        {
            //Lanzamos la petición
            string respuesta = await cliente.GetAsync(path).Result.Content.ReadAsStringAsync();

            //Deserializamos el JSON
            ApiArtist.RootObject artista = JsonSerializer.Deserialize<ApiArtist.RootObject>(respuesta);

            return artista;
        }

        //Método que realiza la petición para obtener la letra de una canción
        static async Task<ApiLyrics.RootObject> GetLyrics(string path)
        {
            //Lanzamos la petición
            string respuesta = await cliente.GetAsync(path).Result.Content.ReadAsStringAsync();

            //Deserializamos el JSON
            ApiLyrics.RootObject letra = JsonSerializer.Deserialize<ApiLyrics.RootObject>(respuesta);

            return letra;
        }
        #endregion

        #region MetodosNormales
        //Método que lee una canción
        public Song cargaCancion(string parametros)
        {
            //Llamamos al método encargado de realizar la petición
            ApiSong.RootObject busquedaCancion = GetSong("https://api.musixmatch.com/ws/1.1/track.search" + parametros + APIKEY).Result;

            //Comprobamos que se haya encontrado alguna canción
            if (busquedaCancion.message.body.track_list.Count > 0)
            {
                string letra = "", genero = "";

                if (busquedaCancion.message.body.track_list[0].track.has_lyrics == 1)
                {
                    //Buscamos la letra para esta cancion
                    letra = cargaLetra(busquedaCancion.message.body.track_list[0].track.track_id);
                }

                //Obtenemos el género
                if(busquedaCancion.message.body.track_list[0].track.primary_genres.music_genre_list.Count > 0)
                {
                    genero = busquedaCancion.message.body.track_list[0].track.primary_genres.music_genre_list[0].music_genre.music_genre_name;
                }

                //Obtenemos el artista
                Artist artista = cargaArtista(busquedaCancion.message.body.track_list[0].track.artist_name);


                //Calculamos el precio de la cancion
                double precio = ((double)busquedaCancion.message.body.track_list[0].track.track_rating * (double)artista.Rating) / 100;
                if (precio < 0) precio = precio * -1;
                precio = precio / 10.5;
                precio = Math.Round(precio, 2);


                //Creamos la canción con los datos buscados
                Song cancion = new Song
                {
                    idSong = busquedaCancion.message.body.track_list[0].track.track_id,
                    Title = busquedaCancion.message.body.track_list[0].track.track_name,
                    Disc = busquedaCancion.message.body.track_list[0].track.album_name,
                    Genre = genero,
                    Lyrics = letra.Replace("(1409619217113)", ""),
                    Author = artista,
                    Price = precio
                    //CALCULAR PRECIO
                };

                return cancion;
            }

            else return null;
            
        }

        //Método que lee la letra de una canción
        public string cargaLetra(int idCancion)
        {
            ApiLyrics.RootObject busquedaLetra = GetLyrics("https://api.musixmatch.com/ws/1.1/track.lyrics.get?track_id=" + idCancion + APIKEY).Result;
            return busquedaLetra.message.body.lyrics.lyrics_body;
        }

        //Método que lee un artista
        public Artist cargaArtista(string autor)
        {
            //Llamamos al método encargado de realizar la petición
            ApiArtist.RootObject busquedaArtista = GetArtist("https://api.musixmatch.com/ws/1.1/artist.search?q_artist=" + autor + APIKEY).Result;

            Artist artista = new Artist
            {
                idAuthor = busquedaArtista.message.body.artist_list[0].artist.artist_id,
                Name = busquedaArtista.message.body.artist_list[0].artist.artist_name,
                Country = busquedaArtista.message.body.artist_list[0].artist.artist_country,
                Rating = busquedaArtista.message.body.artist_list[0].artist.artist_rating
            };

            return artista;
        }
        #endregion
    }
}