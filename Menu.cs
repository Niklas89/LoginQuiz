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
                    Admin admin = new Admin();
                    admin.initAdmin();
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
