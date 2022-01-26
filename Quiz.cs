using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginQuiz
{
    public class Quiz
    {
        public List<Question> QuestionList { get; set; }

        public void init()
        {
            // créer une liste de questions 
            List<Question> Questionlist = new List<Question>();


            // récupere les questions dans le fichier
            Questionlist = JSONModel.GetAllQuestions();

            // lance le questionnaire 
            Start(Questionlist);
        }

        public void Start(List<Question> questions)
        {
            Console.WriteLine("Repondez au Quiz");
            StartQuiz(questions);
        }

        public void StartQuiz(List<Question> questions)
        {
            int i = 0;

            // affiche toutes les questions une par une 
            foreach (Question question in questions)
            {

                Console.WriteLine("Question n° " + ++i);
                Console.WriteLine(question.Ask);
                Display.DisplayAnswers(question);
                Console.WriteLine(question.Answer);
                Console.Clear();
            }
            // FAIRE LE CALCULE DE SCORE ET COMPARER AVEC REPONSE USER
            // calcul le score 
            //int score = quizResult(questions);
            //Console.WriteLine($"Le resultat de votre quiz et de {score} sur {questions.Count()}");

        }

        public static string CheckAnswer()
        {
            string answer;

            // verifie que l'utilisateur réponde a la réponse et ne laisse pas un message vide 
            do
            {
                Console.WriteLine("Ecrivez votre réponse:");
                answer = Console.ReadLine();

            } while (string.IsNullOrEmpty(answer));

            return answer;
        }
    }
}
