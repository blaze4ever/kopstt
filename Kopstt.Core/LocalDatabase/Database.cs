
namespace Kopstt.Core.LocatDatabase
{
    using System;
    using System.Data.SQLite;
    using System.IO;

    public class Database
    {
        private SQLiteConnection _db;
        public Database()
        {
            dbConnect("test");
            createTable();
            fillTable();
            printHighscores();
        }

        public string query()
        {
            return "Sdsdsd":
        }

        public void runQuery()
        {

        }

        public void qeryReusult()
        {

        }

        public void dbInit(string db_name)
        {
            var db_file = $"{db_name}.sqlite";
            if (File.Exists(db_file))
            {
                return;
            }

                SQLiteConnection.CreateFile(db_file);
                File.SetAttributes(db_file, FileAttributes.Hidden);
            
        }

        public void dbConnect(string db_name)
        {
            if (!File.Exists($"{db_name}.sqlite"))
            {
                //MessageBox.Show("No database file");
            }
            else
            {
                _db = new SQLiteConnection($"Data Source={db_name}.sqlite;Version=3;");
                _db.Open();
            }
           
        }

        private void createTable()
        {
            if (_db == null)
            {
                return;
            }

            var query = "create table IF NOT EXISTS highscores (name varchar(20), added datetime)";
            var command = new SQLiteCommand(query, _db);
            command.ExecuteNonQuery();
        }

        private void fillTable()
        {
            if (_db != null)
            {
                var query = $"insert into highscores (name, added) values ('Me', '{DateTime.Now}')";
                var command = new SQLiteCommand(query, _db);
                command.ExecuteNonQuery();
                query = $"insert into highscores (name, added) values ('Myself', '{DateTime.Now}')";
                command = new SQLiteCommand(query, _db);
                command.ExecuteNonQuery();
                query = $"insert into highscores (name, added) values ('And I', '{DateTime.Now}')";
                command = new SQLiteCommand(query, _db);
                command.ExecuteNonQuery();
            }
        }

        private void printHighscores()
        {
            if (_db != null)
            {
                var query = "select * from highscores order by added desc";
                var command = new SQLiteCommand(query, _db);
                var reader = command.ExecuteReader();
                while (reader.Read())

                    Console.WriteLine("Name: " + reader[0] + "\tScore: " + Convert.ToDateTime(reader[1]));
                Console.ReadLine();

                _db.Close();
            }
        }
    }
}
