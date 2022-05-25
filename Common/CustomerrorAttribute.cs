using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SPmvccrudoperations.Common
{
    public class CustomerrorAttribute : HandleErrorAttribute
    {
        //Now Override OnExption   
        public override void OnException(ExceptionContext filterContext)
        {
            //First Check if Exception all ready Handle Or Check Is Custom error Handle is enable   
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }
            var statusCode = (int)HttpStatusCode.InternalServerError;

            if (filterContext.Exception is HttpException)
            {
                statusCode = new HttpException(null, filterContext.Exception).GetHttpCode();
            }


            // if the request is AJAX return JSON else view.  
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        error = true,
                        message = filterContext.Exception.Message
                    }
                };
            }
            else
            {
                var controllerName = filterContext.RouteData.Values["controller"].ToString();
                var actionName = filterContext.RouteData.Values["action"].ToString();
                var errormodel = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

                filterContext.Result = new ViewResult
                {
                    ViewName = View,
                    MasterName = Master,
                    ViewData = new ViewDataDictionary(errormodel),
                    TempData = filterContext.Controller.TempData
                };
            }

            // log the error by using your own method  
            //here you can log  error into db or mail error with details to Admin or any other .  
            //Suppose I created one method name ExeptionLog() which accept one input parament type  exception. So now can paly with this exception into my exception log method.  

            //ExeptionLog(filterContext.Exception);  

            // Prepare the response code.  
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = statusCode;

            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}
