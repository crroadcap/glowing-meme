using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JapApp.Models;
namespace JapApp.Repositories
{  
    public interface IUserRepository
    {
        event EventHandler<User> OnUserAdded;
        event EventHandler<User> OnUserDeleted;
        event EventHandler<User> OnUserUpdated;

        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
        Task<List<User>> GetAllUsers();

    }
}
