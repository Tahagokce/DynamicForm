using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;

namespace DataAccess
{
    public class ReplyDal : EFEntityRepositoryBase<Reply,DynamicFormContext>, IReplyDal
    {
        
    }
}