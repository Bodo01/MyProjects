using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Hangman.Models;
using System.Collections.ObjectModel;
using System.Windows;

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

        public bool DeleteUserByName(User user)
        {
            var cs = "Host=localhost;Username=postgres;Password=12345678;Database=Hangman";
            var sql = "DELETE FROM \"Users\" WHERE (@name)=\"name\"";

            using var con3 = new NpgsqlConnection(cs);
            con3.Open();
            sql = "DELETE FROM \"Games\" WHERE (@name)=\"user_id\"";
            using var cmd3 = new NpgsqlCommand(sql, con3);

            cmd3.Parameters.AddWithValue("name", user.Id);

            cmd3.Prepare();

            cmd3.ExecuteNonQuery();
            con3.Close();

            using var con2 = new NpgsqlConnection(cs);
            con2.Open();
            sql = "DELETE FROM \"Statistics\" WHERE (@name)=\"user_name\"";
            using var cmd2 = new NpgsqlCommand(sql, con2);

            cmd2.Parameters.AddWithValue("name", user.Name);

            cmd2.Prepare();

            cmd2.ExecuteNonQuery();
            con2.Close();

            sql = "DELETE FROM \"Users\" WHERE (@name)=\"name\"";

            using var con = new NpgsqlConnection(cs);
            con.Open();
            
            using var cmd = new NpgsqlCommand(sql, con);

            cmd.Parameters.AddWithValue("name", user.Name);
            
            cmd.Prepare();

            cmd.ExecuteNonQuery();
            con.Close();
            

           

            


            return true;
        }

        public ObservableCollection<Category> GetCategories()
        {
            var categories = new ObservableCollection<Category>();

            var cs = "Host=localhost;Username=postgres;Password=12345678;Database=Hangman";

            using var con = new NpgsqlConnection(cs);
            con.Open();

            string sql = "SELECT * FROM \"Categories\"";
            using var cmd = new NpgsqlCommand(sql, con);

            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                categories.Add(new Category(rdr.GetInt32(0), rdr.GetString(1)));
            }

            con.Close();
            
            for (int i=0;i<categories.Count;i++)
            {
                using var con2 = new NpgsqlConnection(cs);
                con2.Open();

                sql = "SELECT \"word_content\" FROM \"Words\" WHERE (@id)=\"category_id\"";

                using var cmd2 = new NpgsqlCommand(sql, con2);

                cmd2.Parameters.AddWithValue("id", categories[i].Id);
               
                cmd2.Prepare();

                cmd2.ExecuteNonQuery();

                using NpgsqlDataReader rdr2 = cmd2.ExecuteReader();

                while (rdr2.Read())
                {
                    categories[i].Words.Add(rdr2.GetString(0));
                }

            }

            return categories;
        }

        public void UploadGameToDB(Game game)
        {
            var cs = "Host=localhost;Username=postgres;Password=12345678;Database=Hangman";

            using var con = new NpgsqlConnection(cs);
            con.Open();

            if (game.GameId == 0)
            {
                var sql = "INSERT INTO \"Games\"(user_id, time_left, lives_left, level_game, word, guessed_word, categories_name,game_name) VALUES(@user_id, @time_left,@lives_left,@level_game,@word,@guessed_word,@categories_name,@game_name)";
                using var cmd = new NpgsqlCommand(sql, con);

                cmd.Parameters.AddWithValue("user_id", game.UserId);
                cmd.Parameters.AddWithValue("time_left", game.TimeLeft);
                cmd.Parameters.AddWithValue("lives_left", game.LivesLeft);
                cmd.Parameters.AddWithValue("level_game", game.Level);
                cmd.Parameters.AddWithValue("word", game.Word);
                cmd.Parameters.AddWithValue("guessed_word", game.GuessedWord.ToString());
                cmd.Parameters.AddWithValue("categories_name", game.CategoryName);
                cmd.Parameters.AddWithValue("game_name", game.Name);
                cmd.Prepare();

                cmd.ExecuteNonQuery();


            }
            else
            {
                var sql = "UPDATE \"Games\" SET user_id=@user_id, time_left=@time_left, lives_left=@lives_left, level_game=@level_game, word=@word, guessed_word=@guessed_word, categories_name=@categories_name,game_name=@game_name WHERE (@game_id)=\"game_id\"";
                using var cmd = new NpgsqlCommand(sql, con);

                cmd.Parameters.AddWithValue("user_id", game.UserId);
                cmd.Parameters.AddWithValue("time_left", game.TimeLeft);
                cmd.Parameters.AddWithValue("lives_left", game.LivesLeft);
                cmd.Parameters.AddWithValue("level_game", game.Level);
                cmd.Parameters.AddWithValue("word", game.Word);
                cmd.Parameters.AddWithValue("guessed_word", game.GuessedWord.ToString());
                cmd.Parameters.AddWithValue("categories_name", game.CategoryName);
                cmd.Parameters.AddWithValue("game_name", game.Name);
                cmd.Prepare();

                cmd.ExecuteNonQuery();




            }

        }

        public ObservableCollection<Game> GetUserGames(int userId)
        {
            var games = new ObservableCollection<Game>();

            var cs = "Host=localhost;Username=postgres;Password=12345678;Database=Hangman";

            using var con = new NpgsqlConnection(cs);
            con.Open();

            string sql = "SELECT * FROM \"Games\" WHERE (@userid)=\"user_id\"";
            using var cmd = new NpgsqlCommand(sql, con);

            cmd.Parameters.AddWithValue("userid", userId);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                games.Add(new Game(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8)));
            }

            return games;
        }

        public void UpdateStatistics(User user,string categories,bool isWon)
        {
            string[] split = categories.Split(',');
            //   List<string> categoryList = new List<string>(split);

            var cs = "Host=localhost;Username=postgres;Password=12345678;Database=Hangman";

            using var con = new NpgsqlConnection(cs);

            con.Open();
            for (int i=0;i<split.Length;i++)
            {
                
                var sql = "SELECT FROM \"Statistics\" WHERE (@user_name)=\"user_name\" AND (@categ_name)=\"category_name\"";
                using var cmd = new NpgsqlCommand(sql, con);

                cmd.Parameters.AddWithValue("user_name", user.Name);
                cmd.Parameters.AddWithValue("categ_name",split[i]);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                
                if (rdr.Read())
                {
                    using var con1 = new NpgsqlConnection(cs);

                    con1.Open();

                    if (isWon == true)
                        sql = "UPDATE \"Statistics\" SET won = won+1 WHERE (@user_name)=\"user_name\" AND (@categ_name)=\"category_name\"";
                    else sql= "UPDATE \"Statistics\" SET lost = lost+1 WHERE (@user_name)=\"user_name\" AND (@categ_name)=\"category_name\"";

                    using var cmd2 = new NpgsqlCommand(sql, con1);

                    cmd2.Parameters.AddWithValue("user_name", user.Name);
                    cmd2.Parameters.AddWithValue("categ_name", split[i]);

                    cmd2.Prepare();

                    cmd2.ExecuteNonQuery();
                    con1.Close();
                }
                else
                {
                    if (isWon == true)
                  
                    sql = "INSERT INTO \"Statistics\"(user_name, category_name, won) VALUES(@user_name, @categ_name,1)";
                    else sql = "INSERT INTO \"Statistics\"(user_name, category_name, lost) VALUES(@user_name, @categ_name,1)";

                    using var con1 = new NpgsqlConnection(cs);

                    con1.Open();

                    using var cmd2 = new NpgsqlCommand(sql, con1);

                    cmd2.Parameters.AddWithValue("user_name", user.Name);
                    cmd2.Parameters.AddWithValue("categ_name", split[i]);

                    cmd2.Prepare();

                    cmd2.ExecuteNonQuery();

                    con1.Close();

                }

            }

        }

        public ObservableCollection<Statistics> GetStatistics()
        {
            var statisticsList = new ObservableCollection<Statistics>();

            var cs = "Host=localhost;Username=postgres;Password=12345678;Database=Hangman";

            using var con = new NpgsqlConnection(cs);
            con.Open();

            string sql = "SELECT * FROM \"Statistics\"";
            using var cmd = new NpgsqlCommand(sql, con);

            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                var aux = new Statistics();

                aux.Name = rdr.GetString(0);
                aux.CategoryName = rdr.GetString(1);
                aux.Won = rdr.GetInt32(2);
                aux.Lost = rdr.GetInt32(3);
                  statisticsList.Add(aux);
            }

            return statisticsList;
        }
    }
}