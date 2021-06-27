using System;
using JapApp.Repositories;
using JapApp.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace JapApp.ViewModels
{
    public class AppointmentListViewModel : ViewModel
    {
        private readonly AppointmentRepository repository;
        public AppointmentListViewModel(AppointmentRepository repository)
        {
            this.repository = repository;
        }
    }
}
