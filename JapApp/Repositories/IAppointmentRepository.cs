using System;
using JapApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace JapApp.Repositories
{
    public interface IAppointmentRepository
    {
        event EventHandler<Appointment> OnAppointmentCreated;
        event EventHandler<Appointment> OnAppointmentUpdated;
        event EventHandler<Appointment> OnAppointmentDeleted;



        Task CreateAppointment(Appointment appointment);
        Task UpdateAppointment(Appointment appointment);
        Task DeleteAppointment(Appointment appointment);
        Task<List<Appointment>> GetAllAppointments();
    }
}
