using System;

namespace Fluent_Builder_Inheritance_with_Recursive_Generics
{
    class Program
    {
        public class Person 
        {
            public string Name;

            public string Position;

            public override string ToString()
            {
                return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
            }
        }

        public class Builder : PersonJobBuilder<Builder>
        {

        }

        public static Builder New => new Builder();
        public abstract class PersonBuilder
        {
            protected Person person = new Person();

            public Person Build()
            {
                return person;
            }
        }

        public class PersonInfoBuilder<SELF> : PersonBuilder where SELF : PersonInfoBuilder<SELF>
        {
            protected SELF person = new Person();
            public PersonInfoBuilder Called(string name)
            {
                person.Name = name;
                return (SELF) this;
            }
        }

        public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder><SELF>> where SELF : PersonJobBuilder<SELF>
        {
            public  WorksAsA(string postion)
            {
                person.Position = position;
                return this;
            }
        }


        static void Main(string[] args)
        {
            var person = Person.New.Called("Dimitri").WorksAsA("quant").Build();
            Console.WriteLine(person);
            
        }
    }
}
