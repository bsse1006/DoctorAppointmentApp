using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using ServerApp.Model;
using ServerApp.Repository;

namespace ServerApp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly DoctorRepository doctorRepository = new DoctorRepository();
        /*private readonly IHttpContextAccessor httpContextAccessor;
        private ISession session => httpContextAccessor.HttpContext.Session;

        public DoctorController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }*/

        [HttpPost("api/doctor/add")]
        public IActionResult AddDoctor([FromBody] Doctor doctor)
        {
            var usertype = HttpContext.Session.GetString("usertype");
            if (usertype == "admin")
            {
                var addedDoctor = doctorRepository.Add(doctor);
                return Ok(addedDoctor);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("api/doctor/getByID")]
        public IActionResult GetDoctorById(int doctorID)
        {
            var usertype = HttpContext.Session.GetString("usertype");
            if (usertype != null)
            {
                var doctor = doctorRepository.GetByID(doctorID);
                return Ok(doctor);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("api/doctor/getByName")]
        public IActionResult GetDoctorByName(string doctorName)
        {
            var doctor = doctorRepository.GetByName(doctorName);
            return Ok(doctor);
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
        public IActionResult GetAllDoctors()
        {
            Console.WriteLine("Session Value Out:");
            //Console.WriteLine(session.GetString("usertype"));
            return Ok(doctorRepository.GetAll());
            /*var usertype = HttpContext.Session.GetString("usertype");
            if (usertype != null)
            {
                return Ok(doctorRepository.GetAll());
            }
            else
            {
                return BadRequest();
            }*/
        }

        [HttpPost("api/doctor/update")]
        public IActionResult UpdateDoctor([FromBody] Doctor doctor)
        {
            var usertype = HttpContext.Session.GetString("usertype");
            if (usertype == "admin")
            {
                return Ok(doctorRepository.Update(doctor));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("api/doctor/delete")]
        public IActionResult DeleteDoctor(int doctorId)
        {
            var usertype = HttpContext.Session.GetString("usertype");
            if (usertype == "admin")
            {
                var doctor = doctorRepository.GetByID(doctorId);
                doctorRepository.Delete(doctor);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
