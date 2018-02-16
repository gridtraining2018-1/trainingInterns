using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingPointer 
{
    class PoniterClass 
    {
        
        //Pointer in Arrya
        unsafe public int* Array1D(int size)
        {  
            int[] array = new int[size];
            for(int i = 0; i<array.Length;i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            fixed (int* p = array)
            return p;
        }
        //garbage collecter
        /*
         G2
         G1 -> 05,o6,o7,o8
         G0 -> o1,o2,o3,o4
        */

        //print Array
        unsafe public void PrintArray(int size)
        {
            PoniterClass poniterClass = new PoniterClass();
            int* array = poniterClass.Array1D(size);
            for (int i = 0; i<size; i++)
            {
                Console.WriteLine(array[i]);
            }  
        }
    }
}
