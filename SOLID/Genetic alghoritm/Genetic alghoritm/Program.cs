using System;
using System.Collections.Generic;
using System.Linq;

namespace Genetic_alghoritm
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstPopulationGenerator generator = new FirstPopulationGenerator(5, 50);
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
            NextPopulationGenerator childGenerator = new NextPopulationGenerator(5, 50); //Dużo więcej dzieci
            List<Parent> childrenGeneration = childGenerator.GenerateChildren(parents).ToList();
            foreach (var item in childrenGeneration)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("Children fitness:");
            childGenerator.Pattern = "10011001011001100101100110010110011001011001100101";
            childGenerator.CompariseToPattern(childrenGeneration);
            var children = childrenGeneration.OrderByDescending(x => x.Points).Take(5).ToList();
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

    public class FirstPopulationGenerator
    {
        public int LettersCount { get; set; }
        public int ParentsCount { get; set; }
        public string Pattern { get; set; }
        public FirstPopulationGenerator(int amountofParents, int amountOfLetters)
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

    public class NextPopulationGenerator : FirstPopulationGenerator
    {

        public NextPopulationGenerator(int amountofParents, int amountOfLetters) : base(amountofParents, amountOfLetters)
        {
        }
        public IEnumerable<Parent> GenerateChildren(List<Parent> parents)
        {
            for (int i = 0; i < 50; i++) //Wiele razy powtórzyć
            {
                yield return new Parent { Name = GenerateChildName(parents) };
            }
        }
        public string GenerateChildName(List<Parent> parents)  //Krzyżowanie //Domyślnie 2 rodziców
        {
            //System prawdopodobieństwa krzyżowania najlepszych (najwięcej punktów)
            string[] probabiltyStrings = new string[parents.Count];
            string allProbabilitiesStrings = "";
            for (int i = 0; i < 5;i++)
            {
                for(int j = 0; j < parents[i].Points; j++)
                {
                    probabiltyStrings[i] += i;
                }
                allProbabilitiesStrings += probabiltyStrings[i];
            }
            //Losowa z fitnessem
            string name = "";
            Random rnd2 = new Random();
            int crossingPoint = rnd2.Next(0, LettersCount);
            //First parent
            var Parent1 = ChoseParentToReproduce(allProbabilitiesStrings, parents);
            string FirstGenom = Parent1.Name.Substring(1, crossingPoint);
            //Second parent
            var Parent2 = ChoseParentToReproduce(allProbabilitiesStrings, parents);

            while(CheckParentsAreTheSame(Parent1, Parent2)) //Bez samogwałtów
            {
                Parent2 = ChoseParentToReproduce(allProbabilitiesStrings, parents);
            }
            string SecondGenom = Parent2.Name.Substring(crossingPoint);
            name = FirstGenom + SecondGenom;
            return name;

            //Losowa bez uwzgl. fitness'u
            //string name = "";
            //Random rnd2 = new Random();
            //int crossingPoint = rnd2.Next(0, LettersCount);
            //Random chosenParentGen = new Random();
            //int chosenParent = chosenParentGen.Next(0, parents.Count); //Losują się wszyscy bez względu na points.
            //string FirstGenom = parents[chosenParent].Name.Substring(1, crossingPoint);
            //int chosenParent2 = chosenParentGen.Next(0, parents.Count);
            //if (chosenParent == chosenParent2)
            //{
            //    chosenParent2 = chosenParentGen.Next(0, parents.Count); //Nie zabezpieczam przed drugim razem?

            //}
            //string SecondGenom = parents[chosenParent2].Name.Substring(crossingPoint);
            //name = FirstGenom + SecondGenom;
            //return name;

            //Turniejowa
            //var orderedParents = parents.OrderByDescending(x => x.Points);
            //var parent1 = orderedParents.Select(x=>x).FirstOrDefault();
            //var parent2 = orderedParents.Select(x => x).Skip(1).FirstOrDefault();
            //string firstGen = parent1.Name.Substring(1, crossingPoint);
            //string secondGen = parent2.Name.Substring(crossingPoint);
            //name = firstGen + secondGen;
            //return name;
        }

        private bool CheckParentsAreTheSame(Parent parent1, Parent parent2)
        {
            if(parent1 == parent2)
            {
                return true;
            }
            return false;
        }

        public Parent ChoseParentToReproduce(string generationString, List<Parent> parents)
        {
            Random chosenParentGen = new Random();
            int probabilityChoice = chosenParentGen.Next(0, generationString.Length);
            int chosenParent1 = generationString[probabilityChoice];
            return parents[chosenParent1];
        }
    }
}
