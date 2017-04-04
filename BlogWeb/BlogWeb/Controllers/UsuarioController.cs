using System.Web.Mvc;
using System.Web.Security;
using BlogWeb.DAO;
using BlogWeb.Models;
using WebMatrix.WebData;

namespace BlogWeb.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioDAO usuarioDAO;

        public UsuarioController(UsuarioDAO usuarioDAO) 
        {
            this.usuarioDAO = usuarioDAO;

            if (!WebSecurity.Initialized) {
                WebSecurity.InitializeDatabaseConnection("blog", "Usuario", "Id", "Login", true);
            }
        }

        public ActionResult Index()
        {
            return View(usuarioDAO.Lista());
        }

        public ActionResult Form() 
        {
            return View();
        }

        public ActionResult Adiciona(Usuario usuario) 
        {
            if (ModelState.IsValid) 
            {
                try {
                    WebSecurity.CreateUserAndAccount(usuario.Login, usuario.Password,
                        new { Email = usuario.Email, Nome = usuario.Nome }, false);
                    return RedirectToAction("Index");
                }
                catch (MembershipCreateUserException e) {
                    return View("Form");
                }
            }
            else 
            {
                return View("Form", usuario);
            }
        }
    }
}