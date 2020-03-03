using FFLiebeslied.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FFLiebeslied.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult pruebaCarga()
        {
            return View();
        }

        [HttpPost]
        public ActionResult pruebaCarga([Bind(Include = "texto")] string texto)
        {
            API.Api api = new API.Api();
            //Modelo de params ?q_track=buried alive&q_artist=avenged&apikey=9e7110145522bfa2bf3eb372b19e0ac9
            //APIKEY PARAMETRO &apikey=9e7110145522bfa2bf3eb372b19e0ac9
            Song cancion = api.cargaCancion("?q_track=buried alive&q_artist=avenged");
            return View();
        }
    }
}