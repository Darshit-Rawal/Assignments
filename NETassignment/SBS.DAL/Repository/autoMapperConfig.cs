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
        public static Mapper CustomerToDbCustomerMapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<Customer, Database.Customer>();
        }));

        public static Mapper VehicleToDbVehicleMapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<Vehicle, Database.Vehicle>();
        }));

        public static Mapper DbVehicleToVehicleMapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<Database.Vehicle, Vehicle>();
        }));
    }
}
