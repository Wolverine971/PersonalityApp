using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Domain.Questions
{
    public class LoveQ
    {
        public List<LoveQuestions> Question { get; set; }
        public List<LoveAnswers> Answer { get; set; }
    }

    

    public class LoveQuestions
    {
        public string Question { get; set; }
    }
    public class LoveAnswers
    {
        public string Answer { get; set; }
    }
}