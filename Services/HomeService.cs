using SPmvccrudoperations.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using SPmvccrudoperations.Repository;
namespace SPmvccrudoperations.Services
{
    public class HomeService
    {

        private readonly EmployeemasterEntities _context;
        private readonly IEmployeeRepository ier;

        public HomeService()
        {
            _context = new EmployeemasterEntities();
            ier = new EmployeeRepository();
        }

        public List<Employee> GetEmployeeList()
        {
            List<Employee> empList = (List<Employee>)ier.GetAll();

            //List<Employee> empList = _context.Employees.ToList();
            return empList;
        }

        public void CreateEmployee(Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
        }

        public Employee GetEmployee(int id)
        {
            Employee emp = _context.Employees.Where(x => x.Employeeid == id).FirstOrDefault();
            return emp;
        }

        public void UpdateEmployee(Employee Model)
        {
            Employee data = GetEmployee(Model.Employeeid);
            if (data != null)
            {
                data.EmployeeCity = Model.EmployeeCity;
                data.EmployeeName = Model.EmployeeName;
                data.EmployeeSalary = Model.EmployeeSalary;
                _context.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            var data = _context.Employees.Where(x => x.Employeeid == id).FirstOrDefault();
            _context.Employees.Remove(data);
            _context.SaveChanges();
        }
    }
}