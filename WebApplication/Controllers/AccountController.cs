using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;


        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        


            [HttpPost]
            public ActionResult Login(User model)
            {

                if (ModelState.IsValid)
                {

                    var user = _userService.Get(model);
               
                    if (user != null)
                    {
                       
                       HttpContext.Session.SetInt32("UserId",user.Data.Id);
                       HttpContext.Session.SetString("UserName",user.Data.UserName);
                          
                        return RedirectToAction("Index","Home");
                        
                        
                    }
                    else
                    {
                        ViewBag.Error = "Kullanıcı adı veya şifre yanlış.";
                        return View();
                    }


                }

                return View(model);

            }

            
            [HttpGet]
            public ActionResult Login()
            {

                return View();

            }

            public ActionResult Logout()
            {
                
                
                HttpContext.Session.Clear();
               // Session["UserId"] = null;
               // Session["UserName"] = null;


                return RedirectToAction("Login");


            }
            

           

          
    }
}