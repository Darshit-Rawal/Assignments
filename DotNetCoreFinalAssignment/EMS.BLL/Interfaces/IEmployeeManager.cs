using EMS.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.BLL.Interfaces
{
    public interface IEmployeeManager
    {
        IEnumerable<Employee> GetAll();
        Employee Get(Guid Id);
        bool Add(Employee employee);
        bool Update(Employee employee);
        bool Delete(Guid Id);
        IEnumerable<Employee> GetManagers();
    }
}
