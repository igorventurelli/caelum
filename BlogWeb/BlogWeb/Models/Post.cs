using System;
using System.ComponentModel.DataAnnotations;

namespace BlogWeb.Models 
{
    public class Post 
    {
        public virtual int Id { get; set; }
        [Required(ErrorMessage = "Título não pode ser nulo")]
        [StringLength(20)]
        public virtual string Titulo { get; set; }
        [Required(ErrorMessage = "Conteúdo não pode ser nulo")]
        public virtual string Conteudo { get; set; }
        public virtual DateTime? DataPublicacao { get; set; }
        public virtual bool Publicado { get; set; }
        public virtual Usuario Autor { get; set; }
    }
}