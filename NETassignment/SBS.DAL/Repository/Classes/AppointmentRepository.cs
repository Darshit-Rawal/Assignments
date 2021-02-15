using AutoMapper;
using SBS.BusinessEntity;
using SBS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository.Classes
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly Database.ServiceBookingSystemEntities _dbContext;

        /// <summary>
        /// Public Constructor
        /// </summary>
        public AppointmentRepository()
        {
            _dbContext = new Database.ServiceBookingSystemEntities();
        }

        /// <summary>
        /// Add Appointment To Database
        /// </summary>
        /// <param name="appoinement">object of appointment</param>
        /// <returns>Status of creation</returns>
        public string Create(Appointment appoinement)
        {
            try
            {
                if (appoinement != null)
                {
                    var res = _dbContext.Appointments.Where(x => x.VehicleId == appoinement.VehicleId && x.ServiceId == appoinement.ServiceId).FirstOrDefault();
                    if (res != null)
                    {
                        return "already";
                    }
                    Database.Appointment entity = new Database.Appointment();
                    appoinement.Vehicle = null;
                    entity = autoMapperConfig.AppointmentToDbAppointment.Map<Database.Appointment>(appoinement);

                    _dbContext.Appointments.Add(entity);
                    _dbContext.SaveChanges();

                    return "created";
                }
                return "null";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return "null";
            }
            
        }

        /// <summary>
        /// Delete Appointment
        /// </summary>
        /// <param name="appointmentId">Id of appointment</param>
        /// <returns>Status of deletion</returns>
        public string Delete(int appointmentId)
        {
            try
            {
                Database.Appointment appointment = _dbContext.Appointments
                    .Where(x => x.Id == appointmentId).FirstOrDefault();
                if (appointment != null)
                {
                    _dbContext.Appointments.Remove(appointment);
                    _dbContext.SaveChanges();
                    return "deleted";
                }
                return "null";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return "null";
            }
        }

        /// <summary>
        /// Get All Appointments
        /// </summary>
        /// <returns>List of Appointments</returns>
        public IEnumerable<Appointment> GetAppointments()
        {
            List<Appointment> appointmentsReturn = new List<Appointment>();
            var appointments = _dbContext.Appointments.Include("Customer").Include("Dealer").Include("Mechanic").Include("Service").Include("Vehicle").ToList();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Database.Appointment, Appointment>();
                cfg.CreateMap<Database.Customer, Customer>();
                cfg.CreateMap<Database.Dealer, Dealer>();
                cfg.CreateMap<Database.Mechanic, Mechanic>();
                cfg.CreateMap<Database.Service, Service>();
                cfg.CreateMap<Database.Vehicle, Vehicle>();
                cfg.CreateMap<Database.Manufacturer, Manufacturer>();
            });
            config.AssertConfigurationIsValid();

            var mapper = config.CreateMapper();
            if (appointments.Any())
            {
                foreach (var appointment in appointments)
                {
                    Appointment entity = new Appointment();
                    entity = mapper.Map<Database.Appointment, Appointment>(appointment);

                    appointmentsReturn.Add(entity);
                }
                return appointmentsReturn;
            }
            return new List<Appointment>();
        }

        /// <summary>
        /// Get Filtered list of Appointments
        /// </summary>
        /// <param name="startingDate">Starting Date of Filter</param>
        /// <param name="EndingDate">Ending Date of Filter</param>
        /// <returns>List of Appointments</returns>
        public IEnumerable<Appointment> GetAppointments(DateTime startingDate, DateTime EndingDate)
        {
            List<Appointment> appointmentsReturn = new List<Appointment>();
            var appointments = _dbContext.Appointments
                .Where(x => x.AppointmentDate >= startingDate && x.AppointmentDate <= EndingDate).ToList();
            if (appointments.Any())
            {
                foreach (var appointment in appointments)
                {
                    Appointment entity = new Appointment();
                    entity = autoMapperConfig.DbAppointmentToAppointment.Map<Appointment>(appointment);

                    appointmentsReturn.Add(entity);
                }
                return appointmentsReturn;
            }
            return new List<Appointment>();
        }

        /// <summary>
        /// Update Appointment
        /// </summary>
        /// <param name="appointment">object of Appointment</param>
        /// <returns>Status of Updation</returns>
        public string Update(Appointment appointment)
        {
            try
            {
                var entity = _dbContext.Appointments
                    .Where(x => x.Id == appointment.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.MachanicId = appointment.MachanicId;
                    entity.ServiceId = appointment.ServiceId;
                    entity.VehicleId = appointment.VehicleId;
                    entity.CustomerId = appointment.CustomerId;
                    entity.DealerId = appointment.DealerId;
                    entity.Status = appointment.Status;
                    entity.AppointmentDate = appointment.AppointmentDate;

                    _dbContext.SaveChanges();
                    return "updated";
                }
                return "null";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return "null";
            }
        }

        /// <summary>
        /// Update status of a Appointment! Ex. Pending(Default), Approved, Denied
        /// </summary>
        /// <param name="appointmentId">Id of Appointment</param>
        /// <param name="status">status of update</param>
        /// <returns>Status of Updation</returns>
        public string UpdateStatus(int appointmentId, bool status)
        {
            try
            {
                Database.Appointment appointment = _dbContext.Appointments
                    .Where(x => x.Id == appointmentId).FirstOrDefault();
                if (appointment != null)
                {
                    if (status == true)
                    {
                        appointment.Status = 1;
                        return "updated";
                    }
                    else
                    {
                        appointment.Status = -1;
                        return "updated";
                    }
                }
                return "null";
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return "null";
            }
        }
    }
}
