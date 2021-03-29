using EMS.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.BLL.Interfaces
{
    public interface IDepartmentManager
    {
        IEnumerable<Department> GetAll();
    }
}
