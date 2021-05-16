using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Repository
{
    public interface IGetDataRepository
    {
        string GetNameById(int id);
        string[] GetAll();
    }
}
