using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using authontecation.Models;
namespace authontecation.interfces
{
    public interface IEmployee
    {
        List<Employee> GetAll();

        Employee GetById(int id);

        void Add(Employee emp);

        Employee Delete(int id);

        Employee Edit(Employee emp);
    }
}
