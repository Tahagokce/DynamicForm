using System.Collections.Generic;
using Core.DataAccess;

namespace DataAccess.Abstract
{
    public interface IQuestionDal : IEntityRepository<Question>
    {
        public Form GetByFormId(int id);
        public Question UpdatedQuestion(Question TEntity);
    }
}