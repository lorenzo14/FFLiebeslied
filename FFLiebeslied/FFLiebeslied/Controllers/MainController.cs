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
        //Parametros de búsqueda para la API
        string TITLEPARAM = "?q_track=";
        string ARTISTPARAM = "&q_artist=";

        //Variables para controlar los login
        static bool logged;
        static User User;
        static Disc Disc;

        private ModelContext db = new ModelContext();

        public ActionResult Index()
        {
            if(User != null) ViewBag.nombre = User.Username;
            return View();
        }

        public ActionResult About()
        {
            if (User != null) ViewBag.nombre = User.Username;
            return View();
        }

        public ActionResult Servicios()
        {
            if (User != null) ViewBag.nombre = User.Username;
            return View();
        }

        
        //Vistas de la API
        #region VISTAS API


        // GET: BusquedaCanciones
        public ActionResult BusquedaCanciones()
        {
            if (logged)
            {
                ViewBag.nombre = User.Username;
                return View();
            }

            else return RedirectToAction("Login","Main");
        }

        //POST: BusquedaCanciones
        [HttpPost]
        public ActionResult BusquedaCanciones([Bind(Include = "titulo, artista")]string titulo, string artista)
        {
            //Comprobamos que se haya metido titulo
           if(titulo.Trim().CompareTo("") != 0)
            {
                API.Api api = new API.Api();
                //Modelo de params ?q_track=buried alive&q_artist=avenged&apikey=9e7110145522bfa2bf3eb372b19e0ac9
                //APIKEY PARAMETRO &apikey=9e7110145522bfa2bf3eb372b19e0ac9

                //Realizamos la búsqueda de las canciones en la API
                Song cancion = api.cargaCancion(TITLEPARAM + titulo + ARTISTPARAM + artista);

                //Comprobamos el resultado
                if (cancion != null)
                {
                    ViewBag.nombre = User.Username;
                    return View("cancionEncontrada", cancion);
                }
                else return View("noEncontrado");
            }

            else
            {
                ViewBag.mensajeTitulo = "Debe introducirse un titulo";
                return View();
            }
            
        }
        #endregion

        //GET: GuardarCancion
        public ActionResult GuardarCancion()
        {
            //Recibimos los datos de la cancion
            Song cancion = (Song) TempData["cancion"];
            User.Disc.Songs.Add(cancion);
            return RedirectToAction("Index");
        }

        // GET: BusquedaCanciones
        public ActionResult MiDisco()
        {
            ViewBag.nombre = User.Username;
            ViewBag.canciones = User.Disc.Songs;
            return View();
        }

        //POST: MiDisco
        //Borrar canciones
        [HttpPost]
        public ActionResult MiDisco([Bind(Include = "posCancion")]int posCancion)
        {
            User.Disc.Songs.RemoveAt(posCancion);

            return RedirectToAction("MiDisco");
        }

        #region Cuentas
        #region REGISTER
        // GET: Users/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Users/Register
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "UserID,Username,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Comprobamos si el usuario ya existe
                    var usuarioBD = db.Users.First(x => x.Username == user.Username);

                    //Existe
                    return RedirectToAction("ErrorRegister");

                }

                //No existe
                catch
                {
                    //Asginamos el disco al usuario
                    user.Disc = new Disc();

                    //Grabamos el usuario
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Main");

                }


            }

            return View(user);
        }

        public ActionResult ErrorRegister()
        {
            //Mensaje de error a mostrar
            ViewBag.mensaje = "El nombre de usuario especificado ya está en uso";
            return View();
        }

        #endregion

        #region LOGIN
        // GET: Users/Login
        public ActionResult Login()
        {
            return View();
        }


        //POST: Users/login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "UserID,Username,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuarioBD = db.Users.First(x => x.Username == user.Username);

                    //Existe
                    if (usuarioBD.Password.CompareTo(user.Password) == 0)
                    {
                        //La contraseña es correcta
                        logged = true;
                        User = user;
                        Disc disc = new Disc();
                        disc.Songs = new List<Song>();
                        user.Disc = disc;

                        return RedirectToAction("Index", "Main");
                    }
                }

                //No existe
                catch
                {
                    return RedirectToAction("ErrorLogin");
                }
            }

            //Contraseña incorrecta
            return View(user);
        }

        public ActionResult ErrorLogin()
        {
            //Mensaje de error a mostrar
            ViewBag.mensaje = "El usuario especificado no existe";
            return View();
        }

        #endregion

        public ActionResult CierreSesion()
        {
            logged = false;
            User = null;
            return RedirectToAction("Index", "Main");
        }
        #endregion
    }
}