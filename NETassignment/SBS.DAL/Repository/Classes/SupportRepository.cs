using SBS.BusinessEntity;
using SBS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository.Classes
{
    public class SupportRepository : ISupportRepository
    {
        private readonly Database.ServiceBookingSystemEntities _dbContext;

        /// <summary>
        /// Public Constructor
        /// </summary>
        public SupportRepository()
        {
            _dbContext = new Database.ServiceBookingSystemEntities();
        }

        /// <summary>
        /// Get all the dealers
        /// </summary>
        /// <returns>List of dealer</returns>
        public IEnumerable<Dealer> GetDealers()
        {
            List<Dealer> dealersReturn = new List<Dealer>();
            IEnumerable<Database.Dealer> dealers = _dbContext.Dealers.ToList();

            foreach (var dealer in dealers)
            {
                Dealer entity = new Dealer();
                entity = autoMapperConfig.DbDealerToDealer.Map<Dealer>(dealer);

                dealersReturn.Add(entity);
            }

            return dealersReturn;
        }


        /// <summary>
        /// Get all Manufacturers
        /// </summary>
        /// <returns>List of Manufacturers</returns>
        public IEnumerable<Manufacturer> GetManufacturers()
        {
            List<Manufacturer> manufacturersReturn = new List<Manufacturer>();
            IEnumerable<Database.Manufacturer> manufacturers = _dbContext.Manufacturers.ToList();

            foreach (var manufacturer in manufacturers)
            {
                Manufacturer entity = new Manufacturer();
                entity = autoMapperConfig.DbManufacturerToManufacturer.Map<Manufacturer>(manufacturer);

                manufacturersReturn.Add(entity);
            }

            return manufacturersReturn;
        }

        /// <summary>
        /// Get all Services
        /// </summary>
        /// <returns>List of Services</returns>
        public IEnumerable<Service> GetServices()
        {
            List<Service> servicesReturn = new List<Service>();
            IEnumerable<Database.Service> manufacturers = _dbContext.Services.ToList();

            foreach (var service in servicesReturn)
            {
                Service entity = new Service();
                entity = autoMapperConfig.DbServiceToService.Map<Service>(service);

                servicesReturn.Add(entity);
            }

            return servicesReturn;
        }
    }
}
