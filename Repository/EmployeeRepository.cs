using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPmvccrudoperations.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeemasterEntities eme;

        public EmployeeRepository()
        {
            eme = new EmployeemasterEntities();
        }
    
        public void Add(Employee obj)
        {
            eme.Employees.Add(obj);
        }

        public void Delete(int employeeid)
        {
            Employee emp = eme.Employees.Single(model => model.Employeeid == employeeid);

            eme.Employees.Remove(emp);
        }

        public IEnumerable<Employee> GetAll()
        {
             return eme.Employees.ToList();
        }

        public Employee GetById(int employeeid)
        {
            return eme.Employees.FirstOrDefault(model=> model.Employeeid == employeeid);
        }



        public void save()
        {
            eme.SaveChanges();
        }

        public void Update(Employee obj)
        {
            Employee emp = eme.Employees.Single(model => model.Employeeid == obj.Employeeid);
            if(emp != null)
            {
                emp.EmployeeName = obj.EmployeeName;
                emp.EmployeeSalary = obj.EmployeeSalary;
                emp.EmployeeCity = obj.EmployeeCity;
            }
            Add(emp);
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