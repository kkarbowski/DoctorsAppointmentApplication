﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppointmentModel;
using AppointmentRazor.Services.Interfaces;

namespace AppointmentRazor.Services
{
    public class PatientsProfileService : IPatientsProfileService
    {
        private readonly HttpClient _httpClient;

        public PatientsProfileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Patient GetCurrentPatient()
        {
            return new Patient()
            {
                FirstName = "John",
                LastName = "Snow",
                Phone = "978587125",
                Mail = "john.snow@gmail.com",
                BirthDate = DateTime.Now
            };
        }
    }
}
