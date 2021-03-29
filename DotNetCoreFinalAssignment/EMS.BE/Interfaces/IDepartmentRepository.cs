using EMS.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.DAL.Interfaces
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
    }
}
