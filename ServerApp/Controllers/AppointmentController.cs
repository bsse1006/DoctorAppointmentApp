using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Model;
using ServerApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using ServerApp.Service;

namespace ServerApp.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly AppointmentRepository appointmentRepository = new AppointmentRepository();
        private LoggedInPatients loggedInPatients;

        public AppointmentController(LoggedInPatients loggedInPatients)
        {
            this.loggedInPatients = loggedInPatients;
        }

        [HttpPost("api/appointment/add")]
        public IActionResult AddAppointment([FromBody] Appointment appointment, string userName)
        {
            if (loggedInPatients.checkIfLoggedIn(userName))
            {
                var addedAppointment = appointmentRepository.Add(appointment);
                return Ok(addedAppointment);
            }
            else
            {
                return Ok();
            }
        }

        //security flaw
        [HttpGet("api/appointment/getById")]
        public IActionResult GetAppointmentById()//int appointmentID)
        {
            return Ok();
            /*var usertype = HttpContext.Session.GetString("usertype");
            if (usertype != null)
            {
                var appointment = appointmentRepository.GetByID(appointmentID);
                return Ok(appointment);
            }
            else
            {
                return BadRequest();
            }*/
        }

        [HttpGet("api/appointment/getByDoctorId")]
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
        [HttpGet("api/appointment/getByPatientId")]
        public IActionResult GetAppointmentByPatientId(int patientID, string userName)
        {
            if (loggedInPatients.checkIfLoggedIn(userName))
            {
                var appointments = appointmentRepository.GetByPatientID(patientID);
                return Ok(appointments);
            }
            else
            {
                return Ok();
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
        public IActionResult UpdateAppointment([FromBody] Appointment appointment, string userName)
        {
            if (loggedInPatients.checkIfLoggedIn(userName))
            {
                return Ok(appointmentRepository.Update(appointment));
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("api/appointment/delete")]
        public IActionResult DeleteAppointment(string userName, int appointmentId)
        {
            if (loggedInPatients.checkIfLoggedIn(userName))
            {
                var appointment = appointmentRepository.GetByID(appointmentId);
                appointmentRepository.Delete(appointment);
                return Ok();
            }
            else
            {
                return Ok();
            }
        }
    }
}
