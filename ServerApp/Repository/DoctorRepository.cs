using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServerApp.Model;

namespace ServerApp.Repository
{
    public class DoctorRepository : DatabaseRepository
    {
        public Doctor Add(Doctor doctor)
        {
            DatabaseContext.doctors.Add(doctor);
            DatabaseContext.SaveChanges();
            return doctor;
        }

        public List<Doctor> GetAll()
        {
            return DatabaseContext.doctors.ToList();
        }

        public Doctor GetByID(int doctorID)
        {
            return DatabaseContext.doctors.SingleOrDefault(doctor => doctor.id == doctorID);
        }

        public Doctor GetByName(string doctorName)
        {
            //issue with multiple match
            return DatabaseContext.doctors.SingleOrDefault(doctor => doctor.name.Contains(doctorName));
        }

        public Doctor Update(Doctor doctor)
        {
            DatabaseContext.doctors.Update(doctor);
            DatabaseContext.SaveChanges();
            return doctor;
        }

        public bool Delete(Doctor doctor)
        {
            DatabaseContext.doctors.Remove(doctor);
            DatabaseContext.SaveChanges();
            return true;
        }
    }
}
