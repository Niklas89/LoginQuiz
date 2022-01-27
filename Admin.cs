using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginQuiz
{
    public class Admin
    {
        public void initAdmin()
        {
            Display.DisplayMenuAdmin();
            string? adminChoice = Console.ReadLine().ToLower();
            
            // change question
            if (adminChoice == "qchange")
            {
                adminChangeQuestion();
            }
            // change answer
            else if (adminChoice == "rchange")
            {
                adminChangeAnswer();
            }
            else if (adminChoice == "logout")
            {
                Console.Clear();
                Menu menu = new Menu();
                menu.Login();
            }
            initAdmin();
        }
        public void adminChangeQuestion()
        {
            bool keepChanging = true;
            while (keepChanging)
            {
                JSONModel.ChangeOneQuestion();
                Console.WriteLine("Votre question a bien été changée et ajoutée au document.");
                Console.WriteLine("Souhaitez vous changer encore une question? Oui: 'o' / Non: 'n");
                string? wishChange = Console.ReadLine().ToLower();
                if (wishChange == "n")
                {
                    keepChanging = false;
                }
            }
        }
        public void adminChangeAnswer()
        {
            bool keepChanging = true;
            while (keepChanging)
            {
                JSONModel.ChangeOneAnswer();
                Console.WriteLine("Votre réponse a bien été changée et ajoutée au document.");
                Console.WriteLine("Souhaitez vous changer encore une réponse? Oui: 'o' / Non: 'n");
                string? wishChange = Console.ReadLine().ToLower();
                if (wishChange == "n")
                {
                    keepChanging = false;
                }
            }
        }
    }
}

