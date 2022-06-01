using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPmvccrudoperations.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeemasterEntities _employeemasterEntities;

        public EmployeeRepository()
        {
            _employeemasterEntities = new EmployeemasterEntities();
        }

        public void Add(Employee emp)
        {
            _employeemasterEntities.Employees.Add(emp);
            save();
        }

        public void Delete(int employeeid)
        {
            Employee emp = _employeemasterEntities.Employees.Single(employee => employee.Employeeid == employeeid);

            _employeemasterEntities.Employees.Remove(emp);
            save();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeemasterEntities.Employees.ToList();
        }

        public Employee GetById(int employeeid)
        {
            return _employeemasterEntities.Employees.FirstOrDefault(emp => emp.Employeeid == employeeid);
        }



        public void save()
        {
            _employeemasterEntities.SaveChanges();
        }

        public void Update(Employee emp)
        {
            _employeemasterEntities.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            save();
        }

    }

}