using EMS.BE;
using EMS.BLL.Interfaces;
using EMS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.BLL.Classes
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentManager(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IEnumerable<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }
    }
}
