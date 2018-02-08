using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPrograms
{
    public class Demos
    {
        public void palindrome()
        {
            int sum = 0, rem;
            Console.WriteLine("Enter the number you want to check");
            int num = Convert.ToInt32(Console.ReadLine());
            int temp = num;
            while (num > 0)
            {
                rem = num % 10;
                sum = (sum * 10) + rem;
                num = num / 10;
            }
            if (temp == sum)
            {
                Console.WriteLine("{0} is a Palindrome Number ", temp);
            }
            else
            {
                Console.WriteLine("{0} is not a Palindrome Number", temp);
            }


        }
        public int FindMax(int num1, int num2)
        {

            int result;

            if (num1 > num2)
                result = num1;
            else
                result = num2;

            return result;
        }

        public long Fac(int nm)
        {

            /*
            while (nm >= 1)
            {
                return Fac(nm - 1) * nm;

            }
            return 1;
            */
            if (nm == 1)
            {
                return 1;
            }
            else
            {
                return Fac(nm - 1) * nm;
            }
        }


        

        public void myArray()
        {
            int[] arr = new int[10];
            int i;
            for (i = 0; i < 10; i++)
            {
                //arr[i] = i + 10;
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (i = 0; i < 10; i++)
            {
                Console.WriteLine("{0}", arr[i]);
            }
        }
        public void multiArray()
        {
            int[,] mulArr = new int[3, 4] ;
            int c, d;
            for (c = 0; c < 3; c++)
            {
                for (d = 0; d < 4; d++)
                {
                    //Console.WriteLine(mulArr[c, d]);
                    mulArr[c, d] = Convert.ToInt32(Console.ReadLine());
                }
            }
            for (c = 0; c < 3; c++)
            {
                for (d = 0; d < 4; d++)
                {
                    Console.Write("  {0}",mulArr[c, d]);
                }
                Console.Write("\n");
            }

        }



        class Program:show
        {

            public override void run(int num1,int num2)
            {
                int num3;
                num3 = num1 * num2;
                Console.WriteLine(num3);
            }
            static void Main(string[] args)
            {
                Demos demos = new Demos();
                Class1 class1 = new Class1(5);
                //class1.show();
                //show s = new show();
                //s.run(5, 5);
                //s.run(8);
                Program p = new Program();
                p.run(5, 5);
                p.run(9);
               
                //demos.palindrome();
                //int n = demos.FindMax(85,19);
                //Console.WriteLine("{0}",n);
                //long f = demos.Fac(55);

                //Console.WriteLine(f);
                //demos.myArray();
                //demos.multiArray();
                // StructDemo structDemo = new StructDemo();
                // structDemo.testStructure();
                //long m =class1.demo(5);
                //Console.WriteLine("Factorial ={0}",m);
                
                Console.ReadKey();
            }
        }
    }
}
