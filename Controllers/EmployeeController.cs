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
            private readonly HomeService hs;
            public EmployeeController()
            {
                hs = new HomeService();
            }

        // GET: Employee

        public ActionResult Index()
        {
            List<Employee> empList = new List<Employee>();
            try
            {
                empList = hs.GetEmployeeList();
            }
            catch (Exception ex)
            {

            }

            return View(empList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    hs.CreateEmployee(model);
                }
            }
            catch (Exception ex)
            {

            }
            // ViewBag.Message = "Data Insert Successfully";
            return Json(new { Message = "Data Insert Successfully" }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee data = new Employee();
            try
            {
                data = hs.GetEmployee(id);
            }
            catch (Exception ex)
            {

            }
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Employee Model)
        {
            try
            {
                hs.UpdateEmployee(Model);
            }
            catch (Exception ex)
            {

            }


            return RedirectToAction("index");
        }
        public ActionResult Details(int id)
        {
            Employee data = new Employee();
            try
            {
                data = hs.GetEmployee(id);
            }
            catch (Exception ex)
            {

            }
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            try
            {
                hs.DeleteEmployee(id);
            }
            catch (Exception ex)
            {

            }
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }



    }
}