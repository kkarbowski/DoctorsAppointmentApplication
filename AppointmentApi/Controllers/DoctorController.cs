﻿using AppointmentApi.Authorization;
using AppointmentApi.Business;
using AppointmentModel;
using AppointmentModel.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Serilog;
using AppointmentApi.Filters.Action;

namespace AppointmentApi.Controllers
{
    [ServiceFilter(typeof(LoggingFilter))]
    [Route("[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorBusiness _doctorBusiness;

        public DoctorController(IDoctorBusiness doctorBusiness)
        {
            _doctorBusiness = doctorBusiness;
        }

        [Authorize(Roles = Role.Doctor_Patient)]
        [HttpGet]
        public IActionResult GetDoctors()
        {
            Log.Information("Getting information about doctors");
            var doctors = _doctorBusiness.GetDoctors();

            return Ok(doctors);
        }

        [Authorize(Roles = Role.Doctor_Patient)]
        [HttpGet("{doctorId}")]
        public IActionResult GetDoctor(int doctorId)
        {
            Log.Information("Getting information about doctor");
            var doctor = _doctorBusiness.GetDoctor(doctorId);

            return Ok(doctor);
        }

        [Authorize(Roles = Role.Doctor)]
        [HttpGet("{doctorId}/Appointment")]
        public IActionResult GetDoctorAppointments(int doctorId)
        {
            Log.Information("Getting information about doctor's appointments");
            var doctorAppointments = _doctorBusiness.GetDoctorAppointments(doctorId);

            return Ok(doctorAppointments);
        }

        [Authorize(Roles = Role.Doctor)]
        [HttpPost]
        public IActionResult AddDoctor([FromBody] Doctor doctor)
        {
            Log.Information($"Adding new doctor {doctor.FullName}");
            var newDoctor = _doctorBusiness.AddDoctor(doctor);
            if (newDoctor == null)
            {
                Log.Warning("Bad Request - doctor was not added properly");
                return BadRequest();
            }

            Log.Information("Doctor was added");
            return Created(nameof(GetDoctor), newDoctor);
        }

        [Authorize(Roles = Role.Doctor)]
        [HttpPut("{doctorId}")]
        public IActionResult UpdateDoctor(int doctorId, [FromBody] Doctor doctor)
        {
            if (doctorId != doctor.UserId)
            {
                return Forbid();
            }

            Log.Information($"Updating information about doctor {doctor.FullName}");
            var updatedDoctor = _doctorBusiness.UpdateDoctor(doctor);
            if (updatedDoctor == null)
            {
                Log.Warning("Bad Request - doctor was not updated");
                return BadRequest();
            }

            Log.Information("Doctor was updated");
            return Created(nameof(GetDoctor), updatedDoctor);
        }

    }
}
