using EMS.BE;
using EMS.DAL.Context;
using EMS.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EMS.DAL.Classes
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EMSDbContext _dbContext;
        public EmployeeRepository(EMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(Employee employee)
        {
            try
            {
                _dbContext.employees.Add(employee);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            
        }

        public bool Delete(Guid Id)
        {
            try
            {
                Employee entity = _dbContext.employees.Find(Id);
                if (entity != null)
                {
                    _dbContext.employees.Remove(entity);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            
        }

        public Employee Get(Guid Id)
        {
            Employee entity = _dbContext.employees.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Entry(entity).Reference(x => x.department).Load();
            if (entity == null)
            {
                return new Employee();
            }
            return entity;
        }

        public IEnumerable<Employee> GetAll()
        {
            var emps = _dbContext.employees.ToList();
            return emps;
        }

        public IEnumerable<Employee> GetManagers()
        {
            return _dbContext.employees.Where(x => x.IsManager).ToList();
        }

        public bool Update(Employee employee)
        {
            try
            {
                var entity = _dbContext.employees.Attach(employee);
                entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();
                return true;
            } 
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            
        }
    }
}
