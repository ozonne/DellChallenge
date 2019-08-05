using System;

namespace DellChallenge.A
{
    class Program
    {
        static void Main(string[] args)
        {
            // State and explain console output order.
            // The console output order is the following:
            // 1. when the app enters the main method it instantiates the B class which derives from class A so the A constructor 
            // is called and it prints A.A()
            // 2. the next step is to call the class B constructor so it prints B.B()
            // 3. the next spep is to call the Age property in the B class constructor of the parent class A and sets its value
            // to 0 and than it prints A.Age
            new B();
            Console.ReadKey();
        }
    }

    class A
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                Console.WriteLine("A.Age");
            }
        }


        public A()
        {
            Console.WriteLine("A.A()");
        }
    }

    class B : A
    {
        public B()
        {
            Console.WriteLine("B.B()");
            Age = 0;
        }
    }
}
