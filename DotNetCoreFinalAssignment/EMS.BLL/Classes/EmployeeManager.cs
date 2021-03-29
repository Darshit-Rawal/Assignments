using EMS.BE;
using EMS.BLL.Interfaces;
using EMS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.BLL.Classes
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public bool Add(Employee employee)
        {
            return _employeeRepository.Add(employee);
        }

        public bool Delete(Guid Id)
        {
            return _employeeRepository.Delete(Id);
        }

        public Employee Get(Guid Id)
        {
            return _employeeRepository.Get(Id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public IEnumerable<Employee> GetManagers()
        {
            return _employeeRepository.GetManagers();
        }

        public bool Update(Employee employee)
        {
            return _employeeRepository.Update(employee);
        }
    }
}
