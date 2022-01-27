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
        public const string filePath = @"C:\Users\utilisateur\source\repos\LoginQuizv3\jsondetails.json";

        public static dynamic ConvertJsonStrToDynamic()
        {
            string jsonStr = ReadStream();
            dynamic DynamicData = JsonConvert.DeserializeObject(jsonStr);
            return DynamicData;
        }

        public static string ReadStream()
        {
            // string jsonStr = File.ReadAllText(filePath);
            StreamReader streamReader = new StreamReader(filePath);
            string jsonStr = streamReader.ReadToEnd();
            streamReader.Close();
            return jsonStr;
        }


        public static List<Question> GetAllQuestions()
        {
            List<Question> Questionlist = new List<Question>();
            dynamic DynamicData = ConvertJsonStrToDynamic();
            int i = 0;
            foreach (var itemQuestion in DynamicData.Questions)
            {
                string question = itemQuestion;
                string answer = DynamicData.Answers[i];
                Questionlist.Add(new Question(question, answer));
                i++;
            }
            return Questionlist;
        }

        public static void WriteStream(string jsonStr)
        {
            //checking if the file already exists
            if (File.Exists(filePath))
            {
                //deleting file if it exists
                File.Delete(filePath);
            }
            
            //creating StreamWriter to write JSON data to file
            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine(jsonStr);
                streamWriter.Close();
            }

            // other method to write data to file:
            // File.WriteAllText(filePath, jsonStr); 
        }



        public static void ChangeScoreInfo(int newParticipant, int validedQuiz)
        {
            dynamic DynamicData = ConvertJsonStrToDynamic();
            DynamicData.AdminInfo.nbParticipation += newParticipant;
            DynamicData.AdminInfo.nbParticipationCorrect += validedQuiz;
            DynamicData.AdminInfo.successRate = (DynamicData.AdminInfo.nbParticipationCorrect * 100) / DynamicData.AdminInfo.nbParticipation;
            string jsonStr = JsonConvert.SerializeObject(DynamicData);
            WriteStream(jsonStr);
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
                    res = verifyNumberCount(numQuestion, Questionlist.Count());
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
            WriteStream(jsonStr);
        }



        public static bool verifyNumberCount(int number, int questionCount)
        {
            if (number >= 1 && number <= questionCount)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Le numéro doit être supérieur à 1 et inférieur ou égal à " + questionCount);
                return true;
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
                    res = verifyNumberCount(numAnswer, Questionlist.Count());
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
            WriteStream(jsonStr);
        }

        public static void GetAdminInfos()
        {
            dynamic DynamicData = ConvertJsonStrToDynamic();
            Console.WriteLine("Nombre de participations: "+DynamicData.AdminInfo.nbParticipation);
            Console.WriteLine("Taux de réussite: "+DynamicData.AdminInfo.successRate+"%");
            Console.WriteLine("Nombre de participants validé le quiz: "+DynamicData.AdminInfo.nbParticipationCorrect);
        }

    }
}
