using System.Collections.Generic;
using Core.DataAccess;
using Core.Utilities.Results;

namespace DataAccess.Abstract
{
    public interface IFormDal : IEntityRepository<Form>
    {
        public List<Question> GetByFormQuestion(int formId);
        public Form UpdatedForm(Form TEntity);
    }
}