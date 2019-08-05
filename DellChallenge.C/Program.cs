using System;

namespace DellChallenge.C
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Please refactor the code below whilst taking into consideration the following aspects:
            //      1. clean coding
            //      2. naming standards
            //      3. code reusability, hence maintainability
            StartHere();
            Console.ReadKey();
        }

        private static void StartHere()
        {
            var myObject = new MyExtendedObject();
            int obj1 = myObject.Do(1, 3);
            int num2 = myObject.DoExtended(1, 3, 5);
            Console.WriteLine(obj1);
            Console.WriteLine(num2);
        }
    }

    public interface IMyObject
    {
        int Do(int a, int b);
    }

    public interface IMyExtendedObject
    {
        int DoExtended(int a, int b, int c);
    }

    public class MyObject : IMyObject
    {
        public int Do(int a, int b)
        {
            return a + b;
        }
    }

    public class MyExtendedObject : MyObject, IMyExtendedObject
    {
        public int DoExtended(int a, int b, int c)
        {
            return a + b + c;
        }
    }
}
