using SBS.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository.Interface
{
    public interface ISupportRepository
    {
        IEnumerable<Dealer> GetDealers();
        IEnumerable<Manufacturer> GetManufacturers();
        IEnumerable<Service> GetServices();
        Mechanic GetMechanics(string Make);
    }
}
