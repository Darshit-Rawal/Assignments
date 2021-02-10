using SBS.BusinessEntity;
using SBS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository.Classes
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly Database.ServiceBookingSystemEntities _dbContext;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public VehicleRepository()
        {
            _dbContext = new Database.ServiceBookingSystemEntities();
        }

        /// <summary>
        /// Add Vehicle To Database
        /// </summary>
        /// <param name="vehicle">object of vehicle</param>
        /// <returns>Status of creation</returns>
        public string Create(Vehicle vehicle)
        {
            try
            {
                if (vehicle != null)
                {
                    Database.Vehicle entity = new Database.Vehicle();

                    entity = autoMapperConfig.VehicleToDbVehicleMapper.Map<Database.Vehicle>(vehicle);

                    _dbContext.Vehicles.Add(entity);
                    _dbContext.SaveChanges();

                    return "created";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Delete Vehicle
        /// </summary>
        /// <param name="id">Id of vehicle</param>
        /// <returns>Status of deletion</returns>
        public string Delete(int id)
        {
            try
            {
                Database.Vehicle entity = new Database.Vehicle();

                entity = _dbContext.Vehicles.Where(x => x.Id == id).FirstOrDefault();
                if (entity != null)
                {
                    _dbContext.Vehicles.Remove(entity);
                    _dbContext.SaveChanges();

                    return "Deleted";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Get All Vehicles
        /// </summary>
        /// <returns>List of Vehicle</returns>
        public IEnumerable<Vehicle> GetVehicles()
        {
            List<Vehicle> vehiclesReturn = new List<Vehicle>();
            IEnumerable<Database.Vehicle> vehicles = _dbContext.Vehicles.ToList();

            foreach (var vehicle in vehicles)
            {
                Vehicle entity = new Vehicle();
                entity = autoMapperConfig.DbVehicleToVehicleMapper.Map<Vehicle>(vehicle);

                vehiclesReturn.Add(entity);
            }
            
            return vehiclesReturn;
        }

        /// <summary>
        /// Get vehicle/List Of Vehicle by customerId
        /// </summary>
        /// <param name="Customerid">Id of customer</param>
        /// <returns>List of Vehicle</returns>
        public IEnumerable<Vehicle> GetVehicles(int Customerid)
        {
            List<Vehicle> vehiclesReturn = new List<Vehicle>();
            IEnumerable<Database.Vehicle> vehicles = _dbContext.Vehicles
                .Where(x => x.CustomerId == Customerid).ToList();

            foreach (var vehicle in vehicles)
            {
                Vehicle entity = new Vehicle();
                entity = autoMapperConfig.DbVehicleToVehicleMapper.Map<Vehicle>(vehicle);

                vehiclesReturn.Add(entity);
            }

            return vehiclesReturn;
        }

        /// <summary>
        /// Update Vehicle
        /// </summary>
        /// <param name="vehicle">object of Vehicle</param>
        /// <returns>Status of updation</returns>
        public string Update(Vehicle vehicle)
        {
            try
            {
                var entity = _dbContext.Vehicles.Where(x => x.Id == vehicle.Id).FirstOrDefault();

                if (entity != null)
                {
                    entity.LicensePlate = vehicle.LicensePlate;
                    entity.ManufacturerId = vehicle.ManufacturerId;
                    entity.Model = vehicle.Model;
                    entity.RegistrationDate = vehicle.RegistrationDate;
                    entity.ChassisNumber = vehicle.ChassisNumber;
                    entity.CustomerId = vehicle.CustomerId;

                    _dbContext.SaveChanges();

                    return "Updated";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;  
            }
        }
    }
}
