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
                return;
            }
            // change answer
            if (adminChoice == "rchange")
            {
                adminChangeAnswer();
                return;
            }
            // add question
            if (adminChoice == "add")
            {
                adminAddQuestAnsw();
                return;
            }
            // remove question and answer
            if (adminChoice == "remove")
            {
                adminRemoveQuestAnsw();
                return;
            }
            // add question
            if (adminChoice == "questions")
            {
                adminShowQuestions();
                return;
            } 
            // show admin infos about participants
            if (adminChoice == "infos")
            {
                Console.Clear();
                Display.DisplayAdminInfos();
                goBackToAdminMenu();
                return;
            }
        }
        public void adminChangeQuestion()
        {
            bool keepChanging = true;
            while (keepChanging)
            {
                Console.Clear();
                JSONModel.ChangeOneQuestion();
                Console.WriteLine("Votre question a bien été changée et ajoutée au document.");
                Console.WriteLine("Souhaitez vous changer encore une question? Oui: 'o' / Non: 'n");
                string? wishChange = Console.ReadLine().ToLower();
                if (wishChange == "n")
                {
                    keepChanging = false;
                }
            }
            initAdmin();
        }
        public void adminAddQuestAnsw()
        {
            bool keepChanging = true;
            while (keepChanging)
            {
                Console.Clear();
                Console.WriteLine("Veuillez écrire la question que vous souhaitez ajouter");
                string newQuestion = Console.ReadLine();
                JSONModel.AddOneQuestion(newQuestion);
                Console.WriteLine("Votre question ajoutée au document.");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Veuillez écrire la réponse que vous souhaitez ajouter");
                string newAnswer = Console.ReadLine();
                JSONModel.AddOneAnswer(newAnswer);
                Console.WriteLine("Votre réponse ajoutée au document.");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Souhaitez vous ajouter encore une question et sa réponse ? Oui: 'o' / Non: 'n");
                string? wishChange = Console.ReadLine().ToLower();
                if (wishChange == "n")
                {
                    keepChanging = false;
                }
            }
            initAdmin();
        }
        public void adminRemoveQuestAnsw()
        {
            bool keepChanging = true;
            while (keepChanging)
            {
                Console.Clear();
                JSONModel.RemoveQuestAnsw();
                Console.WriteLine("Votre question et sa réponse ont bien été supprimé");
                Console.WriteLine("Souhaitez vous supprimer encore une question et réponse ? Oui: 'o' / Non: 'n");
                string? wishChange = Console.ReadLine().ToLower();
                if (wishChange == "n")
                {
                    keepChanging = false;
                }
            }
            initAdmin();
        }
        public void adminChangeAnswer()
        {
            bool keepChanging = true;
            while (keepChanging)
            {
                Console.Clear();
                JSONModel.ChangeOneAnswer();
                Console.WriteLine("Votre réponse a bien été changée et ajoutée au document.");
                Console.WriteLine("Souhaitez vous changer encore une réponse? Oui: 'o' / Non: 'n");
                string? wishChange = Console.ReadLine().ToLower();
                if (wishChange == "n")
                {
                    keepChanging = false;
                }
            }
            initAdmin();
        }
        public void adminShowQuestions()
        {
            bool keepChanging = true;
            while (keepChanging)
            {
                Console.Clear();
                Quiz.ShowQuestions();
                Console.WriteLine();
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Souhaitez vous revenir au menu admin? Oui: 'o' ");
                string? wishChange = Console.ReadLine().ToLower();
                if (wishChange == "o")
                {
                    keepChanging = false;
                }
            }
            initAdmin();
        }
        public void goBackToAdminMenu()
        {
            bool keepChanging = true;
            while (keepChanging)
            {
                Console.WriteLine();
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Souhaitez vous revenir au menu admin? Oui: 'o' ");
                string? wishChange = Console.ReadLine().ToLower();
                if (wishChange == "o")
                {
                    keepChanging = false;
                }
            }
            initAdmin();
        }
    }
}

