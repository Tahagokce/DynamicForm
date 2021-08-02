using System.Collections.Generic;
using Core.DataAccess;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IAnsweredFormDal : IEntityRepository<AnsweredForm>
    {
        public List<Question> GetByFormQuestion(int formId);
        public AnsweredForm GetByStringId(string id);

        public AnswerViewDto GetAnswerAndQuestionByFormId(int formId);
    }
}