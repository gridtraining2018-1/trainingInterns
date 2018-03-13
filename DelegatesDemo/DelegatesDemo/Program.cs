using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{

    delegate int DelegateExample(int num1, int num2);

    public class Dele
    {
        static int num3 = 0;
        public static int Add(int num1, int num2)
        {
            num3 = num1 + num2;
            return num3;
        }
        public static int getNumber()
        {
            return num3;
        }


        static void Main(string[] args)
        {
            DelegateExample delegateExample = new DelegateExample(Add);
            delegateExample(10, 8);
            Console.WriteLine("the sum is " + Dele.getNumber());


        }

    }
}
