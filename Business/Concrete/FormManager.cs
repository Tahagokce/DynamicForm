using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class FormManager : IFormService
    {
        
        
        private IFormDal _formDal;
        public FormManager(IFormDal formDal)
        {
            _formDal = formDal;
        }
        
        
        
        public IDataResult<List<Form>> GetAll(Expression<Func<Form, bool>> filter = null)
        {
          var result =  _formDal.GetAll(filter);
          return new SuccessDataResult<List<Form>>(result,"Başarılı");
        }

        public IDataResult<Form> GetById(int id)
        {
           var result = _formDal.Get(i => i.Id == id);
          return new SuccessDataResult<Form>(result, "Başarılı");
        }

        public IDataResult<Form> Add(Form TEntity)
        { 
            _formDal.Add(TEntity);
           return new SuccessDataResult<Form>(TEntity, "Başarılı");
        }

        public IDataResult<Form> Update(Form TEntity)
        {
            _formDal.Update(TEntity);
            return new SuccessDataResult<Form>(TEntity, "Başarılı");
        }

        public IDataResult<Form> Delete(Form TEntity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Question>> GetByFormQuestion(int formId)
        {
            return new SuccessDataResult<List<Question>>(_formDal.GetByFormQuestion(formId),"Başarılı");
        }

        public IDataResult<Form> UpdatedForm(Form TEntity)
        {
            _formDal.UpdatedForm(TEntity);
            return new SuccessDataResult<Form>(TEntity, "Başarılı");
        }
    }
}