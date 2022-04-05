using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Hangman.Models;
using System.Collections.ObjectModel;

namespace Hangman
{
    public class DatabaseConnection
    {
        public DatabaseConnection()
        {
            

        }

        public ObservableCollection<User> getUsers()
        {
            var result = new ObservableCollection<User>();

            var cs = "Host=localhost;Username=postgres;Password=12345678;Database=Hangman";

            using var con = new NpgsqlConnection(cs);
            con.Open();
            
            string sql = "SELECT * FROM \"Users\"";
            using var cmd = new NpgsqlCommand(sql, con);

            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                result.Add(new User( rdr.GetInt32(0), rdr.GetString(1),
                        rdr.GetInt32(2)));
            }

            return result;
        }

        public bool InsertNewUser(string name, int picture)
        {
            var cs = "Host=localhost;Username=postgres;Password=12345678;Database=Hangman";

            using var con = new NpgsqlConnection(cs);
            con.Open();

            var sql = "INSERT INTO \"Users\"(name, picture_id) VALUES(@name, @picture_id)";
            using var cmd = new NpgsqlCommand(sql, con);

            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("picture_id", picture);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            return true;

        }

        public bool DeleteUserByName(string name)
        {
            var cs = "Host=localhost;Username=postgres;Password=12345678;Database=Hangman";

            using var con = new NpgsqlConnection(cs);
            con.Open();
            var sql = "DELETE FROM \"Users\" WHERE (@name)=\"name\"";
            using var cmd = new NpgsqlCommand(sql, con);

            cmd.Parameters.AddWithValue("name", name);
            
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            return true;
        }
}
}
