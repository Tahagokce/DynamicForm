using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class AnsweredFormController : BaseController
    {
        private IAnsweredFormService _answeredFormService;

        public AnsweredFormController(IAnsweredFormService answeredFormService)
        {
            _answeredFormService = answeredFormService;
        }

        [HttpGet]
        public ActionResult AnswerView(int id)
        {
             var result =  _answeredFormService.GetAnswerAndQuestionByFormId(id).Data;

            
             return View(result);

        }
        
        
        


        public ActionResult
            AnswerToForm(
                int id) // form cevaplamak için cevaplanacak forma ihtiyacımız var hangi form ise bu idsini alıyoruz ve viewde idsini aldığımız formun sorularını yayınlıyoruz
        {
            ViewBag.FormId = id;
            var result = _answeredFormService.GetByFormQuestion(id);

            return View(result.Data);
        }


        [HttpPost]
        public ActionResult AnswerToForm(IFormCollection form, int id) // viewde birden fazla post edilmesi gereken veri olduğu için formcollectiondan yararlandık,
        {
            // ve cevaplanmış formun hangi forma ait olduğunu tutmak için viewdeki formun idsini aldım


            AnsweredForm answeredForm = new AnsweredForm();
            answeredForm.FormId = id;
            answeredForm.Id = Guid.NewGuid().ToString();
            _answeredFormService.Add(answeredForm);
            //cevaplanmış formu veritabanına kaydettim ki ulaşması daha kolay olsun işler ayrılsı


            var answer = form["reply"].ToString(); //formcollection verileri v,rgülle ayırıp yollar bizde virgülü çıkarıp tane tane kaydediyoruz
            var questionId = form["questionId"].ToString();

             var answeredFormId=  _answeredFormService.GetByStringId(answeredForm.Id).Data.Id;
            //var reply = new Reply();
            //reply.ReplyName = replies;
            //reply.FormReplyId = replyForm.Id;
            //reply.FormId = replyForm.FormId;
            //db.Replies.Add(reply);
            //db.SaveChanges();

            string[] x1 = answer.Split(',');
            string[] x2 = questionId.Split(',');
            int y = 0;
            foreach (var item in x1)
            {
                Reply reply = new Reply();
                reply.Answer = item;
                reply.AnsweredFormId = answeredFormId;
                reply.FormId = answeredForm.FormId; //özet : form cevaplamak isteyen kişi sayfayı çağırdığında çağırdığı forma ait sorular listelenir ve cevapladıtan
                reply.QuestionId = Convert.ToInt32(x2[y]); //sonra post edilirken ReplyForm bojesi oluşturup veri tabanına atıyoruz bunu sebebi cevapları cevaplanmış bir formda tutmak için yoksa karışır
                y++; //sonra cevapların hangi cevaplanmış forma ait olduğunu bulmak için reply objesine cevaplanmış form idsini ekliyoruz.

                
                using (DynamicFormContext context = new DynamicFormContext())
                {
                    context.Replies.Add(reply);
                    context.SaveChanges();
                }
            }

            return RedirectToAction("AnswerToForm", "AnsweredForm", new {id = answeredForm.FormId});
        }
    }
}


//girilen verileri veritabanında aynı satıra eklemek amaçlı yapılan döngümüz

//for (int i = 1; i < form.Count; i++)
//{
//    Reply reply = new Reply();
//    reply.ReplyName = form[i].ToString();
//    reply.FormReplyId = replyFormId;
//    reply.FormId = id;                                                      //özet : form cevaplamak isteyen kişi sayfayı çağırdığında çağırdığı forma ait sorular listelenir ve cevapladıtan
//    //sonra post edilirken ReplyForm bojesi oluşturup veri tabanına atıyoruz bunu sebebi cevapları cevaplanmış bir formda tutmak için yoksa karışır
//    //sonra cevapların hangi cevaplanmış forma ait olduğunu bulmak için reply objesine cevaplanmış form idsini ekliyoruz.

//    db.Replies.Add(reply);

//}
//db.SaveChanges();