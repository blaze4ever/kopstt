namespace Kopstt.Core.Database.Repositories
{
    using Models;

    public interface IJobRepository
    {
        Job Get(int id);
        void Save(Job task);
        void Update(Job task);
        void Delete(Job task);
    }
}
