using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPrograms
{
    public class show
    {
        public virtual void run(int num1, int num2)
        {
            int num3 = num1 + num2;
            Console.WriteLine(num3);
        }


        public void run(int num1)
        {
            int num3;
            num3 = num1 * num1;
            Console.WriteLine(num3);
        }
    }
}
