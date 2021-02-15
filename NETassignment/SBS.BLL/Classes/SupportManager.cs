using SBS.BLL.Interface;
using SBS.BusinessEntity;
using SBS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BLL.Classes
{
    public class SupportManager : ISupportManager
    {
        private readonly ISupportRepository _supportRepository;

        public SupportManager(ISupportRepository supportRepository)
        {
            _supportRepository = supportRepository;
        }

        public IEnumerable<Dealer> GetDealers()
        {
            return _supportRepository.GetDealers();
        }

        public IEnumerable<Manufacturer> GetManufacturers()
        {
            return _supportRepository.GetManufacturers();
        }

        public IEnumerable<Service> GetServices()
        {
            return _supportRepository.GetServices();
        }
    }
}
