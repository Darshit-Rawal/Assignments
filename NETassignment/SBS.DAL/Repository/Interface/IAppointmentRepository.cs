﻿using SBS.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository.Interface
{
    public interface IAppointmentRepository
    {
        string Create(Appointment appoinement);
        string Update(Appointment appointment);
        string UpdateStatus(int appointmentId, bool status);
        string Delete(int appointmentId);
        IEnumerable<Appointment> GetAppointments(int customerId);
        IEnumerable<Appointment> GetAppointments();
        IEnumerable<Appointment> GetAppointments(DateTime startingDate, DateTime EndingDate);
        Appointment GetAppointment(int Id);
    }
}
