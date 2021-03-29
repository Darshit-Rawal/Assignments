using EMS.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee Get(Guid Id);
        bool Add(Employee employee);
        bool Update(Employee employee);
        bool Delete(Guid Id);
        IEnumerable<Employee> GetManagers();
    }
}
