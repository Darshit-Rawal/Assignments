using EMS.BE;
using EMS.DAL.Context;
using EMS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.DAL.Classes
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EMSDbContext _dbContext;
        public DepartmentRepository(EMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Department> GetAll()
        {
            return _dbContext.departments;
        }
    }
}
