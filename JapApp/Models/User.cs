using System;
using System.Collections;
using System.Collections.Generic;
using SQLite;

namespace JapApp.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get;  set; }
        public List<User> FriendsList { get;  set; }
        public DateTime DesiredTime { get; set; }

        public User()
        {
            this.Email = "TestEmail";
        }
    }
}
