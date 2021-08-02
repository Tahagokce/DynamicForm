using Core.Business;
using Core.Utilities.Results;
using DataAccess;

namespace Business.Abstract
{
    public interface IQuestionService : ICrudRepository<Question>
    {
        public IDataResult<Form> GetByFormId(int formId);

        public IDataResult<Question> UpdatedQuestion(Question TEntity);
    }
}