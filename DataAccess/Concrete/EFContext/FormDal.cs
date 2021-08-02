using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class FormDal : EFEntityRepositoryBase<Form,DynamicFormContext>, IFormDal
    {
        public List<Question> GetByFormQuestion(int formId)
        {
            
                using (DynamicFormContext context = new DynamicFormContext())
                {
                    var result = context.Questions.Where(i => i.FormId == formId);
                    return result.ToList();
                }
        }


        public Form UpdatedForm(Form TEntity)
        {
            using (DynamicFormContext context = new DynamicFormContext())
            {
                
                 context.Entry(TEntity).State = EntityState.Modified;                    //güncellenmesini söylüyoruz
                 context.Entry(TEntity).Property(e => e.UserId).IsModified = false; ;    // değişmesini istemediğimiz özelliği belirtiyoruz
                 context.Entry(TEntity).Property(e => e.CreateTime).IsModified = false;
                 context.SaveChanges();
                return TEntity;
            }
        }
        
        
    }
}