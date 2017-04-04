using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.DAO;

namespace BlogWeb.Controllers
{
    public class MenuController : Controller
    {
        private UsuarioDAO dao;

        public MenuController(UsuarioDAO dao) 
        {
            this.dao = dao;
        }

        public ActionResult Index()
        {
            ViewBag.Autores = dao.Lista();
            return PartialView();
        }
    }
}