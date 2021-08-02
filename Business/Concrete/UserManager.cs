using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        
        
        
        public IDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> Add(User TEntity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> Update(User TEntity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> Delete(User TEntity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> Get(User TEntity)
        {
           var result = _userDal.Get(TEntity);
            return new SuccessDataResult<User>(result,"Başarılı");
        }
    }
}