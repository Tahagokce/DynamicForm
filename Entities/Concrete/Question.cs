using System;
using System.Collections.Generic;
using Core.Entities;

namespace DataAccess
{
    public partial class Question : IEntity
    {
        public Question()
        {
            Replies = new HashSet<Reply>();
        }

        public int Id { get; set; }
        public string Question1 { get; set; }
        public int FormId { get; set; }

        public virtual Form Form { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
