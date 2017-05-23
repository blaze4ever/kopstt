namespace Kopstt.Data.LocalDatabase
{
    using System;
    using System.Data.SQLite;
    using System.IO;

    public class Database
    {
        private SQLiteConnection _db;
        public Database()
        {

        }

        public void dbInit(string db_name)
        {
            var db_file = $"{db_name}.sqlite";
            if (!File.Exists(db_file))
            {
                SQLiteConnection.CreateFile(db_file);
                File.SetAttributes(db_file, FileAttributes.Hidden);
            }
        }

        public void dbConnect(string db_name)
        {
            _db = new SQLiteConnection($"Data Source={db_name}.sqlite;Version=3;");
            _db.Open();
        }

        private void createTable()
        {
            var query = "create table IF NOT EXISTS highscores (name varchar(20), score int)";
            var command = new SQLiteCommand(query, _db);
            command.ExecuteNonQuery();
        }

        private void fillTable()
        {
            var query = "insert into highscores (name, score) values ('Me', 500)";
            var command = new SQLiteCommand(query, _db);
            command.ExecuteNonQuery();
            query = "insert into highscores (name, score) values ('Myself', 400)";
            command = new SQLiteCommand(query, _db);
            command.ExecuteNonQuery();
            query = "insert into highscores (name, score) values ('And I', 300)";
            command = new SQLiteCommand(query, _db);
            command.ExecuteNonQuery();
        }

        private void printHighscores()
        {
            var query = "select * from highscores order by score desc";
            var command = new SQLiteCommand(query, _db);
            var reader = command.ExecuteReader();
            while (reader.Read())

                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
                Console.ReadLine();

            _db.Close();
        }
    }
}
