using System;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTasks_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\Users\baez1\Documents\Problemas del posible empleo\input.txt";
            string jsonFile = File.ReadAllText(fileName); //Convert the "input" text file into a string
            List<MovieStar> ms = JsonConvert.DeserializeObject<List<MovieStar>>(jsonFile); //Deserialize "jsonFile" into a list of MovieStar objects called ms
            DateTime birthday, today = DateTime.Today; //Declaring and initializing these variables for use in the age algorithm
            int age = 0;

            foreach (var item in ms)
            {
                Console.WriteLine(item.Name + " " + item.Surname); //Display full name
                Console.WriteLine(item.Sex); //Display sex
                Console.WriteLine(item.Nationality); //Display nationality

                // Algorithm that calculates age from date of birth
                birthday = Convert.ToDateTime(item.dateOfBirth);
                age = today.Year - birthday.Year;
                if (birthday > today.AddYears(-age))
                    age--;

                Console.WriteLine(age + " years old\n"); //Display age
            }
            Console.ReadKey();
        }
    }
}
