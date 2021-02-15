using AutoMapper;
using SBS.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository
{
    public class autoMapperConfig
    {
        public static Mapper CustomerToDbCustomer = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<Customer, Database.Customer>();
        }));

        public static Mapper VehicleToDbVehicle = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<Vehicle, Database.Vehicle>();
        }));

        public static Mapper DbVehicleToVehicle = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<Database.Vehicle, Vehicle>();
        }));

        public static Mapper DbDealerToDealer = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<Database.Dealer, Dealer>();
        }));

        public static Mapper DbManufacturerToManufacturer = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<Database.Manufacturer, Manufacturer>();
        }));

        public static Mapper DbServiceToService = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<Database.Service, Service>();
        }));

        public static Mapper DbAppointmentToAppointment = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<Database.Vehicle, Vehicle>();
        }));

        public static Mapper AppointmentToDbAppointment = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<Appointment, Database.Appointment>();
        }));
    }
}
