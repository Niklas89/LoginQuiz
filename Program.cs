using Newtonsoft.Json;
using System;
using System.Text;

namespace LoginQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Login();
        }
    }
}





/*
           JObject videogameRatings = new JObject(
           new JProperty("Halo", 9),
           new JProperty("Starcraft", 9),
           new JProperty("Call of Duty", 7.5)); */


/*
Console.WriteLine(JSONModel.Serialize());
string jsonstring = JSONModel.Serialize();
JArray item = (JArray)channel["item"];
item.Add("Item 1");
item.Add("Item 2");
// https://www.tutorialsteacher.com/csharp/csharp-stringbuilder
// https://www.c-sharpcorner.com/article/6-effective-ways-to-concatenate-strings-in-c-sharp-and-net-core/
System.Text.StringBuilder builder = new System.Text.StringBuilder("Mahesh Chand");
builder.Append(", ");
builder.Append("Chris Love");
builder.Append(", Praveen Kumar");

StringBuilder sb = new StringBuilder("Hello World!");
sb.Replace("World", "C#");

File.WriteAllText(@"C:\Users\utilisateur\Desktop\student.json", JSONModel.Serialize());
*/



// write JSON directly to a file
/*
using (StreamWriter file = File.CreateText(@"c:\videogames.json"))
using (JsonTextWriter writer = new JsonTextWriter(file))
{
    videogameRatings.WriteTo(writer);
} */



/*
dynamic question = new JSONModel.Questions();
question.question1 = "Elbow Grease";
question.question2 = "Elbow Grease2";
question.question3 = "Elbow Grease3";
question.question4 = "Elbow Grease4";
product.Tags = new JArray("Real", "OnSale");
Console.WriteLine(question.ToString()); */