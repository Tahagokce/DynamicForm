using System;
using System.Collections.Generic;
using Core.Entities;

namespace DataAccess
{
    public partial class AnsweredForm  : IEntity
    {
        public AnsweredForm()
        {
            Replies = new HashSet<Reply>();
        }

        public string Id { get; set; }
        public int FormId { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }
    }
}
