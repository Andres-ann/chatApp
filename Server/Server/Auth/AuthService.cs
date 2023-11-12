using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Server.Auth
{
    public class AuthService
    {
        private List<User> _users = new List<User>();
        private readonly string _DATAPATH = @"..\..\Auth\data.json";
        public AuthService()
        {
            GetUsers();
        }

        public User ValidateUser(string userName, string password)
        {
            var user = _users.FirstOrDefault(u => u.UserName.Equals(userName));
            if (user == null)
            {
                throw new Exception("The user is incorrect");
            }
            if (user.IsValid(password))
            {
                return user;
            }
            else
            {
                throw new Exception("The password is incorrect");
            }
        }

        public void GetUsers()
        {
            string jsonString = File.ReadAllText(_DATAPATH);
            _users = JsonSerializer.Deserialize<List<User>>(jsonString);
        }

    }
}
