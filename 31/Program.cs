using System;
using MyDataManager;

namespace MyDataManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name:");
            var name = Console.ReadLine();

            Console.WriteLine("Please enter your age:");
            var age = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            Console.WriteLine("Please enter your email:");
            var email = Console.ReadLine();

            var person = new PersonData { Name = name, Age = age, Email = email };

            XMLManager xmlManager = new XMLManager(person);
            JSONManager jsonManager = new JSONManager(person);

            xmlManager.Save("data.xml");
            jsonManager.Save("data.json");

            xmlManager.Load("data.xml");
            jsonManager.Load("data.json");
        }
    }
}
