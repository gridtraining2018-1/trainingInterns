using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPrograms
{
    public class Class1
    {
        int n;
        public Class1(int n) {
            this.n = n;  
           
        }
        public void show()
        {
            Console.WriteLine(n);
        }
        public long demo(int n)
         {


             if(n == 1)
             {

                 return 1;
             }
             else
             {
                 return n * demo(n - 1);
             }

         }

    }
}
