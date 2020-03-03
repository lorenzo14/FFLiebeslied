using FFLiebeslied.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FFLiebeslied.Controllers
{
    public class MainController : Controller
    {

        string TITLEPARAM = "?q_track=";
        string ARTISTPARAM = "&q_artist=";

        // GET: BusquedaCanciones
        public ActionResult BusquedaCanciones()
        {
            return View();
        }

        //POST: BusquedaCanciones
        [HttpPost]
        public ActionResult BusquedaCanciones([Bind(Include = "titulo, artista")]string titulo, string artista)
        {
            API.Api api = new API.Api();
            //Modelo de params ?q_track=buried alive&q_artist=avenged&apikey=9e7110145522bfa2bf3eb372b19e0ac9
            //APIKEY PARAMETRO &apikey=9e7110145522bfa2bf3eb372b19e0ac9

            //Realizamos la búsqueda de las canciones en la API
            Song cancion = api.cargaCancion(TITLEPARAM + titulo + ARTISTPARAM + artista);

            //Comprobamos el resultado
            if (cancion != null)
            {
                return View("cancionEncontrada");
            }
            else return View("noEncontrado");
        }
    }
}