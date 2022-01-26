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
            Console.WriteLine("Cher administrateur bienvenue, que voulez vous faire ?? ");
            Console.WriteLine("Tapez Add pour ajouter une question au fichier ");
        }

        // gére la demande de reponse et l'ajoute a l'objet question
        public static void DisplayAnswers(Question question)
        {
            string answer = Quiz.CheckAnswer();
            question.UserAnswers.Add(answer);
            

        }

    }
}
