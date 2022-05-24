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

        public ActionResult Index()
        {
            List<EmployeeViewModel> empViewModelList = new List<EmployeeViewModel>();
            try
            {
                empViewModelList = _homeService.GetEmployeeList();

                
            }
            catch (Exception ex)
            {
                return View();
            }

            return View(empViewModelList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeViewModel employeeViewModel)
        {

            try
            {
                
                    _homeService.CreateEmployee(employeeViewModel);
                
            }
            catch (Exception ex)
            {

            }
            return Json(new { Message = "employee Inserted Successfully" }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            try
            {
                employeeViewModel = _homeService.GetEmployee(id);
            }
            catch (Exception ex)
            {

            }
            return View(employeeViewModel);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeViewModel employeeViewModel)
        {
            try
            {
                _homeService.UpdateEmployee(employeeViewModel);
            }
            catch (Exception ex)
            {

            }


            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            try
            {

                employeeViewModel =  _homeService.GetEmployee(id);
            }
            catch (Exception ex)
            {

            }
            return View(employeeViewModel);
        }
        public ActionResult Delete(int id)
        {
            try
            {
                _homeService.DeleteEmployee(id);
            }
            catch (Exception ex)
            {

            }
            ViewBag.Messsage = "Employee Record Deleted Successfully";
            return RedirectToAction("Index");
        }



    }
}