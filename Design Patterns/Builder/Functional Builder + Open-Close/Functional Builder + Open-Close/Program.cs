using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_Builder___Open_Close
{
    public class Person
    {
        public string Name, Positon;
    }

    public abstract class FunctionalBuilder<TSubject, TSelf> where TSelf : FunctionalBuilder<TSubject, TSelf> where TSubject : new()
    {
        private readonly List<Func<Person, Person>> actions = new List<Func<Person, Person>>();

        public Person Build() => actions.Aggregate(new Person(), (p, f) => f(p));
        public TSelf Do(Action<Person> action) => AddAction(action);
        private TSelf AddAction(Action<Person> action)
        {
            actions.Add(p =>
            {
                action(p);
                return p;
            });
            return (TSelf)this;
        }
    }

    public sealed class PersonBuilder : FunctionalBuilder<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name) => Do(p => p.Name = name)
    }

    //public sealed class PersonBuilder //Sealed means that no one can inherit from this class
    //{
    //    private readonly List<Func<Person, Person>> actions = new List<Func<Person,Person>>();
    //    public PersonBuilder Called(string name) => Do(p => p.Name = name);

    //    public Person Build() => actions.Aggregate(new Person(), (p, f) => f(p));
    //    public PersonBuilder Do(Action<Person> action) => AddAction(action);
    //    private PersonBuilder AddAction(Action<Person> action)
    //    {
    //        actions.Add(p =>
    //        {
    //            action(p);
    //            return p;
    //        });
    //        return this;
    //    }
    //}

    public static class PersonBuilderExtentions
    {
        public static PersonBuilder WorksAs(this PersonBuilder builder, string postion) => builder.Do(p => p.Positon = postion);
    }
    class Program
    {
        static void Main(string[] args)
        {
            var Person = new PersonBuilder().Called("Michal").WorksAs("Developer").Build();
        }
    }
}
