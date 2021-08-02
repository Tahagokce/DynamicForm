using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.DTOs;

namespace DataAccess
{
    public class AnsweredFormDal : EFEntityRepositoryBase<AnsweredForm, DynamicFormContext>, IAnsweredFormDal
    {
        public List<Question> GetByFormQuestion(int formId)
        {
            using (DynamicFormContext context = new DynamicFormContext())
            {
                var result = context.Questions.Where(i => i.FormId == formId);
                return result.ToList();
            }
        }

        public AnsweredForm GetByStringId(string id)
        {
            using (DynamicFormContext context = new DynamicFormContext())
            {
                var result = context.AnsweredForms.FirstOrDefault(i => i.Id == id);
                return result;
            }
        }

        public AnswerViewDto GetAnswerAndQuestionByFormId(int formId)
        {
            AnswerViewDto answerViewDto = new AnswerViewDto();

            DynamicFormContext context = new DynamicFormContext();


            List<List<Reply>> replyModel = new List<List<Reply>>();
            answerViewDto.Form = context.Forms.SingleOrDefault(i => i.Id == formId);
            answerViewDto.Questions = context.Questions.Where(i => i.FormId == formId).ToList();
            answerViewDto.AnsweredForms = context.AnsweredForms.Where(i => i.FormId == formId).ToList();
            foreach (var item in answerViewDto.AnsweredForms)
            {
                var reply = context.Replies.Where(i => i.AnsweredFormId == item.Id).ToList();

                replyModel.Add(reply);
            }

            answerViewDto.ReplyList = replyModel;

            return answerViewDto;
        }
    }
}