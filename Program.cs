using Newtonsoft.Json;
using System;

namespace LoginQuiz
{
    class Program
    {
        static void Main(string[] args)
        {

            string filePath = @"C:\Users\utilisateur\source\repos\LoginQuiz\quizdetails.json";
            StreamReader streamReader = new StreamReader(filePath);
            string jsonStr = streamReader.ReadToEnd();
            dynamic DynamicData = JsonConvert.DeserializeObject(jsonStr);

            // login for the user -----------------------------------------------
            Console.WriteLine("---------- CONNEXION DU USER ----------");
            Console.WriteLine("Entrez votre pseudo:");
            string nameUser = Console.ReadLine();
            string nameUserJson = DynamicData.Users[1].Name;
            Console.WriteLine("Entrez votre mot de passe:");
            string passwordUser = Console.ReadLine();
            string passwordUserJson = DynamicData.Users[1].Password;

            if (nameUser == nameUserJson)
            {
                Console.WriteLine("Pseudo OK!");
                if(passwordUser == passwordUserJson) {
                    Console.WriteLine("Mot de passe OK!");
                }
                Console.WriteLine("Vous etes connecté!");
            } else
            {
                Console.WriteLine("Les identifiants sont incorrects.");
            }


            // login for the admin -----------------------------------------------
            Console.WriteLine("---------- CONNEXION DU ADMIN ----------");
            Console.WriteLine("Entrez votre pseudo:");
            string nameAdmin = Console.ReadLine();
            string nameAdminJson = DynamicData.Users[0].Name;
            Console.WriteLine("Entrez votre mot de passe:");
            string passwordAdmin = Console.ReadLine();
            string passwordAdminJson = DynamicData.Users[0].Password;

            if (nameAdmin == nameAdminJson)
            {
                Console.WriteLine("Pseudo OK!");
                if (passwordAdmin == passwordAdminJson)
                {
                    Console.WriteLine("Mot de passe OK!");
                }
                Console.WriteLine("Vous etes connecté!");
            }
            else
            {
                Console.WriteLine("Les identifiants sont incorrects.");
            }


            /*
            Console.WriteLine(DynamicData.Users[0].Name); 
            Console.WriteLine(DynamicData.Users[0].Password);
            Console.WriteLine(DynamicData.Users[1].Name);
            Console.WriteLine(DynamicData.Users[1].Password);

            Console.WriteLine(DynamicData.Questions[0].Name);
            Console.WriteLine(DynamicData.Questions[1].Name);
            Console.WriteLine(DynamicData.Questions[2].Name);
            Console.WriteLine(DynamicData.Questions[3].Name);

            Console.WriteLine(DynamicData.Answers[0].Name);
            Console.WriteLine(DynamicData.Answers[1].Name);
            Console.WriteLine(DynamicData.Answers[2].Name);
            Console.WriteLine(DynamicData.Answers[3].Name);
            */

        }
    }
}