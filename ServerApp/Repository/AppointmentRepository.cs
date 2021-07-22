using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServerApp.Model;

namespace ServerApp.Repository
{
    public class AppointmentRepository : DatabaseRepository
    {
        public Appointment Add(Appointment appointment)
        {
            DatabaseContext.appointments.Add(appointment);
            DatabaseContext.SaveChanges();
            return appointment;
        }

        public List<Appointment> GetAll()
        {
            return DatabaseContext.appointments.ToList();
        }

        public Appointment GetByID(int appointmentID)
        {
            return DatabaseContext.appointments.SingleOrDefault(appointment => appointment.id == appointmentID);
        }

        public Appointment GetByDoctorID(int doctorID)
        {
            return DatabaseContext.appointments.SingleOrDefault(appointment => appointment.doctorID == doctorID);
        }

        public List<Appointment> GetByPatientID(int patientID)
        {
            return DatabaseContext.appointments.Where(appointment => appointment.patientID == patientID).ToList();
            //return DatabaseContext.appointments.SingleOrDefault(appointment => appointment.patientID == patientID);
        }

        public Appointment GetByTime(string appointmentTime)
        {
            return DatabaseContext.appointments.SingleOrDefault(appointment => appointment.time==appointmentTime);
        }

        public Appointment Update(Appointment appointment)
        {
            DatabaseContext.appointments.Update(appointment);
            DatabaseContext.SaveChanges();
            return appointment;
        }

        public bool Delete(Appointment appointment)
        {
            DatabaseContext.appointments.Remove(appointment);
            DatabaseContext.SaveChanges();
            return true;
        }
    }
}
