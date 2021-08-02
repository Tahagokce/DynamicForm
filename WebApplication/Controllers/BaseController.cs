using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication.Controllers
{
    public class BaseController : Controller
    {
        public int? UserId { get; set; }  
        public string UserName { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HttpContext.Session.Get("UserId")==null)
            {
                context.Result = new RedirectResult("/Account/Login");
            }
            else
            {
                            UserId = HttpContext.Session.GetInt32("UserId");
                            UserName = HttpContext.Session.GetString("UserName");

            }
        
    

            base.OnActionExecuting(context);
        }
    }
}