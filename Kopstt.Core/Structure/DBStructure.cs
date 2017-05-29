using Kopstt.Core.LocatDatabase;

namespace Kopstt.Core.Structure
{
    public abstract class DBStructure
    {
        private Database _db;
        public DBStructure(Database db)
        {
            _db = db;
        }

        public abstract void CreateTable();
    }
}
