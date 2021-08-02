using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    public class QuestionController : BaseController
    {
        private IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        
        
        
         // GET: Question
        public ActionResult Index()             //form ayıretmeksizin bütün sorular burada gözükür buna ayarlama elbette çekeceğiz
        {
           
            return View();
        }

        public ActionResult Create(int id) // soru oluşturmamız için öncelikle soru oluşturacağımız formu bilmeliyiz bunu form listeleme sayfasından formun idsi ile buradaki metota geliyoruz post ederken soruya form idsini ekliyoruz 
        {

            ViewBag.FormId = id;// form id başka yerlerdede kullanılabiliyor
            return View();
        }

        [HttpPost]
        public ActionResult Create(Question question)
        {
            if (ModelState.IsValid) // post ederken form idsini veri tabanına eklediktek sonra seçtiğimiz formun soruları hazır bulunmuş helde oluyor
            {
                
                _questionService.Add(question);
              
                return RedirectToAction("Create", new { id = question.FormId }); //tekrardan soru oluşturma yerine yönlendiriyoruz aynı form idsi ile.
            }
            return View(question);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.FormId = id;
            var question = _questionService.GetById(id); 

            if (question == null)
            {
                return BadRequest();
            }


            return View(question);
        }

        [HttpPost]
        public ActionResult Edit(Question question)
        {
            if (ModelState.IsValid)
            {

                _questionService.UpdatedQuestion(question);
              //  db.Entry(question).State = EntityState.Modified;//güncellenmesini söylüyoruz
              //  db.Entry(question).Property(e => e.FormId).IsModified = false;// değişmesini istemediğimiz özelliği belirtiyoruz
              //  db.SaveChanges();

                return RedirectToAction("Edit", "Form", new { id = question.FormId });
            }

            return View();
        }


        public ActionResult QuestionCreate(int formId)
        {
            var form = _questionService.GetByFormId(formId).Data;
            form.Questions = _questionService.GetAll(i => i.FormId == form.Id).Data;

            return View(form);
        }

       
       

    }
}