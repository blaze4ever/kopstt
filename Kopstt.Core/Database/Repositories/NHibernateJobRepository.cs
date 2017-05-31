namespace Kopstt.Core.Database.Repositories
{
    using Models;
    using NHibernate;

    public class NHibernateJobRepository : IJobRepository
    {
        public void Delete(Job product)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(product);
                transaction.Commit();
            }
        }

        public Job Get(long id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Job>(id);
            }
        }

        public void Save(Job product)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(product);
                transaction.Commit();
            }
        }

        public void Update(Job product)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(product);
                transaction.Commit();
            }
        }
    }
}
