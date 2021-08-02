using System;
using System.Collections.Generic;
using Core.Entities;

namespace DataAccess
{
    public partial class Form : IEntity
    {
        public Form()
        {
            Questions = new HashSet<Question>();
            Replies = new HashSet<Reply>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
