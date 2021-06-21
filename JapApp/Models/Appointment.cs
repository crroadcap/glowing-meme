using System;
using System.Collections.Generic;
using SQLite;

namespace JapApp.Models
{
    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
        int ID { get; set; }
        public DateTime ScheduledTime { get; set; }
        List<User> AcceptedUsers { get; set; }
        public Appointment()
        {
        }
    }
}
