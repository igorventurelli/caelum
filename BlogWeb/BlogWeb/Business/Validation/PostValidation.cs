using System.Web.Mvc;
using BlogWeb.ViewModels;

namespace BlogWeb.Business.Validation 
{
    public static class PostValidation 
    {
        public static void Validate(PostModel viewModel, ModelStateDictionary modelState) 
        {
            if (viewModel.Publicado && viewModel.DataPublicacao == null) 
            {
                modelState.AddModelError("data", "Se for publicado, a dara precisa não pode ser nula");
            }
        }
    }
}