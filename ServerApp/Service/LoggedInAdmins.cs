using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ServerApp.Service
{
    public class LoggedInAdmins
    {
        public ArrayList admins { get; set; }

        public LoggedInAdmins()
        {
            admins = new ArrayList();
        }
        public void AddLoggedInAdmins(string adminName)
        {
            admins.Add(adminName);
        }

        public void RemoveLoggedInAdmins(string adminName)
        {
            admins.Remove(adminName);
        }

        public bool checkIfLoggedIn(string adminName)
        {
            return admins.Contains(adminName);
        }
    }
}
