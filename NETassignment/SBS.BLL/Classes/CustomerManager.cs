using SBS.BLL.Interface;
using SBS.BusinessEntity;
using SBS.Common;
using SBS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BLL.Classes
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public int Login(string email, string password)
        {
            return _customerRepository.Login(email, password);
        }

        public string Register(Customer customer)
        {
            customer.Password = Convert.ToBase64String(PassowrdEncrypt.Encrypt(customer.Password));
            return _customerRepository.Register(customer);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }
    }
}
