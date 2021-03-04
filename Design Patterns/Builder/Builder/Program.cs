using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int indentSize = 2;

        public HtmlElement(string name, string text)
        {
            Name = name;
            Text = text;
        }

        public HtmlElement()
        {

        }

        private string ToStringIndent(int indent)
        {
            var sb = new StringBuilder();
            var i = new String(' ', indentSize * indent);
            sb.AppendLine($"{i}<{Name}>");
            if(!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new String(' ', indentSize * indent + 1));
                sb.AppendLine(Text);
            }

            foreach(var item in Elements)
            {
                sb.Append(item.ToStringIndent(indent + 1));
            }
            sb.AppendLine($"{i}</{Name}>");
            return sb.ToString();
        }


        public override string ToString()
        {
            return ToStringIndent(0);
        }
    }
    public class HtmlBuilder
    {
        private readonly string rootName;
        HtmlElement root = new HtmlElement();
        public HtmlBuilder(string rootName)
        {
            root.Name = rootName;
            this.rootName = rootName;
        }

        public HtmlBuilder AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
            return this;
        }
        public override string ToString()
        {
            return root.ToString();
        }
        public void Clear()
        {
            root = new HtmlElement { Name = root.Name };
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //Low level builder
            var hello = "hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            Console.WriteLine(sb);

            var words = new[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");
            foreach(var item in words)
            {
                sb.AppendFormat("<li>{0}</li>", item);
            }
            sb.Append("</ul>");
            Console.WriteLine(sb);

            //High level builder
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello");
            builder.AddChild("li", "world");
            Console.WriteLine(builder.ToString());
        }
    }
}
