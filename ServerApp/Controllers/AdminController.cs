using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using ServerApp.Model;
using ServerApp.Repository;
using ServerApp.Service;

namespace ServerApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminRepository adminRepository = new AdminRepository();

        private LoggedInAdmins loggedInAdmins;
        private LoggedInPatients loggedInPatients;

        public AdminController(LoggedInAdmins loggedInAdmins, LoggedInPatients loggedInPatients)
        {
            this.loggedInAdmins = loggedInAdmins;
            this.loggedInPatients = loggedInPatients;
        }

        [HttpGet("api/admin/onlinedata")]
        public IActionResult OnlineData(string adminName)
        {
            if (loggedInAdmins.checkIfLoggedIn(adminName))
            {
                return Ok(loggedInPatients.patients);
            }
            else
            {
                return Ok();
            }
        }

        public class AdminCred
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        [HttpPost("api/admin/authenticate")]
        public IActionResult Authenticate([FromBody] AdminCred adminCred)
        {
            if (adminRepository.GetByUsername(adminCred.username) == null)
            {
                return Ok();
            }
            else
            {
                if (adminRepository.GetByUsername(adminCred.username).password == adminCred.password)
                {
                    if (!loggedInAdmins.checkIfLoggedIn(adminCred.username))
                    {
                        loggedInAdmins.AddLoggedInAdmins(adminCred.username);
                    }
                    return Ok(adminCred);
                }
                else
                {
                    return Ok();
                }
            }
        }

        [HttpGet("api/admin/signout")]
        public IActionResult SignOut(string adminName)
        {
            if (loggedInAdmins.checkIfLoggedIn(adminName))
            {
                loggedInAdmins.RemoveLoggedInAdmins(adminName);
                return Ok();
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("api/admin/getByUsername")]
        public IActionResult GetAdminByUsername(string adminName)
        {
            if (loggedInAdmins.checkIfLoggedIn(adminName))
            {
                return Ok(adminRepository.GetByUsername(adminName));
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost("api/admin/add")]
        public IActionResult AddAdmin([FromBody] Admin admin, string adminName)
        {
            if (loggedInAdmins.checkIfLoggedIn(adminName))
            {
                var addedAdmin = adminRepository.Add(admin);
                return Ok(addedAdmin);
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost("api/admin/update")]
        public IActionResult UpdateAdmin([FromBody] Admin admin, string adminName)
        {
            if (loggedInAdmins.checkIfLoggedIn(adminName))
            {
                return Ok(adminRepository.Update(admin));
            }
            else
            {
                return Ok();
            }
        }
    }
}
