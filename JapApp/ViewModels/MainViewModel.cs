using System;
using System.Threading.Tasks;
using JapApp.Repositories;
using System.Windows.Input;
using JapApp.Views;
using Xamarin.Forms;

namespace JapApp.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly AppointmentRepository repository;

        public MainViewModel(AppointmentRepository repository)
        {
            this.repository = repository;
            Task.Run(async () => await LoadData());
        }

        public ICommand CreateMeeting => new Command(async () =>
        {
            var appointmentView = Resolver.Resolve<AppointmentView>();
            await Navigation.PushAsync(appointmentView);
        });

        private async Task LoadData()
        {

        }
    }
}
