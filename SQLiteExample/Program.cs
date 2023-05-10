using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

/*DROP TABLE Person;
INSERT INTO Person(name, age) VALUES('Bill', 21);
SELECT* FROM Person;
DELETE FROM Person WHERE name like '%Bill%';*/
namespace SQLiteExample
{
    internal class Program
    {
        static void addData(string name, int age)
        {
            SQLiteConnection connection = new SQLiteConnection(@"Data Source = test.db;");
            connection.Open();
            var query = @"CREATE TABLE IF NOT EXISTS Person(
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        name NVARCHAR,
                        age INT);" + $"\nINSERT INTO Person(name, age) VALUES ('{name}', {age});";
            Console.WriteLine(query);
            var cmd = new SQLiteCommand(query, connection);
            cmd.ExecuteNonQuery();
           /* query = $"INSERT INTO Person(name, age) VALUES ('{name}', {age});";
            cmd = new SQLiteCommand(query, connection);
            cmd.ExecuteNonQuery();*/
            connection.Close();
            //Console.WriteLine("Создана таблица");
        }
        static void Main(string[] args)
        {
            addData("Frodo Baggings", 19);
        }
    }
}
