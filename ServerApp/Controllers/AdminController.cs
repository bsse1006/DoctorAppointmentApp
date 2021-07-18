using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using ServerApp.Model;
using ServerApp.Repository;

namespace ServerApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminRepository adminRepository = new AdminRepository();

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
                    HttpContext.Session.SetString("usertype", "admin");
                    Console.WriteLine("Session Value In:");
                    Console.WriteLine(HttpContext.Session.GetString("usertype").ToString());
                    return Ok(adminCred);
                }
                else
                {
                    return Ok();
                }
            }
        }

        [HttpGet("api/admin/getByUsername")]
        public IActionResult GetAdminByUsername(string username)
        {
            var usertype = HttpContext.Session.GetString("usertype");
            if (usertype == "admin")
            {
                return Ok(adminRepository.GetByUsername(username));
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost("api/admin/add")]
        public IActionResult AddAdmin([FromBody] Admin admin)
        {
            /*var addedAdmin = adminRepository.Add(admin);
            return Ok(addedAdmin);*/
            var usertype = HttpContext.Session.GetString("usertype");
            if (usertype == "admin")
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
        public IActionResult UpdateAdmin([FromBody] Admin admin)
        {
            var usertype = HttpContext.Session.GetString("usertype");
            if (usertype == "admin")
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
