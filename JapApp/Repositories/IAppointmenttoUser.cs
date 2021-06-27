using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JapApp.Models;

namespace JapApp.Repositories
{
    public interface IAppointmenttoUser
    {
        event EventHandler<AppointmentToUsers> OnAppointmentToUserCreated;
        event EventHandler<AppointmentToUsers> OnAppointmentToUserUpdated;
        event EventHandler<AppointmentToUsers> OnAppointmentToUserDeleted;

        Task AddAppToUser(AppointmentToUsers apptoUser);
        Task UpdateAppToUser(AppointmentToUsers apptoUser);
        Task RemoveAppToUser(AppointmentToUsers apptoUser);
        Task<List<AppointmentToUsers>> GetAllAppointmentToUsers();
    }
}
