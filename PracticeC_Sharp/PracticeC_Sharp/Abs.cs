using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeC_Sharp
{
  public abstract class Sum
    {
        public abstract void Divison();
    }

    class Number: Sum
    {
        int number1, number2;
        public override void Divison()
        { 

            // throw new NotImplementedException();
            #region Shipra here  
            try
            {
                try
                {
                    Console.Write("enter first no.");
                    number1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("enter second no.");
                    number2 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("division" + number1 / number2);
                        }
                catch (Exception)
                {
                    throw;

                }
            }



            catch (Exception ex)
            {
                string exception = "no.divide by zero,error in outer try";
                Console.Write(exception);

            }
            finally
            {

                Console.Write("\n thank u");
            }
            
            #endregion

        }
    }
}
