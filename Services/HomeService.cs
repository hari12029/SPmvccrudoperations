using SPmvccrudoperations.Models;
using SPmvccrudoperations.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace SPmvccrudoperations.Services
{
    public class HomeService
    {

        private readonly EmployeemasterEntities _employeemasterEntities;
        private readonly IEmployeeRepository _iemployeeRepository;

        public HomeService()
        {
            _employeemasterEntities = new EmployeemasterEntities();
            _iemployeeRepository = new EmployeeRepository();
        }

        public List<EmployeeViewModel> GetEmployeeList()
        {
            List<Employee> empList = _iemployeeRepository.GetAll().ToList();

            List<EmployeeViewModel> empViewModelList = new List<EmployeeViewModel>();

            foreach (var emp in empList)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.Employeeid = emp.Employeeid;
                empViewModel.EmployeeName = emp.EmployeeName;
                empViewModel.EmployeeSalary = emp.EmployeeSalary;
                empViewModel.EmployeeCity = emp.EmployeeCity;


                empViewModelList.Add(empViewModel);
            }
            return empViewModelList;
        }

        public void CreateEmployee(EmployeeViewModel employeeViewModel)
        {
            Employee employee = new Employee();
            employee.Employeeid = employeeViewModel.Employeeid;
            employee.EmployeeName = employeeViewModel.EmployeeName;
            employee.EmployeeSalary = employeeViewModel.EmployeeSalary;
            employee.EmployeeCity = employeeViewModel.EmployeeCity;

            _iemployeeRepository.Add(employee);
        }

        public EmployeeViewModel GetEmployee(int id)
        {
            Employee emp = _iemployeeRepository.GetById(id);

            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.Employeeid = emp.Employeeid;
            employeeViewModel.EmployeeName = emp.EmployeeName;
            employeeViewModel.EmployeeSalary = emp.EmployeeSalary;
            employeeViewModel.EmployeeCity = emp.EmployeeCity;

            return employeeViewModel;
        }

        public void UpdateEmployee(EmployeeViewModel employeeViewModel)
        {

            Employee employee = _iemployeeRepository.GetById(employeeViewModel.Employeeid);
            employee.Employeeid = employeeViewModel.Employeeid;
            employee.EmployeeName = employeeViewModel.EmployeeName;
            employee.EmployeeSalary = employeeViewModel.EmployeeSalary;
            employee.EmployeeCity = employeeViewModel.EmployeeCity;

            _iemployeeRepository.Update(employee);
        }

        public void DeleteEmployee(int id)
        {
            _iemployeeRepository.Delete(id);

        }
    }
}