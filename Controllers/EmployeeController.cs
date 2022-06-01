using Newtonsoft.Json;
using SPmvccrudoperations.Models;
using SPmvccrudoperations.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SPmvccrudoperations.Controllers
{
    [RoutePrefix("Employee")]
    public class EmployeeController : Controller

    {
        private readonly HomeService _homeService;
        private readonly string _baseUrl;

        public EmployeeController()
        {
            _homeService = new HomeService();
            _baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"].ToString();
        }

        // GET: Employee
        //[HandleError]
        [Route("~/")]
        [Route("Index")]
        //public ActionResult Index()
        //{
        //    //throw new Exception();
        //    List<EmployeeViewModel> empViewModelList = new List<EmployeeViewModel>();

        //    var client = new HttpClient();
        //    var apiUrl = ConfigurationManager.AppSettings["ApiBaseUrl"].ToString() + "api/Employee/GetEmployees";
        //    var response = client.GetAsync(apiUrl).Result;
        //    var content = response.Content.ReadAsStringAsync().Result;

        //    empViewModelList = _homeService.GetEmployeeList();
        //    return View(empViewModelList);
        //}

        public async Task<ActionResult> Index()
        {
            List<EmployeeViewModel> empViewModelList = new List<EmployeeViewModel>();
            
            try
            {
                using (var client = new HttpClient())
                {
                    //Passing service base url
                    client.BaseAddress = new Uri(_baseUrl);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                    HttpResponseMessage Res = await client.GetAsync("api/Employee/GetEmployees");
                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the .Net Type
                        var myDeserializedClass = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<EmployeeViewModel>>>(EmpResponse);
                        empViewModelList = myDeserializedClass.Data.ToList();
                    }
                    //returning the employee list to view
                    return View(empViewModelList);
                }
            }   
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public class ApiResponse<T>
        {
            public T Data { get; set; }
            public object Exception { get; set; }
            public object Message { get; set; }
        }

        public class ResponseDataDetail
        {
            public EmployeeViewModel Data { get; set; }
            public object Exception { get; set; }
            public object Message { get; set; }
        }

        [Route("Create")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Route("Create")]
        //[HandleError]
        [HttpPost]
        public async Task<ActionResult> Create(EmployeeViewModel employeeViewModel)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsondata = JsonConvert.SerializeObject(employeeViewModel);

                HttpContent data = new StringContent(jsondata, Encoding.UTF8, "application/json");

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/Employee/AddEmployee", data);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the .Net Type
                    //var myDeserializedClass = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<EmployeeViewModel>>>(EmpResponse);
                    //employeeViewModel = myDeserializedClass.Data;
                }
                //returning the employee list to view
                // return View(empViewModelList);
            }




           // _homeService.CreateEmployee(employeeViewModel);
            return Json(new { Message = "employee Inserted Successfully" }, JsonRequestBehavior.AllowGet);
        }
        [Route("Edit/{id}")]
        //[HandleError]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel = _homeService.GetEmployee(id);
            return View(employeeViewModel);
        }
        [Route("Edit")]
        //[HandleError]
        [HttpPost]
        public async Task<ActionResult> Edit(EmployeeViewModel employeeViewModel)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsondata = JsonConvert.SerializeObject(employeeViewModel);

                HttpContent data = new StringContent(jsondata, Encoding.UTF8, "application/json");

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/Employee/UpdateEmployee", data);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    //var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the .Net Type
                    //ResponseDataDetail myDeserializedClass = JsonConvert.DeserializeObject<ResponseDataDetail>(EmpResponse);
                   // employeeViewModel = myDeserializedClass.Data;
                }
                //returning the employee list to view
                // return View(empViewModelList);
            }
            //_homeService.UpdateEmployee(employeeViewModel);
            return Json("Success",JsonRequestBehavior.AllowGet);
        }
        [Route("Details/{id}")]
        //[HandleError]
        public async Task<ActionResult> Details(int id)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/Employee/GetEmployeeById/?id=" + id);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the .Net Type
                    var myDeserializedClass = JsonConvert.DeserializeObject<ApiResponse<EmployeeViewModel>>(EmpResponse);
                    employeeViewModel = myDeserializedClass.Data;
                }
                //returning the employee list to view
               // return View(empViewModelList);
            }


           // employeeViewModel = _homeService.GetEmployee(id);
            return View(employeeViewModel);
        }
        [Route("Delete/{id}")]
        //[HandleError]
        public async Task<ActionResult> Delete(int id)

        {
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.DeleteAsync("api/Employee/DeleteEmployee/?id=" + id);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the .Net Type
                    ResponseDataDetail myDeserializedClass = JsonConvert.DeserializeObject<ResponseDataDetail>(EmpResponse);
                   // employeeViewModel = myDeserializedClass.Data;
                }
                //returning the employee list to view
                // return View(empViewModelList);
            }
            // _homeService.DeleteEmployee(id);
            ViewBag.Messsage = "Employee Record Deleted Successfully";
            return RedirectToAction("Index");
        }


        public ActionResult Error()
        {
            return View();
        }
    }
}