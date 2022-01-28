using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginQuiz
{
    public class Display
    {

        public static void DisplayMenuAdmin()
        {
            Console.Clear();
            Console.WriteLine("Cher administrateur bienvenue, que voulez vous faire ?");
            Console.WriteLine("Tapez 'qchange' pour changer une question dans le fichier.");
            Console.WriteLine("Tapez 'rchange' pour changer une réponse dans le fichier.");
            Console.WriteLine("Tapez 'qadd' pour ajouter une question dans le fichier.");
            Console.WriteLine("Tapez 'radd' pour ajouter une réponse dans le fichier.");
            Console.WriteLine("Tapez 'questions' pour afficher la liste des questions");
            Console.WriteLine("Tapez 'infos' pour voir le nombre de participants et le taux de réussite.");
        }

        // gére la demande de reponse et l'ajoute a l'objet question
        public static void DisplayAnswers(Question question)
        {
            string answer = Quiz.CheckAnswer();
            question.UserAnswers.Add(answer);
        }

        public static void DisplayAdminInfos()
        {
            JSONModel.GetAdminInfos();
        }

        // gere les réponses fausses 
        public static void DisplayWrongAnswer(Question question)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Pour la question " + question.Ask + ", vous avez répondu ");

            foreach (string answer in question.UserAnswers)
            {
                Console.Write(" " + answer + " ");
            }

            Console.Write(" tandis qu'il fallait répondre " + question.Answer + "\n");


            Console.ResetColor();
        }

        // gere les bonnes réponses 
        public static void DisplayGoodAnswer(Question question)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pour la question " + question.Ask + ", vous avez donné une bonne réponse ");
            Console.ResetColor();
        }

        // gere les bonnes réponses 
        public static void DisplayQuestionList(Question question)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pour la question " + question.Ask + ", vous avez donné une bonne réponse ");
            Console.ResetColor();
        }

    }
}
