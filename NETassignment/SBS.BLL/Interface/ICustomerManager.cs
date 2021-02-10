using SBS.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BLL.Interface
{
    public interface ICustomerManager
    {
        string Register(Customer customer);
        bool Login(string email, string password);
    }
}
