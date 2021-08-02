using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    public class FormController : BaseController
    {
        private IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }


            [HttpGet]
            public ActionResult Index()   // oluşturulan bütün formlar listeleniyor
            {
                var form = _formService.GetAll().Data;
                return View(form);
            }



            public ActionResult Create()
            {
                return View();
            }


            [HttpPost]
            public ActionResult Create(Form form)
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                if (ModelState.IsValid)
                {
                    form.UserId = UserId.Value;
                    form.CreateTime = DateTime.Now;
                    _formService.Add(form);
                    return RedirectToAction("Index","Home");
                }

                return View();
            }



            public ActionResult Edit(int id)
            {
                var form = _formService.GetById(id).Data;
                if (form == null)
                {
                    return BadRequest();
                }

                var question = _formService.GetByFormQuestion(form.Id).Data;
                form.Questions=question;

                return View(form);


            }


            [HttpPost]
            public ActionResult Edit(Form form)
            {

                if (ModelState.IsValid)
                {
                    _formService.UpdatedForm(form);


                    // db.Entry(form).State = EntityState.Modified;                    //güncellenmesini söylüyoruz
                    // db.Entry(form).Property(e => e.UserId).IsModified = false; ;    // değişmesini istemediğimiz özelliği belirtiyoruz
                    // db.Entry(form).Property(e => e.CreateTime).IsModified = false;
                    // db.SaveChanges();
                        
                    return View();
                    //return RedirectToAction("Index" ,"Home");
                }

                return View();


            }
    }
}