using Blog.DAO;
using Blog.Models;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            ISessionFactory factory = Fluently.Configure(cfg)
                .Mappings(x => {
                    x.FluentMappings.AddFromAssembly(
                        Assembly.GetExecutingAssembly());
                }).BuildSessionFactory();
            using (ISession session = factory.OpenSession()) 
            {
                Post post = new Post();
                post.Titulo = "Post do NHibernate";
                post.Conteudo = "Conteudo do Post";
                post.DataPublicacao = DateTime.Now;
                post.Publicado = true;

                ITransaction tx = session.BeginTransaction();
                session.Save(post);
                tx.Commit();
            }
            Console.ReadLine();
        }
    }
}
