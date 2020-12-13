using System;

namespace TaskA
{
    class A
    {
        public string Name = "A";
        public A(string name)
        {
            Name = name;
        }

    }
    class B : A
    {
        public string Name = "B";

        public B(string name) : base(name)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            B a = new B("C");
            Console.WriteLine(a.Name);
        }
    }
}
