using System;
using System.ComponentModel.DataAnnotations;
using BlogWeb.Models;

namespace BlogWeb.ViewModels 
{
    public class PostModel 
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public bool Publicado { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public int? AutorId { get; set; }

        public PostModel() { }

        public PostModel(Post post) 
        {
            this.Id = post.Id;
            this.Titulo = post.Titulo;
            this.Conteudo = post.Conteudo;
            this.DataPublicacao = post.DataPublicacao;
            this.Publicado = post.Publicado;
            if (post.Autor != null) 
            {
                this.AutorId = post.Autor.Id;
            }
        }

        public Post CriaPost() 
        {
            Post post = new Post() {
                Id = this.Id,
                Titulo = this.Titulo,
                Conteudo = this.Conteudo,
                Publicado = this.Publicado,
                DataPublicacao = this.DataPublicacao
            };
            if (this.AutorId != 0) 
            {
                Usuario autor = new Usuario() {
                    Id = this.AutorId.Value
                };
                post.Autor = autor;
            }
            return post;
        }
    }
}