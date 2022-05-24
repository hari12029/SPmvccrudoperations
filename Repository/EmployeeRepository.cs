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
            return _employeemasterEntities.Employees.FirstOrDefault(emp=> emp.Employeeid == employeeid);
        }



        public void save()
        {
            _employeemasterEntities.SaveChanges();
        }

        public void Update(Employee emp)
        {


            Employee employee = _employeemasterEntities.Employees.FirstOrDefault(empmodel => empmodel.Employeeid == emp.Employeeid);
            if (employee != null)
            {
                employee.EmployeeName = emp.EmployeeName;
                employee.EmployeeSalary = emp.EmployeeSalary;
                employee.EmployeeCity = emp.EmployeeCity;
            }
            save();
        }

        //public static IEnumerable<Predicate<Employee>> GetValidPredicates(this ArticleFiltersModel filter)
        //{
        //    if (filter.IsAvailable.HasValue)
        //        yield return a => a.IsAvailable == filter.IsAvailable;
        //    if (!string.IsNullOrWhiteSpace(filter.Name))
        //        yield return a => a.Title.Contains(filter.Name);
        //    if (filter.AreaFrom.HasValue)
        //        yield return a => a.House.Area >= filter.AreaFrom;
        //    // etc.

        //    if (filter.WithHomeAppliances.HasValue)
        //        yield return a => a.House.WithHomeAppliances == filter.WithHomeAppliances;
        //}
    }

 }