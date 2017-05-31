namespace Kopstt.Core.Database.Mapping
{
    using System;
    using System.Xml.Serialization;
    using NHibernate.Mapping.ByCode;

    public class Mapper
    {
        public Mapper()
        {
            var mapper = new ModelMapper();
            mapper.AddMapping<JobMap>();

            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            var xmlSerializer = new XmlSerializer(mapping.GetType());

            xmlSerializer.Serialize(Console.Out, mapping);
        }
    }
}
