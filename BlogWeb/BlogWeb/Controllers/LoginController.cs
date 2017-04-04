using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.DAO;
using BlogWeb.Models;
using WebMatrix.WebData;

namespace BlogWeb.Controllers
{
    public class LoginController : Controller
    {
        private UsuarioDAO dao;
        
        public LoginController(UsuarioDAO dao) 
        {
            this.dao = dao;

            if (!WebSecurity.Initialized) 
            {
                WebSecurity.InitializeDatabaseConnection("blog", "Usuario", "Id", "Login", true);
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(string login, string senha) 
        {
            if (WebSecurity.Login(login, senha)) 
            {
                return RedirectToAction("Index", "Post");
            }
            else 
            {
                ModelState.AddModelError("login.invalido", "Login ou senha incorretos");
                return View("Index");
            }
        }
    }
}