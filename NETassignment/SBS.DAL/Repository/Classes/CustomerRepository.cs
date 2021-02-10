using AutoMapper;
using SBS.BusinessEntity;
using SBS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBS.DAL.Repository;

namespace SBS.DAL.Repository.Classes
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Database.ServiceBookingSystemEntities _dbContext;

        public CustomerRepository()
        {
            _dbContext = new Database.ServiceBookingSystemEntities();
        }

        //Login User
        public bool Login(string email, string password)
        {
            Database.Customer customer = _dbContext.Customers.Where(user => user.EmailId.Equals(email)
            && user.Password == password).FirstOrDefault();

            if (customer != null)
            {
                return true;
            }
            return false;
        }

        //Register user
        public string Register(Customer customer)
        {
            try
            {
                if (customer != null)
                {
                    Database.Customer entity = new Database.Customer();

                    entity = autoMapperConfig.CustomerToDbCustomerMapper.Map<Database.Customer>(customer);

                    _dbContext.Customers.Add(entity);
                    _dbContext.SaveChanges();

                    return "created";
                }
                return "null";

            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

       
    }
}
