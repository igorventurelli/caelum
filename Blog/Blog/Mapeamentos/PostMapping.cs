using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Blog.Models;

namespace Blog.Mapeamentos {

    class PostMapping : ClassMap<Post>
    {
        public PostMapping() 
        {
            Id(post => post.Id).GeneratedBy.Identity();
            Map(post => post.Titulo);
            Map(post => post.Conteudo);
            Map(post => post.DataPublicacao);
            Map(post => post.Publicado);
        }
    }
}
