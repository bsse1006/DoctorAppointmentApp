using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Model;
using ServerApp.Repository;

namespace ServerApp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly DoctorRepository doctorRepository = new DoctorRepository();

        [HttpPost("api/doctor/add")]
        public IActionResult AddDoctor([FromBody] Doctor doctor)
        {
            var addedDoctor = doctorRepository.Add(doctor);
            return Ok(addedDoctor);
        }

        [HttpGet("api/doctor/getByID")]
        public IActionResult GetDoctorById(int doctorID)
        {
            var doctor = doctorRepository.GetByID(doctorID);
            return Ok(doctor);
        }

        [HttpGet("api/doctor/getByName")]
        public IActionResult GetDoctorByName(string doctorName)
        {
            var doctor = doctorRepository.GetByName(doctorName);
            return Ok(doctor);
        }

        [HttpGet("api/doctor/getAll")]
        public IActionResult GetAllDoctors()
        {
            return Ok(doctorRepository.GetAll());
        }

        [HttpPost("api/doctor/update")]
        public IActionResult UpdateDoctor([FromBody] Doctor doctor)
        {
            return Ok(doctorRepository.Update(doctor));
        }

        [HttpGet("api/doctor/delete")]
        public IActionResult DeleteDoctor(int doctorId)
        {
            var doctor = doctorRepository.GetByID(doctorId);
            doctorRepository.Delete(doctor);
            return Ok();
        }
    }
}
