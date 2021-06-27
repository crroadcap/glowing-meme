using System;
using JapApp.Models;

namespace JapApp.ViewModels
{
    public class AppointmentViewModel : ViewModel
    {

        public Appointment Appointment { get; set; }
        public User Poster { get; set; }
        

        public AppointmentViewModel()
        {
           
        }
    }
}
