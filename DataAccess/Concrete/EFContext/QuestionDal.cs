using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class QuestionDal : EFEntityRepositoryBase<Question,DynamicFormContext>, IQuestionDal
    {
        public Form GetByFormId(int formId)
        {
            using (DynamicFormContext context = new DynamicFormContext())
            {
                var result = context.Forms.SingleOrDefault(i => i.Id == formId);
                return result;
            }
        }
        public Question UpdatedQuestion(Question TEntity)
        {
            using (DynamicFormContext context = new DynamicFormContext())
            {
                
                context.Entry(TEntity).State = EntityState.Modified;                    //güncellenmesini söylüyoruz
                context.Entry(TEntity).Property(e => e.FormId).IsModified = false; ;    // değişmesini istemediğimiz özelliği belirtiyoruz
                context.SaveChanges();
                return TEntity;
            }
        }
        
        
    }
}