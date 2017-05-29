namespace Kopstt.Core.LocalDatabase.Structure
{
    public class Tasks : DBStructure
    {
        public string CreateQuery()
        {
            if (_db == null)
            {
                return;
            }

            var query = "CREATE table IF NOT EXISTS tasks (name varchar(20), added datetime)";
            var command = new SQLiteCommand(query, _db);
            command.ExecuteNonQuery();
        }
    }
}
