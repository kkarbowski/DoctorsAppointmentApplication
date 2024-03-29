﻿using AppointmentApi.Controllers;
using AppointmentApi.DataAccess;
using AppointmentApi.Exceptions;
using AppointmentModel.Model;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentApi.Business
{
    public class AppointmentBusiness : IAppointmentBusiness
    {
        private readonly IAppointmentDataAccess _appointmentDataAccess;

        public AppointmentBusiness(IAppointmentDataAccess appointmentDataAccess)
        {
            _appointmentDataAccess = appointmentDataAccess;
        }


        public Appointment GetAppointment(int appointmentId)
        {
            var appointment = _appointmentDataAccess.GetAppointment(appointmentId);

            if (appointment == null)
            {
                throw new EntityNotFoundException(nameof(Appointment), appointmentId);
            }

            return appointment.RemoveReferenceLoop();
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _appointmentDataAccess.GetAppointments().Select(a => a.RemoveReferenceLoop());
        }

        public Appointment AddAppointment(Appointment appointment)
        {
            try
            {
                if (!IsAppointmentDateAvailableForGivenDoctor(appointment.AppointmentDate, appointment.Doctor.UserId))
                    throw new OccupiedAppointmentDateException(appointment.AppointmentDate, appointment.Doctor.UserId);

                return _appointmentDataAccess.AddAppointment(appointment).RemoveReferenceLoop();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            try
            {
                return _appointmentDataAccess.UpdateAppointment(appointment).RemoveReferenceLoop();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Encountered an exception while trying to execute AppointmentBusiness.UpdateAppointment");
                return null;
            }
        }

        private bool IsAppointmentDateAvailableForGivenDoctor(DateTime appointmentDate, int doctorid)
        {
            var appointment = _appointmentDataAccess.GetAppointmentForSpecificDateAndDoctor(appointmentDate, doctorid);
            return appointment == null ? true : false;
        } 
    }
}
