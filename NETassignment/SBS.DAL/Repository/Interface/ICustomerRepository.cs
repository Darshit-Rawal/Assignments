using SBS.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository.Interface
{
    public interface ICustomerRepository
    {
        bool Login(string email, string password);
        string Register(Customer customer);
    }
}
