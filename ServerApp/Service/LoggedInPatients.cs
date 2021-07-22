using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ServerApp.Service
{
    public class LoggedInPatients
    {
        public ArrayList patients { get; set; }

        public LoggedInPatients ()
        {
            patients = new ArrayList();
        }
        public void AddLoggedInPatients(string patientName)
        {
            patients.Add(patientName);
        }

        public void RemoveLoggedInPatients(string patientName)
        {
            patients.Remove(patientName);
        }

        public bool checkIfLoggedIn(string patientName)
        {
            return patients.Contains(patientName);
        }
    }
}
