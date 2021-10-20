using System;
using System.Collections.Generic;
using System.Text;

namespace BreviumScheduler
{
    class Appointment
    {
        int doctorId;
        int personId;
        string appointmentTime;
        bool isNewPatientAppointment;

        public int DoctorId { get => doctorId; set => doctorId = value; }
        public int PersonId { get => personId; set => personId = value; }
        public string AppointmentTime { get => appointmentTime; set => appointmentTime = value; }
        public bool IsNewPatientAppointment { get => isNewPatientAppointment; set => isNewPatientAppointment = value; }
    }
}
