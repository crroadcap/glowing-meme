using System;
using System.Collections.Generic;
using SQLite;
using JapApp.Repositories;

namespace JapApp.Models
{
    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
        int ID { get; set; }
        public DateTime ScheduledTime { get; set; }
        public List<User> AcceptedUsers { get; set; }
        public User Poster { get; set; }
        public Appointment()
        {

        }
    }
}
