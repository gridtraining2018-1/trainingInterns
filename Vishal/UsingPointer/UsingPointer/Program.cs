using SHDocVw;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingPointer
{
    class Program : PoniterClass
    {
        //GoToProject(UsingPointer)->RightClick->Properties->Build->AllowUnsafeCode
       
        //With the help of unsafe key word we use pointer
        static void Main(string[] args)
        {
            int size = Convert.ToInt32(Console.ReadLine());
            int value = 25;
            unsafe
            {
                int* ptr = &value;//In unsafe code we can initialize the add of variable into pointer variable.
                Console.WriteLine(*ptr);   
            }
            Program program = new Program();
            program.PrintArray(size);
        }

    }
}
