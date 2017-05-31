namespace Kopstt.Core.Database.Mapping
{
    using Models;
    using NHibernate.Mapping.ByCode;
    using NHibernate.Mapping.ByCode.Conformist;

    public class JobMap : ClassMapping<Job>
    {
        public JobMap()
        {
            Id(x => x.id, map => { map.Column("ID"); map.Generator(Generators.Assigned); });
            Property(x => x.name);
            Property(x => x.category);
            Property(x => x.added);
            Property(x => x.execution);
            Property(x => x.priority);
            Property(x => x.done);
            Property(x => x.archived);
        }
    }
}
