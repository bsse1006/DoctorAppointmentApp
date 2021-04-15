using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServerApp.Model;

namespace ServerApp.Repository
{
    public class PatientRepository : DatabaseRepository
    {
        public Patient Add(Patient patient)
        {
            DatabaseContext.patients.Add(patient);
            DatabaseContext.SaveChanges();
            return patient;
        }

        public List<Patient> GetAll()
        {
            return DatabaseContext.patients.ToList();
        }

        public Patient GetByID(int patientID)
        {
            return DatabaseContext.patients.SingleOrDefault(patient => patient.id == patientID);
        }

        public Patient GetByEmail(string patientEmail)
        {
            return DatabaseContext.patients.SingleOrDefault(patient => patient.email == patientEmail);
        }

        public Patient Update(Patient patient)
        {
            DatabaseContext.patients.Update(patient);
            DatabaseContext.SaveChanges();
            return patient;
        }

        public bool Delete(Patient patient)
        {
            DatabaseContext.patients.Remove(patient);
            DatabaseContext.SaveChanges();
            return true;
        }
    }
}
