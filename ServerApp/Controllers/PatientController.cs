using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Model;
using ServerApp.Repository;

namespace ServerApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly PatientRepository patientRepository = new PatientRepository();

        [HttpPost("api/patient/add")]
        public IActionResult AddPatient([FromBody] Patient patient)
        {
            var addedPatient = patientRepository.Add(patient);
            return Ok(addedPatient);
        }

        [HttpGet("api/patient/getByEmail")]
        public IActionResult GetPatientByEmail(string patientEmail)
        {
            var patient = patientRepository.GetByEmail(patientEmail);
            return Ok(patient);
        }

        [HttpGet("api/patient/getByID")]
        public IActionResult GetPatientById(int patientID)
        {
            var patient = patientRepository.GetByID(patientID);
            return Ok(patient);
        }

        [HttpGet("api/patient/getAll")]
        public IActionResult GetAllPatients()
        {
            return Ok(patientRepository.GetAll());
        }

        /*[HttpPost("api/patient/update")]
        public IActionResult UpdatePatient([FromBody] Patient patient)
        {
            return Ok(patientRepository.Update(patient));
        }*/

        /*[HttpGet("api/patient/delete")]
        public IActionResult DeletePatient(int patientID)
        {
            var patient = patientRepository.GetByID(patientID);
            patientRepository.Delete(patient);
            return Ok();
        }*/
    }
}
