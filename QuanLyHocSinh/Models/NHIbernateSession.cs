using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHocSinh.Models
{
    public class NHIbernateSession
    {

        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {

                    var configuration = new Configuration();
                    var configurationPath = HttpContext.Current.Server.MapPath(@"~\Config\Hibernate.cfg.xml");
                    configuration.Configure(configurationPath);
                    
                    configuration.SessionFactory().GenerateStatistics();

                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            
            return SessionFactory.OpenSession();
        }
       
    }
}