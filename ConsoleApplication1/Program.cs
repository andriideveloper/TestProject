using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    class TextCell
    {
        public string Text { get; set; }
        public string Detail { get; set; }
    }

    class Grouper<TK, T>
    {
        public TK Key { get; private set; }
        public List<T> Items { get; private set; } 
        public IGrouping<TK, T> Item
        {
            set
            {
                if(value == null)
                    return;

                Key = value.Key;

                if (Items == null)
                    Items = new List<T>();

                Items.AddRange(value);
            }
        }

        //public IList<T> Items { get; set; }
    }
    class Program
    {
        static void Main()
        {
            var list = new List<TextCell>
            {
                new TextCell {Text = "A"},
                new TextCell {Text = "Aa"},
                new TextCell {Text = "Ab"},
                new TextCell {Text = "Ac"},
                new TextCell {Text = "Abb"},
                new TextCell {Text = "B"},
                new TextCell {Text = "Ba"},
                new TextCell {Text = "Bg"},
                new TextCell {Text = "Bd"},
                new TextCell {Text = "Ba", Detail = "det"},
                new TextCell {Text = "Br"},
                new TextCell {Text = "C"},
                new TextCell {Text = "Cc"},
                new TextCell {Text = "C"},
            };
            //List<IGrouping<string, TextCell>>
            var list1 = list.OrderBy(c => c.Text).GroupBy(c => c.Text[0].ToString(), c => c).Select(i=> new Grouper<string, TextCell> { Item = i}).ToList();
            //list1;//.Select( g = new Typle<string, TextCell>())

            return;
            for(var i = 0; i < 20; i++)
                Console.WriteLine(i % 5);

            Console.Read();
            return;

            var visitor = new PersonVisitor();

            var child = new Child();
            var teenager = new Teenager();
            var person = new Person();
            var date = new DateTime();

            visitor.Visit(child);
            visitor.Visit(teenager);
            visitor.Visit(person);
            visitor.Visit(date);

            child.Visit();
            teenager.Visit();
            person.Visit();
            date.Visit();

            Console.Read();
        }
    }

    class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Child : Person
    {

    }

    class Teenager : Person
    {
        
    }

    class PersonVisitor
    {
        public void Visit(Person obj)
        {
            Console.WriteLine("Person Visited");
        }
        public void Visit(Child obj)
        {
            Console.WriteLine("Child Visited");
        }
        public void Visit(Teenager obj)
        {
            Console.WriteLine("Teenager Visited");
        }
        public void Visit(object obj)
        {
            Console.WriteLine("Object Visited");
        }
    }

    static class PersonStaticVisitor
    {
        public static void Visit(this Person obj)
        {
            Console.WriteLine("Person Visited");
        }
        public static void Visit(this Child obj)
        {
            Console.WriteLine("Child Visited");
        }
        public static void Visit(this Teenager obj)
        {
            Console.WriteLine("Teenager Visited");
        }
        public static void Visit(this object obj)
        {
            Console.WriteLine("Object Visited");
        }
    }
}