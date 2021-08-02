using System;
using System.Linq;
using Business.Concrete;
using DataAccess;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicFormContext context = new DynamicFormContext();

            AnsweredFormManager answeredFormManager = new AnsweredFormManager(new AnsweredFormDal());

            var result = answeredFormManager.GetAnswerAndQuestionByFormId(3).Data;
            
            Console.WriteLine(result.Form.Title);
            
            foreach (var item in result.Questions)
            {
                Console.WriteLine(item.Question1);
            }

            foreach (var item in result.ReplyList)
            {
                foreach (var reply in item)
                {
                    Console.WriteLine(reply.Answer);
                }
                
            }
            





        }
        }
    }
