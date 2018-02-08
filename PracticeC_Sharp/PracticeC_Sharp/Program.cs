using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeC_Sharp
{
    
    
        class Rectangle
        {

            //member variables
            protected double length;
            protected double width;
        


            public Rectangle(double l, double w)
            {
                length = l;
                width = w;
            }
            public double GetArea()
            {
                return length * width;
            }
            public void Display()
            {
                Console.WriteLine("Length: {0}", length);
                Console.WriteLine("Width: {0}", width);
                Console.WriteLine("Area: {0}", GetArea());
            }
        }//end class Rectangle  
        class Tabletop : Rectangle
        {
            private double cost;
            public Tabletop(double l, double w) : base(l, w) { }
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        /// 
            public virtual double GetCost()
            {
                double cost;
                 cost = GetArea() * 70;
                return cost;
            }
            public  void Display()
            {
                base.Display();
                Console.WriteLine("Cost: {0}", GetCost());
            }
        }
    //end of class tabletop
       class Perimeter : Tabletop
    {
        public Perimeter(double l, double w) : base(l, w) { }
       public void GetPerimeter()
        {
            double peri = length * width;
            Console.WriteLine("perimeter is" + peri);
        }

    }
    //end of class perimeter 

       
        class ExecuteRectangle
        {
            static void Main(string[] args)
            {
            Tabletop t = new Tabletop(4.5, 7.5);
            Perimeter p = new Perimeter(3, 7);
            Program p1 = new Program();
            System.Data.DataTable dt = new System.Data.DataTable();
            
            t.Display();
            p.GetPerimeter();


            p1.Display();
           
            Console.ReadKey();
            }
        }
    
}
