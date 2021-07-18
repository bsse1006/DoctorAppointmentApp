using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Model;
using ServerApp.Repository;

namespace ServerApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly PatientRepository patientRepository = new PatientRepository();

        [HttpPost("api/patient/authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            if (patientRepository.GetByEmail(userCred.email)==null)
            {
                return Ok();
            }
            else
            {
                if (patientRepository.GetByEmail(userCred.email).password == userCred.password)
                {
                    HttpContext.Session.SetString("usertype", "patient");
                    return Ok(userCred);
                }
                else
                {
                    return Ok();
                }  
            }
        }

        public class UserCred
        {
            public string email { get; set; }
            public string password { get; set; }
        }

        [HttpPost("api/patient/add")]
        public IActionResult AddPatient([FromBody] Patient patient)
        {
            var addedPatient = patientRepository.Add(patient);
            return Ok(addedPatient);
        }

        [HttpGet("api/patient/getByEmail")]
        public IActionResult GetPatientByEmail(string patientEmail)
        {
            var usertype = HttpContext.Session.GetString("usertype");
            if (usertype!=null)
            {
                var patient = patientRepository.GetByEmail(patientEmail);
                return Ok(patient);
            }
            else
            {
                return Ok();
            }
        }

        //security flaw
        [HttpGet("api/patient/getByID")]
        public IActionResult GetPatientById(int patientID)
        {
            var usertype = HttpContext.Session.GetString("usertype");
            if (usertype != null)
            {
                var patient = patientRepository.GetByID(patientID);
                return Ok(patient);
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("api/patient/getAll")]
        public IActionResult GetAllPatients()
        {
            var usertype = HttpContext.Session.GetString("usertype");
            if (usertype == "admin")
            {
                return Ok(patientRepository.GetAll());
            }
            else
            {
                return Ok();
            }
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
