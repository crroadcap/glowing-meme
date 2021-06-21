using System;
using System.Threading.Tasks;
using JapApp.Models;
using SQLite;
using System.IO;

namespace JapApp.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public AppointmentRepository()
        {
        }

        public event EventHandler<Appointment> OnAppointmentCreated;
        public event EventHandler<Appointment> OnAppointmentDeleted;
        public event EventHandler<Appointment> OnAppointmentUpdated;

        private SQLiteAsyncConnection connection;

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
                }) ;

            }
        }

        public async Task CreateAppointment(Appointment appointment)
        {
            await CreateConnection();
            await connection.InsertAsync(appointment);
            OnAppointmentCreated?.Invoke(this, appointment);
        }

        public async Task UpdateAppointment(Appointment appointment)
        {
            await CreateConnection();
            await DeleteAppointment(appointment);
            await CreateAppointment(appointment);
            OnAppointmentUpdated?.Invoke(this, appointment);
        }

        public async Task DeleteAppointment(Appointment appointment)
        {
            await CreateConnection();
            await connection.GetAsync<Appointment>(appointment);
            OnAppointmentDeleted?.Invoke(this, appointment);
        }
    }
}
