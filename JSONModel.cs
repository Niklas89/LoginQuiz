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
        public const string filePath = @"C:\Users\utilisateur\source\repos\LoginQuiz\LoginQuizv3\jsondetails.json";

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



        public static void ShowScoreInfo()
        {
            dynamic DynamicData = ConvertJsonStrToDynamic();
            Console.WriteLine("Nombre de participants : "+DynamicData.AdminInfo.nbParticipation);
            Console.WriteLine("Nombre de ayant validé correctement le quiz (score supérieur ou égal à la moyenne) : " + DynamicData.AdminInfo.nbParticipationCorrect);
            Console.WriteLine("Taux de réussite : " + DynamicData.AdminInfo.successRate+"%");
        }



        public static void AddOneQuestion(string newQuestion)
        {
            dynamic DynamicData = ConvertJsonStrToDynamic();
            string jsonStr = JsonConvert.SerializeObject(DynamicData.Questions);
            StringBuilder sb = new StringBuilder(jsonStr);
            sb.Insert(sb.Length-1, $", \"{newQuestion}\"");
            jsonStr = sb.ToString();
            DynamicData.Questions = JsonConvert.DeserializeObject(jsonStr);
            jsonStr = JsonConvert.SerializeObject(DynamicData);
            WriteStream(jsonStr);
        }



        public static void AddOneAnswer(string newAnswer)
        {
            dynamic DynamicData = ConvertJsonStrToDynamic();
            string jsonStr = JsonConvert.SerializeObject(DynamicData.Answers);
            StringBuilder sb = new StringBuilder(jsonStr);
            sb.Insert(sb.Length - 1, $", \"{newAnswer}\"");
            jsonStr = sb.ToString();
            DynamicData.Answers = JsonConvert.DeserializeObject(jsonStr);
            jsonStr = JsonConvert.SerializeObject(DynamicData);
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
                }
                else
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




        // Change a question
        public static void RemoveQuestAnsw()
        {
            Console.WriteLine("Indiquez la question et sa réponse à supprimer dans la liste ci-dessous:");
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
                Console.WriteLine("Réponse: "+ question.Answer);

                if (Questionlist.Count() == 1)
                {
                    Console.WriteLine("Il reste qu'une question dans le Quiz, vous ne pouvez pas la supprimer, veuillez en ajouter plus.");
                    Console.ReadKey();
                    return;
                }
            }
            int numQuestion = 0;
            bool res = true;
            while (res)
            {
                Console.WriteLine("Quelle question souhaitez vous supprimer? Tapez le numéro correspondant.");
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
            // affiche toutes les questions une par une et supprime celle qui correspond
            // FORMAT DU JSON DOIT ETRE COMME CECI POUR QUE CELA FONCTIONNE:
            // "Questions": ["Premiere question", "Deuxieme question", "Troisieme question", "Quatrieme question"],
	        // "Answers": ["Premiere reponse", "Deuxieme reponse", "Troisieme reponse", "Quatrieme reponse"],
            foreach (Question question in Questionlist)
            {
                ++i;
                if (i == numQuestion)
                {
                    int charIndexAnswRemove = -2;
                    int charIndexQuestRemove = -2;
                    if (i == 1)
                    {
                        charIndexQuestRemove = -1;
                        charIndexAnswRemove = 2;
                    } 
                    // check longueur de string question et son index dans la string jsonStr 
                    // pour la supprimer de la string total à envoyer dans le StreamWriter
                    StringBuilder sbquest = new StringBuilder(question.Ask);
                    int questlength = sbquest.Length;
                    int questindex = jsonStr.IndexOf(question.Ask);
                    questlength = questlength + 3; // enlever les " dans le json
                    questindex = questindex + charIndexQuestRemove; // si cest le premier element de la liste faudra faire -1 au lieu de -3

                    // meme chose pour la réponse qui doit etre supprimée en meme temps
                    StringBuilder sbanswer = new StringBuilder(question.Answer);
                    int answerlength = sbanswer.Length;
                    int answerindex = jsonStr.IndexOf(question.Answer);
                    answerlength = answerlength + 3; // enlever les " dans le json
                    answerindex = (answerindex + charIndexAnswRemove) - (questlength + 3); // si cest le premier element de la liste faudra faire -1

                    // reponse et question se suppriment
                    sb.Remove(questindex, questlength);
                    sb.Remove(answerindex, answerlength);
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

        public static void InsertHashedPasswords(string password, string user)
        {
            dynamic DynamicData = ConvertJsonStrToDynamic();
            if(user == "user")
            {
                DynamicData.Users.Userpass = password;
            } else if(user == "admin")
            {
                DynamicData.Users.Adminpass = password;
            }
            string jsonStr = JsonConvert.SerializeObject(DynamicData);
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
