using SPmvccrudoperations.Models;
using SPmvccrudoperations.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPmvccrudoperations.Controllers
{
    public class EmployeeController : Controller

    {
        private readonly HomeService _homeService;


        public EmployeeController()
        {
            _homeService = new HomeService();
        }

        // GET: Employee
        [HandleError]
        public ActionResult Index()
        {
            //throw new Exception();
            List<EmployeeViewModel> empViewModelList = new List<EmployeeViewModel>();

            
                empViewModelList = _homeService.GetEmployeeList();
                return View(empViewModelList);
                    
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HandleError]
        [HttpPost]
        public ActionResult Create(EmployeeViewModel employeeViewModel)
        {

            _homeService.CreateEmployee(employeeViewModel);
            return Json(new { Message = "employee Inserted Successfully" }, JsonRequestBehavior.AllowGet);

        }
        [HandleError]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

           
                employeeViewModel = _homeService.GetEmployee(id);
                return View(employeeViewModel);
            
        }
        [HandleError]
        [HttpPost]
        public ActionResult Edit(EmployeeViewModel employeeViewModel)
        {
            
                _homeService.UpdateEmployee(employeeViewModel);
                return RedirectToAction("Index");

        }
        [HandleError]
        public ActionResult Details(int id)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            
            

                employeeViewModel =  _homeService.GetEmployee(id);
                return View(employeeViewModel);

            
     
        }
        [HandleError]
        public ActionResult Delete(int id)
        {
            
            
                _homeService.DeleteEmployee(id);
                ViewBag.Messsage = "Employee Record Deleted Successfully";
                return RedirectToAction("Index");

            
            
        }



    }
}