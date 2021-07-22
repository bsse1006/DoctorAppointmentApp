using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using ServerApp.Model;
using ServerApp.Repository;
using ServerApp.Service;

namespace ServerApp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly DoctorRepository doctorRepository = new DoctorRepository();
        private LoggedInAdmins loggedInAdmins;
        private LoggedInPatients loggedInPatients;

        public DoctorController(LoggedInAdmins loggedInAdmins, LoggedInPatients loggedInPatients)
        {
            this.loggedInAdmins = loggedInAdmins;
            this.loggedInPatients = loggedInPatients;
        }

        [HttpPost("api/doctor/add")]
        public IActionResult AddDoctor([FromBody] Doctor doctor, string adminName)
        {
            if (loggedInAdmins.checkIfLoggedIn(adminName))
            {
                var addedDoctor = doctorRepository.Add(doctor);
                return Ok(addedDoctor);
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("api/doctor/getById")]
        public IActionResult GetDoctorById(string userName, int doctorId)
        {
            if (loggedInAdmins.checkIfLoggedIn(userName) || loggedInPatients.checkIfLoggedIn(userName))
            {
                var doctor = doctorRepository.GetByID(doctorId);
                //Console.WriteLine(doctor.name);
                return Ok(doctor);
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("api/doctor/getByName")]
        public IActionResult GetDoctorByName()//string doctorName)
        {
            return Ok();
            /*var doctor = doctorRepository.GetByName(doctorName);
            return Ok(doctor);*/
            /*var usertype = HttpContext.Session.GetString("usertype");
            if (usertype != null)
            {
                var doctor = doctorRepository.GetByName(doctorName);
                return Ok(doctor);
            }
            else
            {
                return BadRequest();
            }*/
        }

        [HttpGet("api/doctor/getAll")]
        public IActionResult GetAllDoctors(string userName)
        {
            if (loggedInAdmins.checkIfLoggedIn(userName) || loggedInPatients.checkIfLoggedIn(userName))
            {
                return Ok(doctorRepository.GetAll());
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost("api/doctor/update")]
        public IActionResult UpdateDoctor([FromBody] Doctor doctor, string adminName)
        {
            if (loggedInAdmins.checkIfLoggedIn(adminName))
            {
                return Ok(doctorRepository.Update(doctor));
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("api/doctor/delete")]
        public IActionResult DeleteDoctor(string adminName, int doctorId)
        {
            if (loggedInAdmins.checkIfLoggedIn(adminName))
            {
                var doctor = doctorRepository.GetByID(doctorId);
                doctorRepository.Delete(doctor);
                return Ok();
            }
            else
            {
                return Ok();
            }
        }
    }
}
