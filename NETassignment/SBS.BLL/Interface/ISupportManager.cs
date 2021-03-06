﻿using SBS.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BLL.Interface
{
    public interface ISupportManager
    {
        IEnumerable<Dealer> GetDealers();
        IEnumerable<Manufacturer> GetManufacturers();
        IEnumerable<Service> GetServices();
        Mechanic GetMechanics(string Make);
    }
}
