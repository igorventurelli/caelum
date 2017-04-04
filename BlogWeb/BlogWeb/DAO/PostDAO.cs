using System.Collections.Generic;
using BlogWeb.Models;
using NHibernate;

namespace BlogWeb.DAO 
{
    public class PostDAO 
    {
        private ISession session;

        public PostDAO(ISession session) 
        {
            this.session = session;
        }

        public IList<Post> Lista() 
        {
            string hql = "select p from Post p";
            IQuery query = session.CreateQuery(hql);
            return query.List<Post>();
        }

        public void Adiciona(Post post) 
        {
            ITransaction tx = session.BeginTransaction();
            session.Save(post);
            tx.Commit();
        }

        public void Remove(int id) 
        {
            ITransaction tx = session.BeginTransaction();
            Post p = new Post() {
                Id = id
            };
            session.Delete(p);
            tx.Commit();
        }

        public void Atualiza(Post post) 
        {
            ITransaction tx = session.BeginTransaction();
            session.Merge(post);
            tx.Commit();
        }

        public Post BuscaPorId(int id) 
        {
            return session.Get<Post>(id);
        }

        public IList<Post> ListaPublicadosDoAutor(string nomeAutor) 
        {
            string hql = "select p from Post p "
                + " where p.Autor.Nome = :nomeAutor " 
                + " and p.Publicado = true "
                + " order by p.DataPublicacao desc";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("nomeAutor", nomeAutor);
            return query.List<Post>();
        }
    }
}