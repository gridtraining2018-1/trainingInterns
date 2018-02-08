using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeC_Sharp
{
    interface Sample
    {
        void Display();
    }
    class Program : Sample
    {
        public void Display()
        {
            Console.Write("welcme");
        }
    }
}
