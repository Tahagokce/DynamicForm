using System.Collections.Generic;
using Core.Business;
using Core.Utilities.Results;
using DataAccess;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAnsweredFormService : ICrudRepository<AnsweredForm>
    {
        public IDataResult<List<Question>> GetByFormQuestion(int formId);
        public IDataResult<AnsweredForm> GetByStringId(string id);
        
        public IDataResult<AnswerViewDto> GetAnswerAndQuestionByFormId(int formId);

    }
}