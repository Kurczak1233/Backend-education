using System;

namespace Liskov_Substitution_Principle
{
    class Program
    {

        static public int Area(Rectangle r) => r.Height * r.Width;
        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle(2,3);
            Console.WriteLine($"{rc} has area {Area(rc)}");

            Rectangle sq = new Square();
            sq.Width = 4;
            Console.WriteLine($"{sq}0 has area {Area(sq)}");

        }

    }
    public class Square : Rectangle
    {
        public override int Width
        {
            set { base.Width = base.Height = value; }
        }
        public override int Height
        {
            set { base.Width = base.Height = value; }
        }
    }

    public class Rectangle
    {
        public virtual int Width{ get; set; }
        public virtual int Height{ get; set; }
        public Rectangle()
        {
            
        }
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }
}

