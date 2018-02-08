using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismDemo
{
    class Rbi
    {
        public virtual void Roi()
        {
            Console.WriteLine("this is rate of interest...5%");
        }

    }
    class Pnb : Rbi
    {
        public override void Roi()
        {
            base.Roi();
            Console.WriteLine("this is rate of interest...8%");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rbi rbi = new Pnb();
            rbi.Roi();
            Console.ReadKey();
        }
    }
}
