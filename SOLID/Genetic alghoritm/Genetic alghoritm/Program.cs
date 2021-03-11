using System;
using System.Collections.Generic;
using System.Linq;

namespace Genetic_alghoritm
{
    class Program
    {
        static void Main(string[] args)
        {
            PopulationGenerator generator = new PopulationGenerator(5,50);
            generator.Pattern = "10011001011001100101100110010110011001011001100101"; //Tymczasowo stała. LettersCount musi być więc 10!
            List<Parent> parents = generator.GenerateChildren().ToList();
            foreach(var item in parents)
            {
                Console.WriteLine(item.Name);
            }
            generator.CompariseToPattern(parents);
            foreach (var item in parents)
            {
                Console.WriteLine(item.Points);
            }
        }
    }

    public class Parent
    {
        public string Name { get; set; }
        public int Points { get; set; }
    }

    public class PopulationGenerator
    {
        public int LettersCount{ get; set; }
        public int ParentsCount{ get; set; }
        public string Pattern { get; set; }
        public PopulationGenerator(int amountofParents, int amountOfLetters)
        {
            LettersCount = amountOfLetters;
            ParentsCount = amountofParents;
        }
        public int AmountOfLetters{ get; set; }
        public IEnumerable<Parent> Parents { get; set; }
        public virtual IEnumerable<Parent> GenerateChildren()
        {     
            for (int i = 0; i < ParentsCount; i++)
            {
                yield return new Parent { Name = GenerateName()};
            }
        }

        public string GenerateName()
        {
            string name = "";
            Random rnd = new Random();
            for (int i = 0; i < LettersCount; i++)
            {
                name += rnd.Next(0, 2).ToString();
            }
            return name;
        }

        public void CompariseToPattern(List<Parent> parents)
        {
            
            foreach(var item in parents)
            {
                int sum = 0;
                for(int i = 0; i < LettersCount; i++)
                {
                    if(item.Name[i] == Pattern[i])
                    {
                        sum++;
                    }
                }
                item.Points = sum;
            }
        }
    }

    public class NextPopulationGenerator : PopulationGenerator
    {
        public int ProbabilityOfMutaion { get; set; }
        public NextPopulationGenerator(int probability,int amountofParents, int amountOfLetters) : base(amountofParents, amountOfLetters)
        {
            ProbabilityOfMutaion = probability;
        }
        public override IEnumerable<Parent> GenerateChildren()
        {
            for (int i = 0; i < ParentsCount; i++)
            {
                yield return new Parent { Name = GenerateName()};
            }
        }
        public string GenerateName(Parent parent) //Nie dokończone.
        {
            string name = "";
            Random rnd = new Random();
            int n = rnd.Next(0, 101);
            if(n > ProbabilityOfMutaion)
            for (int i = 0; i < LettersCount; i++)
            {
                name += rnd.Next(0, 2).ToString();
            }
            return name;
        }
    }
}
