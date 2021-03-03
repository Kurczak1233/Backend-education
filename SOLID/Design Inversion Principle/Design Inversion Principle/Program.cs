using System;
using System.Collections.Generic;
using System.Linq;

namespace Design_Inversion_Principle
{   
    public enum RelationShip
    {
        Parent,
        Child,
        Sibling
    }

    public interface IRelationShipBrowser
    {
        IEnumerable<Person> FindAllChildren(string name);
    }

    public class Person
    {
        public string Name;
    }
    //Low - level
    public class Relationship : IRelationShipBrowser
    {
        private List<(Person, RelationShip, Person)> realtions = new List<(Person, RelationShip, Person)>();
        public void AddParentAndChild(Person parent, Person child)
        {
            realtions.Add((parent, RelationShip.Parent, child));
            realtions.Add((child, RelationShip.Parent, parent));
        }

        public IEnumerable<Person> FindAllChildren(string name)
        {
            foreach (var r in realtions.Where(x => x.Item1.Name == name && x.Item2 == RelationShip.Parent))
            {
                yield return r.Item3;
            }
        }

        //public List<(Person, RelationShip, Person)> Realtions => realtions;
    }

    public class Research
    {
        //public Research(Relationship relationship)
        //{
        //    var relations = relationship.Realtions;
        //    foreach( var r in relations.Where(x=>x.Item1.Name=="John" && x.Item2== RelationShip.Parent))
        //    {
        //        Console.WriteLine($"John has a child called {r.Item3.Name}");
        //    }
        //}
        public Research(IRelationShipBrowser browser)
        {
            foreach (var p in browser.FindAllChildren("John"))
            {
                Console.WriteLine($"John has a child called {p.Name}");
            }
        }
        static void Main(string[] args)
        {
            var parent = new Person() {Name = "John"};
            var child1 = new Person() {Name = "Chris"};
            var child2 = new Person() {Name = "Mary" };

            var realationships = new Relationship();
            realationships.AddParentAndChild(parent, child1);
            realationships.AddParentAndChild(parent, child2);

            new Research(realationships);
        }
    }
}
