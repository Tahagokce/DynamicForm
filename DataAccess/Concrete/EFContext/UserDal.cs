using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;

namespace DataAccess
{
    public class UserDal : EFEntityRepositoryBase<User,DynamicFormContext>, IUserDal
    {
        public User Get(User user)
        {
            using (DynamicFormContext context = new DynamicFormContext())
            {
               var result = context.Users.FirstOrDefault(i => i.UserName == user.UserName && i.Password == user.Password);
               return result;
            }
        }
    }
}