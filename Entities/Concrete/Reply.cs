using System;
using System.Collections.Generic;
using Core.Entities;

namespace DataAccess
{
    public partial class Reply : IEntity
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public int FormId { get; set; }
        public int QuestionId { get; set; }
        public string AnsweredFormId { get; set; }

        public virtual AnsweredForm AnsweredForm { get; set; }
        public virtual Form Form { get; set; }
        public virtual Question Question { get; set; }
    }
}
