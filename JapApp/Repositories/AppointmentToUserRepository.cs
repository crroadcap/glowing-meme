using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using JapApp.Models;
using SQLite;

namespace JapApp.Repositories
{
    public class AppointmentToUserRepository :IAppointmenttoUser
    {
        public AppointmentToUserRepository()
        {
        }

        public event EventHandler<AppointmentToUsers> OnAppointmentToUserCreated;
        public event EventHandler<AppointmentToUsers> OnAppointmentToUserUpdated;
        public event EventHandler<AppointmentToUsers> OnAppointmentToUserDeleted;

        private SQLiteAsyncConnection connection;

        private async Task CreateConnection()
        {

            if (connection == null)
            {
                return;
            }
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var databasePath = Path.Combine(documentPath, "AppointmentToUser.db");

            connection = new SQLiteAsyncConnection(databasePath);
            await connection.CreateTableAsync<AppointmentToUsers>();

            if (await connection.Table<AppointmentToUsers>().CountAsync() == 0)
            {
                await connection.InsertAsync(new Appointment()
                {
                    ScheduledTime = DateTime.Now
                });

            }
        }

      

        public async Task AddAppToUser(AppointmentToUsers apptoUser)
        {
            await CreateConnection();
            await connection.InsertAsync(apptoUser);
            OnAppointmentToUserCreated?.Invoke(this, apptoUser);
        }

        public async Task UpdateAppToUser(AppointmentToUsers apptoUser)
        {
            await CreateConnection();
            await RemoveAppToUser(apptoUser);
            await AddAppToUser(apptoUser);

            OnAppointmentToUserUpdated?.Invoke(this, apptoUser);
        }

        public async Task RemoveAppToUser(AppointmentToUsers apptoUser)
        {
            await CreateConnection();
            await connection.DeleteAsync<AppointmentToUsers>(apptoUser);
            await AddAppToUser(apptoUser);
            OnAppointmentToUserDeleted?.Invoke(this, apptoUser);
        }
    }
}
