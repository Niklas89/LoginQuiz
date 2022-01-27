using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            Console.Clear();
            Console.WriteLine("Repondez au Quiz");
            Console.WriteLine("_________________________");
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
            // calcul le score 
            int score = quizResult(questions);
            Console.WriteLine($"Le resultat de votre quiz et de {score} sur {questions.Count()}");

        }

        public int quizResult(List<Question> questions)
        {
            int result = 0;
            int validedQuiz = 0;

            Console.WriteLine("resultat du Quiz");

            // verifie si une réponse est bonne ou non 
            foreach (Question question in questions)
            {
                bool goodAnswer = true;

                foreach (string response in question.UserAnswers)
                {
                    Regex rgx = new Regex($@"\b{Regex.Escape(question.Answer)}\b");
                    //if (!question.Answer.Contains(response))
                    if (!rgx.IsMatch(response))
                            goodAnswer = false;
                }

                if (!goodAnswer)
                {
                    Display.DisplayWrongAnswer(question);
                    continue;
                } else
                {
                    Display.DisplayGoodAnswer(question);
                    result++;
                }

            }
            double average = (double)  (result*100) / questions.Count();
            if(average >= 50)
            {
                validedQuiz = 1;
            }
            Console.WriteLine("Taux de réussite: " + average + "%");
            JSONModel.ChangeScoreInfo(1, validedQuiz);
            return result;
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
