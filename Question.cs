using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginQuiz
{
    public class Question
    {
        public string Ask { get; set; }
        public string Answer { get; set; }
        public List<string> UserAnswers { get; set; }

        public Question(string question, string answered)
        {
            this.Ask = question;
            this.Answer = answered;
            this.UserAnswers = new List<string>();

        }
    }
}
