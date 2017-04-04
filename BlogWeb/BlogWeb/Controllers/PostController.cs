using System.Web.Mvc;
using BlogWeb.Business.Validation;
using BlogWeb.DAO;
using BlogWeb.Filters;
using BlogWeb.ViewModels;

namespace BlogWeb.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        PostDAO postDAO;
        UsuarioDAO usuarioDAO;

        public PostController(PostDAO postDAO, UsuarioDAO usuarioDAO)
        {
            this.postDAO = postDAO;
            this.usuarioDAO = usuarioDAO;
        }

        [Route("posts")]
        public ActionResult Index()
        {
            return View(postDAO.Lista());
        }

        public ActionResult Form() 
        {
            ViewBag.Usuarios = usuarioDAO.Lista();
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(PostModel viewModel) 
        {
            PostValidation.Validate(viewModel, ModelState);

            if (!ModelState.IsValid) 
            {
                ViewBag.Usuarios = usuarioDAO.Lista();
                return View("Form", viewModel);
            }
            postDAO.Adiciona(viewModel.CriaPost());
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id) 
        {
            postDAO.Remove(id);
            return RedirectToAction("Index");
        }

        [Route("posts/{id}")]
        public ActionResult Visualiza(int id) 
        {
            ViewBag.Usuarios = usuarioDAO.Lista();
            return View(new PostModel(postDAO.BuscaPorId(id)));
        }

        public ActionResult Altera(PostModel viewModel) 
        {
            //PostValidation.Validate(post, ModelState);

            if (!ModelState.IsValid) 
            {
                ViewBag.Usuarios = usuarioDAO.Lista();
                return View("Visualiza", viewModel);
            }
            postDAO.Atualiza(viewModel.CriaPost());
            return RedirectToAction("Index");
        }
    }
}