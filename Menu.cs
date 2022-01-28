using System;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LoginQuiz
{
    public class Menu
    {

        public void Login()
        {
            string nameUserJson = JSONModel.ConvertJsonStrToDynamic().Users.Username;
            string nameAdminJson = JSONModel.ConvertJsonStrToDynamic().Users.Admin;
            string passwordUserJson = JSONModel.ConvertJsonStrToDynamic().Users.Userpass;
            passwordUserJson = checkIfPasswordIsHashed(passwordUserJson, "user");
            string passwordAdminJson = JSONModel.ConvertJsonStrToDynamic().Users.Adminpass;
            passwordAdminJson = checkIfPasswordIsHashed(passwordAdminJson, "admin");

            Console.WriteLine("Connectez-vous");
            Console.WriteLine("Identifiant:");
            string name = Console.ReadLine();
            Console.WriteLine("Mot de Passe:");
            string password = Console.ReadLine();
            password = ComputeSha256Hash(password);
            checkUser(name, password, nameUserJson, nameAdminJson, passwordUserJson, passwordAdminJson);
        }

        public static string checkIfPasswordIsHashed(string password, string user)
        {
            Regex rgx = new Regex("^[a-f0-9]{64}$");
            if (!rgx.IsMatch(password))
            {
                if(user == "admin")
                {
                    password = ComputeSha256Hash(password);
                    JSONModel.InsertHashedPasswords(password, "admin");
                } else if (user == "user")
                {
                    password = ComputeSha256Hash(password);
                    JSONModel.InsertHashedPasswords(password, "user");
                }
                Console.WriteLine("MDP converti en hash");

            } else
            {
                Console.WriteLine("C'est deja bien hashé");
            }
            return password;
            
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Convert byte array to a string   
            StringBuilder builder = new StringBuilder();

            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                try
                {
                    // ComputeHash - returns byte array  
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine($"I/O Exception: {e.Message}");
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine($"Access Exception: {e.Message}");
                }
                return builder.ToString();
            }
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
