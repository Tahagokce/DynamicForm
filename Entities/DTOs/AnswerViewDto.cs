using System.Collections.Generic;
using DataAccess;

namespace Entities.DTOs
{
    public class AnswerViewDto
    {
        public Form Form { get; set; }
        public List<Question> Questions { get; set; }
        public List<AnsweredForm> AnsweredForms { get; set; }
        
        public List<List<Reply>> ReplyList { get; set; }
    }
}