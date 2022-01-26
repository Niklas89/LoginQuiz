using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginQuiz
{
    public class JSONModel
    {
        public const string filePath = @"C:\Users\utilisateur\source\repos\LoginQuizv2\quizdetails.json";

        public class Rootobject
        {
            public Users users { get; set; }
            public Questions questions { get; set; }
            public Answers answers { get; set; }
            public AdminInfo adminInfo { get; set; }
        }

        public class Users
        {
            public string admin { get; set; }
            public string adminpass { get; set; }
            public string username { get; set; }
            public string userpass { get; set; }
        }

        public class Questions
        {
            public string question1 { get; set; }
            public string question2 { get; set; }
            public string question3 { get; set; }
            public string question4 { get; set; }
            
        }

        public class Answers
        {
            public string answer1 { get; set; }
            public string answer2 { get; set; }
            public string answer3 { get; set; }
            public string answer4 { get; set; }
        }

        public class AdminInfo
        {
            public string nbParticipation { get; set; }
            public string successRate { get; set; }
            public string nbParticipationCorrect { get; set; }
        }

        public static Rootobject JsonReader()
        {
            StreamReader streamReader = new StreamReader(filePath);
            string jsonStr = streamReader.ReadToEnd();
            Rootobject record = JsonConvert.DeserializeObject<Rootobject>(jsonStr);
            return record;
        }
       

        public static List<Question> GetAllQuestions()
        {
            List<Question> Questionlist = new List<Question>();
            Questionlist.Add(new Question(JsonReader().questions.question1, JsonReader().answers.answer1));
            Questionlist.Add(new Question(JsonReader().questions.question2, JsonReader().answers.answer2));
            Questionlist.Add(new Question(JsonReader().questions.question3, JsonReader().answers.answer2));
            Questionlist.Add(new Question(JsonReader().questions.question4, JsonReader().answers.answer2));  

            return Questionlist;
        }

    }
}
