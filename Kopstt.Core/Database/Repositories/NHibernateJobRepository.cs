using System.Windows.Forms;

namespace Kopstt.Core.Database.Repositories
{
    using System;
    using Models;
    using NHibernate;

    public class NHibernateJobRepository : IJobRepository
    {
        private bool completed;

        public void Delete(Job job)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(job);
                transaction.Commit();
            }
        }

        public Job Get(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Job>(id);
            }
        }

        public void Save(Job job)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(job);
                transaction.Commit();

                if (transaction.WasCommitted)
                {
                    completed = true;
                }
                else
                {
                    completed = false;
                }
                
            }
        }

        public void Update(Job job)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(job);
                transaction.Commit();
            }
        }

        public bool IsProcessed()
        {
            return completed;
        }
    }
}
