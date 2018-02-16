using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingArray 
{
    class Program : UsingArray.Array
    {   
        static void Main(string[] args)
        {
            Console.Write("Size = ");
            int size = int.Parse(Console.ReadLine());
            int[] array = new int[size];
            Console.WriteLine("Following Array :- ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Array[{0}] = ", i);
                array[i] = int.Parse(Console.ReadLine());
            }
            Program program = new Program();
            program.BasicArray();
            program.declarationAndInitializationAtSameTime();
            program.declarationAndInitializationAtSameTime1();
            program.declarationAndInitializationAtSameTime2();
            Program.printArray(array);
            program.multidimensionalArrays();
            program.jaggedArrays();
            Program.PrintArray(1, 2, 3, 4, 5, 6, 7);
            Program.PrintArray("Vishal Jaiswal", 1403210240, 21, "A+", "vickyvishalj99@gmail.com", 7532971412);
        }
    }
}
