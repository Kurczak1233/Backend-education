using System;

namespace Single_Responsibility_Principle
{
    public class StandardMessages
    {
        public static void WelcomeMessage() //THIS IS VIOLATING REVERSE INJECTION PRINCIPLE!  (but here is ok)
        {
            Console.WriteLine("Welcome to my app");
        }
        public static void EndApplication()
        {
            Console.ReadLine();
        }

        public static void DisplayValidationError(string fieldName)
        {
            Console.WriteLine($"{fieldName} is not valid!");
        }
    }


}
