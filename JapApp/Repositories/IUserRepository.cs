using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JapApp.Models;
namespace JapApp.Repositories
{  
    public interface IUserRepository
    {
        event EventHandler<User> OnAppointmentCreated;
        event EventHandler<User> OnAppointmentOccuring;

        Task<List<User>> GetFriendsList();
        Task AddAcceptedUser(User user);
        Task UpdateAccpetedUser(User user);
        Task AddOrUpdateAcceptedUser(User user);
        Task RemoveAcceptedUser(User user);
        Task ScheduleMeeting();
    }
}
