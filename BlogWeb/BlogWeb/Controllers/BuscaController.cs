using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.DAO;

namespace BlogWeb.Controllers
{
    public class BuscaController : Controller
    {
        private PostDAO dao;

        public BuscaController(PostDAO dao) 
        {
            this.dao = dao;
        }

        public ActionResult BuscaPorAutor(string nomeAutor) 
        {
            return View(dao.ListaPublicadosDoAutor(nomeAutor));
        }
    }
}