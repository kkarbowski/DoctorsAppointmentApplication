﻿using AppointmentApi.Database;
using AppointmentModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentApi.DataAccess
{
    public class AppointmentDataAccess : IAppointmentDataAccess
    {
        private readonly AppDbContext _appDbContext;

        public AppointmentDataAccess(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Appointment GetAppointment(int appointmentId)
        {
            return _appDbContext.Appointments.Find(appointmentId);
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _appDbContext.Appointments.ToList();
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            _appDbContext.Patients.Attach(appointment.Patient);
            _appDbContext.Doctors.Attach(appointment.Doctor);
            
            var newAppointment = _appDbContext.Appointments.Update(appointment);
            _appDbContext.SaveChanges();

            return newAppointment.Entity;
        }
    }
}