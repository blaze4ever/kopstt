namespace Kopstt.Core.Database
{
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Cfg.MappingSchema;
    using NHibernate.Mapping.ByCode;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.IO;
    using Mapping;

    public static class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static Configuration _configuration;
        private static HbmMapping _mapping;
        private const string CONNECTION_STRING = @"Data Source=kopstt.db;Pooling=true;FailIfMissing=false; BinaryGUID=false;New=false;Compress=true;Version=3";
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static Configuration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = CreateConfiguration();
                }
                return _configuration;
            }
        }

        public static HbmMapping Mapping
        {
            get
            {
                if (_mapping == null)
                {
                    _mapping = CreateMapping();
                }
                return _mapping;
            }
        }
        
        private static Configuration CreateConfiguration()
        {
            var configuration = new Configuration();
            if (!File.Exists("kopstt.db"))
            {
                SQLiteConnection.CreateFile("kopstt.db");
            }

            configuration.SetProperty("connection.connection_string", CONNECTION_STRING);
            configuration.Configure();
            configuration.AddDeserializedMapping(Mapping, null);
            return configuration;
        }

        private static HbmMapping CreateMapping()
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(new List<System.Type> { typeof(JobMap) });
            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }
    }
}
