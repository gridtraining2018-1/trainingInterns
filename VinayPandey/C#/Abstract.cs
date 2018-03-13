using System;

namespace abstractSample
{
      //Creating an Abstract Class
      abstract class absClass
      {
            //A Non abstract method
            public int AddTwoNumbers(int Num1, int Num2)
            {
                return Num1 + Num2;
            }

            //An abstract method, to be
            //overridden in derived class
            public abstract int MultiplyTwoNumbers(int Num1, int Num2);
      }

      //A Child Class of absClass
      class absDerived:absClass
      {
           #region main method is comming...
            static void Main(string[] args)
            {
               //You can create an
               //instance of the derived class

               absDerived calculate = new absDerived();
               int added = calculate.AddTwoNumbers(10,20);
               int multiplied = calculate.MultiplyTwoNumbers(10,20);
               Console.WriteLine("Added : {0}, Multiplied : {1}", added, multiplied);
            }
			#endregion
			

            //using override keyword,
            //implementing the abstract method
            //MultiplyTwoNumbers
            public override int MultiplyTwoNumbers(int Num1, int Num2)
            {
                return Num1 * Num2;
            }
      }
}