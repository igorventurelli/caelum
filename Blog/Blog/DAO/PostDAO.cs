using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAO {

    public class PostDAO 
    {
        public void Adiciona(Post post) 
        {
            using(IDbConnection conexao = ConnectionFactory.CriaConexao())
            using (IDbCommand comando = conexao.CreateCommand()) 
            {
                comando.CommandText = "insert into " +
                    "posts (titulo, conteudo, dataPublicacao, publicado) " +
                    "values (@titulo, @conteudo, @dataPublicacao, @publicado)";

                IDbDataParameter paramTitulo = comando.CreateParameter();
                paramTitulo.ParameterName = "titulo";
                paramTitulo.Value = post.Titulo;
                comando.Parameters.Add(paramTitulo);

                IDbDataParameter paramConteudo = comando.CreateParameter();
                paramConteudo.ParameterName = "conteudo";
                paramConteudo.Value = post.Conteudo;
                comando.Parameters.Add(paramConteudo);

                IDbDataParameter paramData = comando.CreateParameter();
                paramData.ParameterName = "dataPublicacao";
                paramData.Value = post.DataPublicacao;
                comando.Parameters.Add(paramData);

                IDbDataParameter paramPublicado = comando.CreateParameter();
                paramPublicado.ParameterName = "publicado";
                paramPublicado.Value = post.Publicado;
                comando.Parameters.Add(paramPublicado);

                comando.ExecuteNonQuery();
            }
        }

        public IList<Post> Lista() 
        {
            using(IDbConnection conexao = ConnectionFactory.CriaConexao())
            using (IDbCommand comando = conexao.CreateCommand()) 
            {
                comando.CommandText = "select * from posts";

                IDataReader leitor = comando.ExecuteReader();
                IList<Post> posts = new List<Post>();
                while (leitor.Read()) 
                {
                    Post post = new Post();
                    post.Id = Convert.ToInt32(leitor["id"]);
                    post.Titulo = Convert.ToString(leitor["titulo"]);
                    post.Conteudo = Convert.ToString(leitor["conteudo"]);
                    if (!Convert.IsDBNull(leitor["dataPublicacao"])) 
                    {
                        post.DataPublicacao = Convert
                            .ToDateTime(leitor["dataPublicacao"]);
                    }
                    post.Publicado = Convert.ToBoolean(leitor["publicado"]);
                    posts.Add(post);
                }
                leitor.Close();
                return posts;
            }
        }
    }
}
