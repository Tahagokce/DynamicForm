using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class ReplyManager : IReplyService
    {
        private IReplyDal _replyDal;

        public ReplyManager(IReplyDal replyDal)
        {
            _replyDal = replyDal;
        }
        
        
        
        public IDataResult<List<Reply>> GetAll(Expression<Func<Reply, bool>> filter = null)
        {
            return new SuccessDataResult<List<Reply>>(_replyDal.GetAll());

        }

        public IDataResult<Reply> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Reply> Add(Reply TEntity)
        {
            return new SuccessDataResult<Reply>(TEntity, "Başarılı");
        }

        public IDataResult<Reply> Update(Reply TEntity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Reply> Delete(Reply TEntity)
        {
            throw new NotImplementedException();
        }
    }
}