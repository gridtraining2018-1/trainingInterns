using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingArray
{
    public class Array
    {
        //int arr[] = new int[5];//compile time error  
        public void BasicArray()
        {
            Console.Write("Size = ");
            int size = int.Parse(Console.ReadLine());
            int[] array = new int[size];
            Console.WriteLine("Following Array :- ");
            for(int i = 0; i<array.Length; i++)
            {
                Console.Write("Array[{0}] = ", i);
                array[i] = int.Parse(Console.ReadLine());
            }
        }
        public void declarationAndInitializationAtSameTime()
        {
            int[] array = new int[5] { 1, 2, 3, 4, 5 };
            Console.WriteLine("Following Array :- ");
            for (int i = 0; i<array.Length; i++)
            {
                Console.WriteLine("Array[{0}] = {1}", i,array[i]);
            }
        }
        public void declarationAndInitializationAtSameTime1()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine("Following Array :- ");
            for (int i = 0; i<array.Length; i++)
            {
                Console.WriteLine("Array[{0}] = {1}", i, array[i]);
            }
            
        }
        public void declarationAndInitializationAtSameTime2()
        {
            Console.WriteLine("Following Array :- ");
            int[] array = { 10, 20, 30, 40, 50 };
            foreach (int i in array)
            {
                Console.WriteLine("Array = {0}" ,i);
            }
        }
        public static void printArray(int[] array)
        {
            Console.WriteLine("Following Array :- ");
            for (int i = 0; i<array.Length; i++)
            {
                Console.WriteLine("Array[{0}] = {1}", i, array[i]);
            }
        }
        public static void printArray(int[,] array,int row,int column)
        {
            Console.WriteLine("Following Multidimensional Array :- ");
            for (int i = 0; i < row; i++)
            {
                for(int j = 0; j< column; j++)
                {
                    Console.WriteLine("Array[{0}][{1}] = {2}", i,j, array[i,j]);
                }
            }
        }
        public static void printArray(int [][] array)
        {
            for(int i = 0; i<array.Length; i++)
            {
                for(int j = 0; j<array[i].Length;j++)
                {
                    Console.Write("Array[{0}][{1}] = {2},  ", i,j, array[i][j]);
                }
                Console.WriteLine();
            }
        }

        //Note :- You can't overload the Array printArray Method to params printArray Method becouse the treat as same parameter.  
        public static void PrintArray(params int[] NOA)
        {
            for(int i = 0; i<NOA.Length; i++)
            {
                Console.WriteLine(NOA[i]);
            }
        }
        public static void PrintArray(params Object[] NOA)
        {
            for (int i = 0; i < NOA.Length; i++)
            {
                Console.WriteLine(NOA[i]);
            }
        }
        public void multidimensionalArrays()
        {
            Console.Write("Row = ");
            int row = Convert.ToInt32(Console.ReadLine());
            Console.Write("Column = ");
            int column = Convert.ToInt32(Console.ReadLine());
            int[,] array = new int[row,column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    array[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            UsingArray.Array.printArray(array, row, column);
        }
        public void jaggedArrays()
        {
            Console.WriteLine("Number of array :- ");
            int n = int.Parse(Console.ReadLine());
            int[][] array = new int[n][];
            for(int i = 0; i<n;i++)
            {
                Console.Write("Size = ");
                int size = Convert.ToInt32(Console.ReadLine());
                array[i] = new int[size];
                for(int j = 0; j<array[i].Length; j++)
                {
                    array[i][j] = int.Parse(Console.ReadLine());
                }
            }
            UsingArray.Array.printArray(array);
        }   
    } 
}
