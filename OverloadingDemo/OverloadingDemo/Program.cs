using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadingDemo
{
    class MemberOverload
    {
        public int Multiply(int num1,int num2)
        {
            return num1 * num2;
        }
        public int Multiply(int a, int b,int c)
        {
            return a * b * c;
        }

    }


    #region Method overriding
    public class RBI
    {
        public virtual void Bank()
        {
            Console.WriteLine("Bank... RBI");
        }
        
    }
    public class PNB : RBI
    {
        public override void Bank()
        {
            Console.WriteLine("Bank... PNB");
        }
    }
    #endregion



    class Program
    {
        static void Main(string[] args)
        {
            MemberOverload memberOverload = new MemberOverload();
            Console.WriteLine(memberOverload.Multiply(2, 2));
            Console.WriteLine( memberOverload.Multiply(4, 3, 7));
            PNB pNB = new PNB();
            pNB.Bank();
            Test test = new Test();
            test.Display();
            Console.ReadKey();
        }
    }
}
