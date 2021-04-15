using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServerApp.Model
{
    public class Admin
    {
        [Key]
        public string username { get; set; }

        public string password { get; set; }
    }
}
