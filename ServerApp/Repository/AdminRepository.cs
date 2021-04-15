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

        public Admin Get()
        {
            return DatabaseContext.admins.ElementAtOrDefault(0);
        }

        public Admin Update(Admin admin)
        {
            DatabaseContext.admins.Update(admin);
            DatabaseContext.SaveChanges();
            return admin;
        }
    }
}
