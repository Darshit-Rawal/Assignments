using SBS.BLL.Interface;
using SBS.BusinessEntity;
using SBS.DAL.Repository.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BLL.Classes
{
    public class VehicleManager : IVehicleManager
    {
        private readonly VehicleRepository _vehicleRepository;

        public VehicleManager(VehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public string Create(Vehicle vehicle)
        {
            return _vehicleRepository.Create(vehicle);
        }

        public string Delete(int id)
        {
            return _vehicleRepository.Delete(id);
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            return _vehicleRepository.GetVehicles();
        }

        public IEnumerable<Vehicle> GetVehicles(int Customerid)
        {
            return _vehicleRepository.GetVehicles(Customerid);
        }

        public string Update(Vehicle vehicle)
        {
            return _vehicleRepository.Update(vehicle);
        }
    }
}
