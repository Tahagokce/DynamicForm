using System.Collections.Generic;
using Core.Business;
using Core.Utilities.Results;
using DataAccess;

namespace Business.Abstract
{
    public interface IFormService : ICrudRepository<Form>
    {
        public IDataResult<List<Question>> GetByFormQuestion(int formId);

        public IDataResult<Form> UpdatedForm(Form TEntity);
    }
}