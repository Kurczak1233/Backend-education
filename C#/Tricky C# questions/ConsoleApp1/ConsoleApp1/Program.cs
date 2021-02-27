using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static String str;
        static DateTime date;
        delegate void MyDelegate();
        static void Main(string[] args)
        {
            //TASK 1//
            string myString = (string)null; //Rzutowanie jest zbędne - null to null. 
            Console.WriteLine(myString is string); //False

            //TASK 2//
            Console.WriteLine(Math.Round(5.5));  //Przybliżanie do najbliżej możliwej 6
            Console.WriteLine(Math.Round(6.5));  // -||- 6

            //TASK 3//
            Console.WriteLine(str == null ? "str == null" : str); //null
            Console.WriteLine(date == null ? "str == null" : date.ToString()); //Wyświetli datę zawartą w date. (0001-01-01...)

            //TASK 4//
            var delegates = new List<MyDelegate>();
            for(int i =0;i < 6; i++)
            {
                delegates.Add(delegate { Console.WriteLine(i); });
            }

            foreach(var @delegate in delegates)
            {
                @delegate(); // 6 x 6
            }
            
        }
    }
}
