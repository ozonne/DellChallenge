using System;

namespace DellChallenge.B
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given the classes and interface below, please constructor the proper hierarchy.
            // Feel free to refactor and restructure the classes/interface below.
            // (Hint: Not all species and Fly and/or Swim)
            _ = new Human();
            _ = new Bird();
            _ = new Fish();
        }
    }

    public interface ISpecies
    {
        void Eat();
        void Drink();
    }

    public interface IBird
    {
        void Fly();
    }

    public interface IFish
    {
        void Swim();
    }

    public class Species : ISpecies
    {
        public Species()
        {
            GetSpecies();
        }

        public virtual void GetSpecies()
        {
            Console.WriteLine($"Echo who am I?");
        }

        public void Drink()
        {
            Console.WriteLine($"* I drink");
        }

        public void Eat()
        {
            Console.WriteLine($"* I eat");
        }
    }

    public class Human : Species
    {
        public Human()
        {
            Console.WriteLine($"I am a human");
            Drink();
            Eat();
        }
    }

    public class Bird : Species, IBird
    {
        public Bird()
        {
            Console.WriteLine($"I am a bird");
            Drink();
            Eat();
            Fly();
        }

        public void Fly()
        {
            Console.WriteLine($"* I fly");
        }
    }

    public class Fish : Species
    {
        public Fish()
        {
            Console.WriteLine($"I am a fish");
            Drink();
            Eat();
            Swim();
        }

        public void Swim()
        {
            Console.WriteLine($"* I swim");
        }
    }
}

