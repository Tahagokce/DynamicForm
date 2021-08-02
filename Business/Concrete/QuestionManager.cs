using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class QuestionManager : IQuestionService
    {
        private IQuestionDal _questionDal; 
        public QuestionManager(IQuestionDal questionDal)
        { 
            _questionDal = questionDal;
         }
        
        
        public IDataResult<List<Question>> GetAll(Expression<Func<Question, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Question> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Question> Add(Question TEntity)
        {
            _questionDal.Add(TEntity);
            return new SuccessDataResult<Question>(TEntity, "Başarılı");
        }

        public IDataResult<Question> Update(Question TEntity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Question> Delete(Question TEntity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Form> GetByFormId(int formId)
        {
            var result =  _questionDal.GetByFormId(formId);
            return new SuccessDataResult<Form>(result, "Başarılı");
        }

        public IDataResult<Question> UpdatedQuestion(Question TEntity)
        {
            _questionDal.UpdatedQuestion(TEntity);
           return new SuccessDataResult<Question>(TEntity, "Başarılı");
        }
    }
}