using Core.Business;
using Core.Utilities.Results;
using DataAccess;

namespace Business.Abstract
{
    public interface IUserService : ICrudRepository<User>
    {
        public IDataResult<User> Get(User user);
    }
}