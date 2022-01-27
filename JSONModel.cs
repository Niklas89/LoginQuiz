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
            string jsonStr = ReadStream();
            Rootobject record = JsonConvert.DeserializeObject<Rootobject>(jsonStr);
            return record;
        }

        public static string ReadStream()
        {
            // string jsonStr = File.ReadAllText(filePath);
            StreamReader streamReader = new StreamReader(filePath);
            string jsonStr = streamReader.ReadToEnd();
            streamReader.Close();
            return jsonStr;
        }




        // Change a question
        public static void ChangeOneQuestion()
        {
            Console.WriteLine("Indiquez la question à changer dans la liste ci-dessous:");
            // créer une liste de questions 
            List<Question> Questionlist = new List<Question>();

            // récupere les questions dans le fichier
            Questionlist = JSONModel.GetAllQuestions();

            int i = 0;
            // affiche toutes les questions une par une 
            foreach (Question question in Questionlist)
            {

                Console.WriteLine("Question n° " + ++i);
                Console.WriteLine(question.Ask);
            }
            int numQuestion = 0;
            bool res = true;
            while (res)
            {
                Console.WriteLine("Quelle question souhaitez vous changer? Tapez le numéro correspondant.");
                res = int.TryParse(Console.ReadLine(), out numQuestion);
                if (res)
                {
                    if (numQuestion >= 1 && numQuestion <= Questionlist.Count())
                    {
                        res = false;
                    }
                    else
                    {
                        Console.WriteLine("Le numéro doit être supérieur à 1 et inférieur ou égal à " + Questionlist.Count());
                        res = true;
                    }
                } else
                {
                    Console.WriteLine("Vous n'avez pas tapé un numéro. Réessayez.");
                    res = true;
                }
            }

            
            string jsonStr = ReadStream();
            StringBuilder sb = new StringBuilder(jsonStr);

            i = 0;
            // affiche toutes les questions une par une 
            foreach (Question question in Questionlist)
            {
                ++i;
                if (i == numQuestion)
                {
                    Console.WriteLine("Ecrivez la nouvelle question.");
                    string newQuestionAsk = Console.ReadLine();
                    sb.Replace(question.Ask, newQuestionAsk);
                }
            }
            jsonStr = sb.ToString();
            //checking if the file already exists
            if (File.Exists(filePath))
            {
                //deleting file if it exists
                File.Delete(filePath);
            }
            // File.WriteAllText(filePath, jsonStr); 
            //creating StreamWriter to write JSON data to file
            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine(jsonStr);
                streamWriter.Close();
            }
        }





        public static void ChangeOneAnswer()
        {
            Console.WriteLine("Indiquez la réponse à changer dans la liste ci-dessous:");
            // créer une liste de questions 
            List<Question> Questionlist = new List<Question>();

            // récupere les réponses dans le fichier
            Questionlist = JSONModel.GetAllQuestions();

            int i = 0;
            // affiche toutes les questions une par une 
            foreach (Question question in Questionlist)
            {

                Console.WriteLine("Question n° " + ++i);
                Console.WriteLine(question.Ask);
                Console.WriteLine("Réponse:");
                Console.WriteLine(question.Answer);
            }
            int numAnswer = 0;
            bool res = true;
            while (res)
            {
                Console.WriteLine("Quelle réponse souhaitez vous changer? Tapez le numéro correspondant.");
                res = int.TryParse(Console.ReadLine(), out numAnswer);
                if (res)
                {
                    if(numAnswer >= 1 && numAnswer <= Questionlist.Count())
                    {
                        res = false;
                    } else
                    {
                        Console.WriteLine("Le numéro doit être supérieur à 1 et inférieur ou égal à "+ Questionlist.Count());
                        res = true;
                    }
                } else
                {
                    Console.WriteLine("Vous n'avez pas tapé un numéro. Réessayez.");
                    res = true;
                }
            }


            string jsonStr = ReadStream();
            StringBuilder sb = new StringBuilder(jsonStr);

            i = 0;
            // affiche toutes les questions une par une 
            foreach (Question question in Questionlist)
            {
                ++i;
                if (i == numAnswer)
                {
                    Console.WriteLine("Ecrivez la nouvelle réponse.");
                    string newAnswer = Console.ReadLine();
                    sb.Replace(question.Answer, newAnswer);
                }
            }
            jsonStr = sb.ToString();
            //checking if the file already exists
            if (File.Exists(filePath))
            {
                //deleting file if it exists
                File.Delete(filePath);
            }
            File.WriteAllText(filePath, jsonStr);
        }


        public static List<Question> GetAllQuestions()
        {
            List<Question> Questionlist = new List<Question>();
            Questionlist.Add(new Question(JsonReader().questions.question1, JsonReader().answers.answer1));
            Questionlist.Add(new Question(JsonReader().questions.question2, JsonReader().answers.answer2));
            Questionlist.Add(new Question(JsonReader().questions.question3, JsonReader().answers.answer3));
            Questionlist.Add(new Question(JsonReader().questions.question4, JsonReader().answers.answer4));  

            return Questionlist;
        }

    }
}
