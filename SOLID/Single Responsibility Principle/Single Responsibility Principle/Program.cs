using System;
using System.Diagnostics;

namespace Single_Responsibility_Principle
{
    class Program
    {
       

        static void Main(string[] args)
        {
            //Persistence and Journual classes are connected to those lines!
            //var j = new Journal();
            //j.AddEntry("I cried today");
            //j.AddEntry("I ate a bug");
            //Console.WriteLine(j);


            //var p = new Persistence();
            //var filename = @"C:\Users\Flutter shy\Desktop\Backend education\journal.txt";
            //p.SaveToFile(j, filename, true);
            //var d = new Process();
            //d.StartInfo = new ProcessStartInfo(filename)
            //{ UseShellExecute = true};
            //d.Start();

            StandardMessages.WelcomeMessage();
            Person user = PersonDataCapture.Capture();
            bool isUserValid = PersonValidator.ValidatePerson(user);
            if(!isUserValid == false)
            {
                StandardMessages.EndApplication();
                return;
            }
            Console.WriteLine( $"Your username is {user.FirstName.Substring(0,1)}{user.LastName}");
            StandardMessages.EndApplication();
            AccountGenerator.CreateAccount(user);
        }
    }


}
