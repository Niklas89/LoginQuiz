using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginQuiz
{
    public class Menu
    {

        public void Login()
        {
            /*
            string filePath = @"C:\Users\utilisateur\source\repos\LoginQuizv2\quizdetails.json";
            StreamReader streamReader = new StreamReader(filePath);
            string jsonStr = streamReader.ReadToEnd();
            JSONModel.Rootobject record = JsonConvert.DeserializeObject<JSONModel.Rootobject>(jsonStr); //  JSON.Net
            */
            
            string nameUserJson = JSONModel.JsonReader().users.username;
            string nameAdminJson = JSONModel.JsonReader().users.admin;
            string passwordUserJson = JSONModel.JsonReader().users.userpass;
            string passwordAdminJson = JSONModel.JsonReader().users.adminpass;

            Console.WriteLine("Connectez-vous");
            Console.WriteLine("Identifiant:");
            string name = Console.ReadLine();
            Console.WriteLine("Mot de Passe:");
            string password = Console.ReadLine();
            checkUser(name, password, nameUserJson, nameAdminJson, passwordUserJson, passwordAdminJson);

            /*
            Console.WriteLine("Users infos");
            Console.WriteLine(record.users.admin);
            Console.WriteLine(record.users.adminpass);
            Console.WriteLine(record.users.username);
            Console.WriteLine(record.users.userpass);
            Console.WriteLine();

            Console.WriteLine("Questions: ");
            Console.WriteLine(record.questions.question1);
            Console.WriteLine(record.questions.question2);
            Console.WriteLine(record.questions.question3);
            Console.WriteLine(record.questions.question4);
            Console.WriteLine();

            Console.WriteLine("Answers");
            Console.WriteLine(record.answers.answer1);
            Console.WriteLine(record.answers.answer2);
            Console.WriteLine(record.answers.answer3);
            Console.WriteLine(record.answers.answer4);

            Console.WriteLine("Admin infos");
            Console.WriteLine(record.adminInfo.nbParticipation);
            Console.WriteLine(record.adminInfo.nbParticipationCorrect);
            Console.WriteLine(record.adminInfo.successRate);
            Console.WriteLine();

            */

        }


        public void checkUser(string name, string password, string nameUserJson, string nameAdminJson, string passwordUserJson, string passwordAdminJson) 
        {
            if(name == nameUserJson)
            {
                if (password == passwordUserJson)
                {
                    Console.WriteLine(" user correct");
                    Quiz quiz = new Quiz();
                    quiz.init();
                } else
                {
                    Console.WriteLine("MDP incorrect");
                }

            } else if(name == nameAdminJson)
            {
                if (password == passwordAdminJson)
                {
                    Console.WriteLine(" admin correct");
                    // rediriger vers page Admin
                } else
                {
                    Console.WriteLine("MDP incorrect");
                }

            } else
            {
                Console.WriteLine("Mauvais identifiants");
            }
            
        }
    }
}
