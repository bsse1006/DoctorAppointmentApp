using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Model;
using ServerApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApp.Controllers
{
    class AppointmentController : Controller
    {
        private readonly AppointmentRepository appointmentRepository = new AppointmentRepository();

        [HttpPost("api/appointment/add")]
        public IActionResult AddAppointment([FromBody] Appointment appointment)
        {
            var usertype = HttpContext.Session.GetString("usertype");
            if (usertype == "patient")
            {
                var addedAppointment = appointmentRepository.Add(appointment);
                return Ok(addedAppointment);
            }
            else
            {
                return BadRequest();
            }
        }

        //security flaw
        [HttpGet("api/appointment/getByID")]
        public IActionResult GetAppointmentById(int appointmentID)
        {
            var usertype = HttpContext.Session.GetString("usertype");
            if (usertype != null)
            {
                var appointment = appointmentRepository.GetByID(appointmentID);
                return Ok(appointment);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("api/appointment/getByDoctorID")]
        public IActionResult GetAppointmentByDoctorId(int doctorID)
        {
            var usertype = HttpContext.Session.GetString("usertype");
            if (usertype != null)
            {
                var appointment = appointmentRepository.GetByDoctorID(doctorID);
                return Ok(appointment);
            }
            else
            {
                return BadRequest();
            }
        }

        //security flaw
        [HttpGet("api/appointment/getByPatientID")]
        public IActionResult GetAppointmentByPatientId(int patientID)
        {
            var usertype = HttpContext.Session.GetString("usertype");
            if (usertype != null)
            {
                var appointment = appointmentRepository.GetByPatientID(patientID);
                return Ok(appointment);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("api/appointment/getAll")]
        public IActionResult GetAllAppointments()
        {
            var usertype = HttpContext.Session.GetString("usertype");
            if (usertype == "admin")
            {
                return Ok(appointmentRepository.GetAll());
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("api/appointment/update")]
        public IActionResult UpdateAppointment([FromBody] Appointment appointment)
        {
            var usertype = HttpContext.Session.GetString("usertype");
            if (usertype == "patient")
            {
                return Ok(appointmentRepository.Update(appointment));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("api/appointment/delete")]
        public IActionResult DeleteAppointment(int appointmentId)
        {
            var usertype = HttpContext.Session.GetString("usertype");
            if (usertype == "patient")
            {
                var appointment = appointmentRepository.GetByID(appointmentId);
                appointmentRepository.Delete(appointment);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
