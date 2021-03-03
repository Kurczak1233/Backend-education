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

    // Bad way to implement filter
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

        public IEnumerable<Product> FilterBySizeAndColor(Color color, Size size, IEnumerable<Product> produtcts)
        {
            foreach (var p in produtcts)
            {
                if (p.Size == size && p.Color == color)
                {
                    yield return p;
                }
            }
        }
    }

    // Good way to implement filter (open-close)
    public interface ISpecificaction<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecificaction<T> spec);
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecificaction<Product> spec)
        {
            foreach (var item in items)
            {
                if (spec.IsSatisfied(item))
                    yield return item;
            }
        }
    }

    public class ColorSpecification : ISpecificaction<Product>
    {
        private Color color;
        public ColorSpecification(Color color)
        {
            this.color = color;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }

    public class SizeSpecification : ISpecificaction<Product>
    {
        private Size size;
        public SizeSpecification(Size size)
        {
            this.size = size;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Size == size;
        }
    }


    public class AndSpecification<T> : ISpecificaction<T>
    {
        private ISpecificaction<T> First, Second;

        public AndSpecification(ISpecificaction<T> first, ISpecificaction<T> second)
        {
            First = first;
            Second = second;
        }

        public bool IsSatisfied(T t)
        {
            return First.IsSatisfied(t) && Second.IsSatisfied(t);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //NOT CLEVER WAY TO IMPLEMENT FILTER!
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
            //CLEVER WAY TO IMPLEMENT FILTER
            var bf = new BetterFilter();
            Console.WriteLine("Green product (new):");
            foreach(var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($"- {p.Name} is green");

            }

            Console.WriteLine("Large blue items");
            foreach (var p in bf.Filter(products, new AndSpecification<Product>(new ColorSpecification(Color.Blue), (new SizeSpecification(Size.Large)))))
            {
                Console.WriteLine($"- {p.Name} is big and blue");

            }
        }
    }
}
