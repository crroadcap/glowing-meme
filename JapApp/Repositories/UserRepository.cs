using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using JapApp.Models;
using SQLite;

namespace JapApp.Repositories
{
    public class UserRepository :IUserRepository
    {
        public event EventHandler<Appointment> OnAppointmentCreated;
        public event EventHandler<Appointment> OnAppointmentDeleted;
        public event EventHandler<Appointment> OnAppointmentUpdated;

        private SQLiteAsyncConnection connection;

        public UserRepository()
        {

            

        }


        private async Task CreateConnection()
        {

            if (connection == null)
            {
                return;
            }
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var databasePath = Path.Combine(documentPath, "Appointment.db");

            connection = new SQLiteAsyncConnection(databasePath);
            await connection.CreateTableAsync<Appointment>();

            if (await connection.Table<Appointment>().CountAsync() == 0)
            {
                await connection.InsertAsync(new Appointment()
                {
                    ScheduledTime = DateTime.Now
                });

            }
        }

        public event EventHandler<User> OnUserAdded;
        public event EventHandler<User> OnUserDeleted;
        public event EventHandler<User> OnUserUpdated;

        public async Task CreateUser(User user)
        {
            await CreateConnection();
            await connection.InsertAsync(user);
            OnUserAdded?.Invoke(this, user);

        }

        public async Task DeleteUser(User user)
        {
            await CreateConnection();
            await connection.DeleteAsync(user);
            OnUserDeleted?.Invoke(this, user);
            
        }

        public async Task<List<User>> GetAllUsers()
        {
            await CreateConnection();
            return await connection.Table<User>().ToListAsync();
        }

        public async Task UpdateUser(User user)
        {
            await CreateConnection();
            await DeleteUser(user);
            await CreateUser(user);
            OnUserUpdated?.Invoke(this, user);
        }
    }
}
