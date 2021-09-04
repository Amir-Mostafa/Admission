using authontecation.Authontecation;
using authontecation.interfces;
using authontecation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authontecation.Repo
{
    public class EmployeeRepo : IEmployee
    {

        private  ApplicationDbContext dbContext;
        public EmployeeRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(Employee emp)
        {
            dbContext.Add(emp);
            dbContext.SaveChanges();
        }

        public Employee Delete(int id)
        {
            var data = dbContext.Employees.Find(id);

            if (data == null)
                return null;
            else
            {
                dbContext.Remove(data);
                dbContext.SaveChanges();
                return data;
            }


        }

        
        public Employee Edit(Employee emp)
        {
            //var data = dbContext.Employees.Find(emp.Id);
            //if (data != null)
            //{
            //    Employee d = new Employee
            //    {
            //        Id=emp.Id,
            //        Name=emp.Name,
            //        salary=emp.salary
            //    };
                dbContext.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbContext.SaveChanges();
            //}
            return emp;
        }

        public List<Employee> GetAll()
        {
            return dbContext.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            Employee data = dbContext.Employees.Where(n => n.Id == id).FirstOrDefault();
            if (data == null)
                return null;
            return data;
        }
        
    }
}
