using News.Logic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace News.Logic.Manager
{
    public class UserManager
    {
        //3. Create UserManager with method Register(string username, string email, string password) :
        public void Register(string username, string email, string password)
        {
            using (var db = new NewsDatabase())
            {
                if (String.IsNullOrEmpty(username))
                {
                    throw new LogicException("Title can't be empty!");
                }
                var sameUsername = db.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());
                //3.1. Check if there isn't a user with the same username already
                if (sameUsername != null)
                {
                    throw new LogicException("This username is already taken. Please choose a different one.");
                }
                //3.2. Check if there isn't a user with the same e-mail already
                sameUsername = db.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
                if (sameUsername != null)
                {
                    throw new LogicException("This email is already in use, please choose a different email.");
                }

                //3.3. (Optional) Check if password is at least 6 symbols
                //var longEmail = db.Users.Where(u => u.Email.Length >= 6);
                if (!password.IsPasswordOk())
                {
                    throw new LogicException("The email must be at least 6 characters long!");
                }
                //3.4. Add user if all OK
                db.Users.Add(new Users()
                {
                    Username = username,
                    Email = email,
                    Password = password
                });

                db.SaveChanges();
            }

        }
        public Users GetUser(string username, string password)
        {
            using (var db = new NewsDatabase())
            {
               return db.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower() && u.Password == password);
            }
        }
        
    }
}
