using System;
using System.Collections.Generic;
using System.Linq;

namespace Genetic_alghoritm
{
    class Program
    {
        static void Main(string[] args)
        {
            PopulationGenerator generator = new PopulationGenerator(5, 50);
            generator.Pattern = "10011001011001100101100110010110011001011001100101"; //Tymczasowo stała. LettersCount musi być więc 10!
            List<Parent> parents = generator.GenerateChildren().ToList();
            //Wyświetlenie nazw rodziców
            Console.WriteLine("Parents:");
            foreach (var item in parents)
            {
                Console.WriteLine(item.Name);
            }
            //Sprawdzenie fitnessu rodziców
            Console.WriteLine("Parents fitness:");
            generator.CompariseToPattern(parents);
            foreach (var item in parents)
            {
                Console.WriteLine(item.Points);
            }
            //Generowanie dzieci
            Console.WriteLine("Children:");
            NextPopulationGenerator crossingGenerator = new NextPopulationGenerator(5, 50); //Dużo więcej dzieci
            List<Parent> children = crossingGenerator.GenerateChildren(parents).ToList();
            foreach (var item in children)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("Children fitness:");
            crossingGenerator.Pattern = "10011001011001100101100110010110011001011001100101";
            crossingGenerator.CompariseToPattern(children);
            foreach (var item in children)
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
        public int LettersCount { get; set; }
        public int ParentsCount { get; set; }
        public string Pattern { get; set; }
        public PopulationGenerator(int amountofParents, int amountOfLetters)
        {
            LettersCount = amountOfLetters;
            ParentsCount = amountofParents;
        }
        public int AmountOfLetters { get; set; }
        public IEnumerable<Parent> Parents { get; set; }
        public virtual IEnumerable<Parent> GenerateChildren()
        {
            for (int i = 0; i < ParentsCount; i++)
            {
                yield return new Parent { Name = GenerateName() };
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

            foreach (var item in parents)
            {
                int sum = 0;
                for (int i = 0; i < LettersCount; i++)
                {
                    if (item.Name[i] == Pattern[i])
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
        public NextPopulationGenerator(/*int probability,*/ int amountofParents, int amountOfLetters) : base(amountofParents, amountOfLetters)
        {
        }
        public IEnumerable<Parent> GenerateChildren(List<Parent> parents)
        {
            for (int i = 0; i < ParentsCount; i++) //Wiele razy powtórzyć
            {
                yield return new Parent { Name = GenerateChildName(parents) };
            }
        }
        public string GenerateChildName(List<Parent> parents)  //Krzyżowanie //Domyślnie 2 rodziców
        {
            string name = "";
            Random rnd2 = new Random();
            int crossingPoint = rnd2.Next(0, LettersCount);
            Random chosenParentGen = new Random();
            int chosenParent = chosenParentGen.Next(0, parents.Count); //Losują się wszyscy bez względu na points.
            string FirstGenom = parents[chosenParent].Name.Substring(1, crossingPoint);
            int chosenParent2 = chosenParentGen.Next(0, parents.Count);
            if (chosenParent == chosenParent2)
            {
                chosenParent2 = chosenParentGen.Next(0, parents.Count); //Nie zabezpieczam przed drugim razem?

            }
            string SecondGenom = parents[chosenParent2].Name.Substring(crossingPoint);
            name = FirstGenom + SecondGenom;
            return name;
            // V.1
            //string FirstGen = parents[0].Name.Substring(0, crossingPoint);
            //string SecondGen = parents[1].Name.Substring(crossingPoint);
            //name += FirstGen + SecondGen;
            //return name;
        }
    }
}
