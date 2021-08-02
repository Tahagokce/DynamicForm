using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AnsweredFormManager : IAnsweredFormService
    {
        private IAnsweredFormDal _answeredFormDal;
        public AnsweredFormManager(IAnsweredFormDal answeredFormDal)
        {
            _answeredFormDal = answeredFormDal;
        }
        
        
        public IDataResult<List<AnsweredForm>> GetAll(Expression<Func<AnsweredForm, bool>> filter = null)
        {
            if (filter!= null)
            {
                return new SuccessDataResult<List<AnsweredForm>>(_answeredFormDal.GetAll(filter), "Başarılı");
            }

            return new SuccessDataResult<List<AnsweredForm>>(_answeredFormDal.GetAll(), "Başarılı");

        }

        public IDataResult<AnsweredForm> GetById(int id)
        {
            throw new NotImplementedException();
        }


        public IDataResult<AnsweredForm> GetByStringId(string id)
        {
           var result = _answeredFormDal.GetByStringId(id);
           return new SuccessDataResult<AnsweredForm>(result, "Başarılı");  
        }

        public IDataResult<AnswerViewDto> GetAnswerAndQuestionByFormId(int formId)
        {
            var result = _answeredFormDal.GetAnswerAndQuestionByFormId(formId);
            return new SuccessDataResult<AnswerViewDto>(result, "Başarılı");
        }

        public IDataResult<AnsweredForm> Add(AnsweredForm TEntity)
        {
            _answeredFormDal.Add(TEntity);
            return new SuccessDataResult<AnsweredForm>(TEntity, "Başarılar");
        }

        public IDataResult<AnsweredForm> Update(AnsweredForm TEntity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<AnsweredForm> Delete(AnsweredForm TEntity)
        {
            _answeredFormDal.Delete(TEntity);
            return new SuccessDataResult<AnsweredForm>(TEntity, "Başarılı");
        }

        public IDataResult<List<Question>> GetByFormQuestion(int formId)
        {
            var result = _answeredFormDal.GetByFormQuestion(formId);

            return new SuccessDataResult<List<Question>>(result, "Başarılı");
        }
    }
}