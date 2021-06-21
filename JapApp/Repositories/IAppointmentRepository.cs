using System;
using JapApp.Models;
using System.Threading.Tasks;
namespace JapApp.Repositories
{
    public interface IAppointmentRepository
    {
        event EventHandler<Appointment> OnAppointmentCreated;
        event EventHandler<Appointment> OnAppointmentUpadated;
        event EventHandler<Appointment> OnAppointmentDeleted;



        Task CreateAppointment(Appointment appointment);
        Task UpdateAppointment(Appointment appointment);
        Task DeleteAppointment(Appointment appointment);
    }
}
