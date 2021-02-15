using SBS.BLL.Interface;
using SBS.BusinessEntity;
using SBS.DAL.Repository.Classes;
using SBS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BLL.Classes
{
    public class AppointmentManager : IAppointmentManager
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentManager(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public string Create(Appointment appoinement)
        {
            SupportRepository support = new SupportRepository();
            appoinement.MachanicId = support.GetMechanics(appoinement.Vehicle.Manufacturer.Name).Id;
            return _appointmentRepository.Create(appoinement);
        }

        public string Delete(int appointmentId)
        {
            return _appointmentRepository.Delete(appointmentId);
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _appointmentRepository.GetAppointments();
        }

        public IEnumerable<Appointment> GetAppointments(DateTime startingDate, DateTime EndingDate)
        {
            return _appointmentRepository.GetAppointments(startingDate, EndingDate);
        }

        public string Update(Appointment appointment)
        {
            return _appointmentRepository.Update(appointment);
        }

        public string UpdateStatus(int appointmentId, bool status)
        {
            return _appointmentRepository.UpdateStatus(appointmentId, status);
        }
    }
}
