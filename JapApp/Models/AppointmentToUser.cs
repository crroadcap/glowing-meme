using System;
using System.Collections.Generic;
using SQLite;

namespace JapApp.Models
{
    public class AppointmentToUsers
    {
        [PrimaryKey, AutoIncrement]
        public int ID { set; get; }
        public Dictionary<Appointment, List<User>> map { get; set; }
        public AppointmentToUsers()
        {
        }
    }
}
