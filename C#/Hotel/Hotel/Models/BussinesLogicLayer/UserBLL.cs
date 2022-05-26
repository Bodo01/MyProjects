using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace Hotel.Models.BusinessLogicLayer
{
    public class UserBLL
    {
        public UserBLL()
        {
            UsersList = new ObservableCollection<User>();

        }

        private HotelEntities context = new HotelEntities();
        public ObservableCollection<User> UsersList { get; set; }
        public string ErrorMessage { get; set; }

        public void AddMethod(User user)
        {
            

            if (user != null)
            {
                if (string.IsNullOrEmpty(user.name) || string.IsNullOrEmpty(user.pass_word) || string.IsNullOrEmpty(user.username))
                {
                    ErrorMessage = "You cannot create an account with empty fields!";
                }
                else
                {
                    context.Users.Add(new User()
                    {
                        username = user.username,
                        pass_word = user.pass_word,
                        name = user.name,
                        email = user.email,
                        phone_number = user.phone_number,
                        user_type = 0,
                        deleted = false
                    });
                    context.SaveChanges();
                    UsersList.Add(user);
                    ErrorMessage = "";
                }
            }
        }

        public ObservableCollection<User> GetAllUsers()
        {
            List<User> users = context.Users.ToList();
            ObservableCollection<User> result = new ObservableCollection<User>();

            foreach (User user in users)
            {
                result.Add(user);
            }

            return result;
        }

        public bool UsernameExists(string username)
        {
            List<User> users = context.Users.ToList();

            foreach (var user in users)
            {
                if (user.username.ToLower() == username.ToLower())
                {
                    return true;
                }
            }



            return false;
        }
        public User VerifyExistanceOfAnUser(string username, string password)
        {
            List<User> users = context.Users.ToList();

            foreach (var user in users)
            {
                if (user.username == username && user.pass_word == password)
                {
                    return user;
                }
            }

            return null;
        }
    }
}