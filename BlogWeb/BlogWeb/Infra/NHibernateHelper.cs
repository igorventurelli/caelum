using System.Reflection;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;

namespace BlogWeb.Infra 
{
    public class NHibernateHelper 
    {
        private static ISessionFactory factory = CriaSessionFactory();

        private static ISessionFactory CriaSessionFactory() {
            Configuration cfg = new Configuration();
            cfg.Configure();
            return Fluently.Configure(cfg)
                .Mappings(x => x.FluentMappings.AddFromAssembly(
                    Assembly.GetExecutingAssembly()
                    )
                 ).BuildSessionFactory();
        }

        public static ISession AbreSession() 
        {
            return factory.OpenSession();
        }
    }
}