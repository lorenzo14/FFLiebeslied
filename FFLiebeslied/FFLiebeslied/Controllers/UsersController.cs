using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FFLiebeslied.Models;

namespace FFLiebeslied.Controllers
{
    public class UsersController : Controller
    {
        private ModelContext db = new ModelContext();

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
                    return RedirectToAction("Login", "Users");
                    
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
                    if(usuarioBD.Password.CompareTo(user.Password) == 0)
                    {
                        //La contraseña es correcta
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


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
