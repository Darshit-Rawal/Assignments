using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Repository
{
    public class EmployeeRepository : IGetDataRepository
    {
        public string[] GetAll()
        {
            string[] array = { "Ronny", "Darshit" };
            return array;
        }

        public string GetNameById(int id)
        {
            string name;
            if (id == 1)
            {
                name = "Ronny";
            }
            else if (id == 2)
            {
                name = "Darshit";
            }
            else
            {
                name = "Not Found";
            }
            return name;
        }
    }
}
