using System;
using System.Collections.Generic;

namespace Open_Close_Principle
{
    public enum Color
    {
        Red, Green, Blue
    }
    public enum Size
    {
        Small, Medium, Large, Huge
    }
    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }

    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(Size size,IEnumerable<Product> produtcts)
        {
            foreach (var p in produtcts)
            {
                if(p.Size == size)
                {
                    yield return p;
                }
            }
        }

        public IEnumerable<Product> FilterByColor(Color color, IEnumerable<Product> produtcts)
        {
            foreach (var p in produtcts)
            {
                if (p.Color == color)
                {
                    yield return p;
                }
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);
            Product[] products = {apple, tree, house};
            var pf = new ProductFilter();
            Console.WriteLine("Green products (old):");
            foreach (var p in pf.FilterByColor(Color.Green, products))
            {
                Console.WriteLine($"- {p.Name} is green");
            }
        }
    }
}
