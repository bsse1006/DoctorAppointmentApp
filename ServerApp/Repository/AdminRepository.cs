using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServerApp.Model;

namespace ServerApp.Repository
{
    public class AdminRepository : DatabaseRepository
    {
        public Admin Add(Admin admin)
        {
            DatabaseContext.admins.Add(admin);
            DatabaseContext.SaveChanges();
            return admin;
        }

        public Admin GetByUsername(string adminUsername)
        {
            return DatabaseContext.admins.SingleOrDefault(admin => admin.username == adminUsername);
        }

        public Admin Update(Admin admin)
        {
            DatabaseContext.admins.Update(admin);
            DatabaseContext.SaveChanges();
            return admin;
        }
    }
}
