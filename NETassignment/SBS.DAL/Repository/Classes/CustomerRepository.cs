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

        /// <summary>
        /// Public Constructor
        /// </summary>
        public CustomerRepository()
        {
            _dbContext = new Database.ServiceBookingSystemEntities();
        }

        //Login User
        /// <summary>
        /// Find user from database
        /// </summary>
        /// <param name="email">email of user</param>
        /// <param name="password">password of user</param>
        /// <returns>user id of found user</returns>
        public int Login(string email, string password)
        {
            Database.Customer customer = _dbContext.Customers.Where(user => user.EmailId.Equals(email)
            && user.Password == password).FirstOrDefault();

            if (customer != null)
            {
                return customer.Id;
            }
            return 0;
        }

        /// <summary>
        /// Register user into database
        /// </summary>
        /// <param name="customer">object of customer</param>
        /// <returns>string represents state of method/opertaion</returns>
        public string Register(Customer customer)
        {
            try
            {
                if (customer != null)
                {
                    var res = _dbContext.Customers.Where(x => x.EmailId.Equals(customer.EmailId)).FirstOrDefault();
                    if (res != null)
                    {
                        return "already";
                    }
                    Database.Customer entity = new Database.Customer();

                    entity = autoMapperConfig.CustomerToDbCustomer.Map<Database.Customer>(customer);

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
