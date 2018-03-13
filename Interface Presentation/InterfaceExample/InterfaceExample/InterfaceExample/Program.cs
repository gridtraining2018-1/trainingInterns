using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    public interface inter   ///An interface looks like a class, but has no implementation. The only thing it contains are declarations of events, indexers, methods and/or properties.
    {
        // interface members
        void getDetails();
        void showDetails();
    }

    public class BaseClass:inter    //Class inheriting interface
    {
        int num1, num2, result;
        
        public void getDetails()
        {
            bool bool_input=false;

            do
                try
                {
                    Console.Clear();
                    Console.WriteLine("Enter the first num");
                    num1 = int.Parse(Console.ReadLine());  
                    Console.WriteLine("Enter the second num");
                    num2 = int.Parse(Console.ReadLine());
                    result = num1 + num2;
                    bool_input = false;
                }
                catch (FormatException fe)    //Class which deals with format exceptions.
                {
                    bool_input = true;
                    Console.WriteLine("Incorrect input format: Please enter numeric value, Exception details are");
                    Console.WriteLine(fe.Message);
                    Console.ReadKey();
                }
                catch(OverflowException oe)   //Class which deals with overflow exceptions.
                {
                    bool_input = true;
                    Console.WriteLine("Out of range, Exception details are");
                    Console.WriteLine(oe.Message);
                    Console.ReadKey();
                }
                catch (Exception e)         //Class which deals with all sort of exceptions.
                {
                    bool_input = true;
                    Console.WriteLine("Exception occured: Try again, Exception details are");
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            while (bool_input);
        }

        public void showDetails()
        {
            Console.WriteLine("Answer is " + result);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass obj = new BaseClass();
            obj.getDetails();
            obj.showDetails();
            Console.ReadKey();
        }
    }

}
