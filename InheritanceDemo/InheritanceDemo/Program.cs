using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    #region Single Level Inheritance
    public class Employee
    {
        public int salary = 1000000;
        public void Display()
        {
            Console.WriteLine("I am employee");
        }

    }
    public class Programmar : Employee
    {
        public int bonus = 5000;
        public void Display1()
        {
            Console.WriteLine("I am programmar");
        }
    }
    #endregion

    public class Animal
    {
        public void Eat()
        {
            Console.WriteLine("All animals are eating");
        }
    }
    public class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("Dogs bark");
        }
    }
    public class BabyDogs : Dog
    {
        public void Weep()
        {
            Console.WriteLine("Baby dogs weep");
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            Programmar programmar = new Programmar();
            Console.WriteLine(programmar.salary);
            Console.WriteLine(programmar.bonus);
            programmar.Display();
            programmar.Display1();
            BabyDogs babyDogs = new BabyDogs();
            babyDogs.Eat();
            babyDogs.Bark();
            babyDogs.Weep();
            Console.ReadKey();
        }
    }
}
