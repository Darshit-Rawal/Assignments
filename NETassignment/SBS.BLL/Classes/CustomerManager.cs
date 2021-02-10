using SBS.BLL.Interface;
using SBS.BusinessEntity;
using SBS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public bool Login(string email, string password)
        {
            return _customerRepository.Login(email, password);
        }

        public string Register(Customer customer)
        {
            customer.Password = Convert.ToBase64String(Encrypt(customer.Password));
            return _customerRepository.Register(customer);
        }

        // Encryption Key used to encrypt password
        private readonly string EncryptionKey = "Encryption@123:]";

        private byte[] Encrypt(string password)
        {
            var key = GetKey(EncryptionKey);

            using (var aes = Aes.Create())
            using (var encryptor = aes.CreateEncryptor(key, key))
            {
                var plainText = Encoding.UTF8.GetBytes(password);
                return encryptor.TransformFinalBlock(plainText, 0, plainText.Length);
            }
        }

        // converts key into 128 bit hash
        private byte[] GetKey(string key)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(keyBytes);
            }
        }
    }
}
