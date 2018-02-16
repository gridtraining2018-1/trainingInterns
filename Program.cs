using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace thread1
{
    class SpeedoMeter
    {

        String sum = "";
        public void Speed1()
        {
            for (int l = 0; l < 10; l++)
            {
                for (int k = 0; k < 10; k++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine(l+""+k+""+j+""+i);
                            Thread.Sleep(0);

                        }
                    }
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            SpeedoMeter sm = new SpeedoMeter();
            sm.Speed1();
            Console.ReadKey();
        }
    }
}
