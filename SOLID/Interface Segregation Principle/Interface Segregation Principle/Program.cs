using System;

namespace Interface_Segregation_Principle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class Document
    {

    }
    public interface IMachine : IPrinter, IScan
    {
    }

    public interface IPrinter
    {
        void Print(Document d);
    }
    public interface ICopy
    {
        void Scan(Document d);
    }
    public interface IScan
    {
        void Fax(Document d);
    }
    public class MultiFunctionPrinter : IMachine
    {
        private IPrinter printer;
        private IScan scaner;

        public MultiFunctionPrinter(IScan scaner, IPrinter print)
        {
            this.scaner = scaner;
            this.printer = print;
        }

        //Decorator!
        public void Print(Document d)
        {
            printer.Print(d);
        }
        public void Scan(Document d)
        {
            scaner.Fax(d);
        }
    }
    public class OldFashinonedPrinter : ICopy
    {
        public void Scan(Document d)
        {
            //
        }
    }
}
