using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCodes
{
    public class Program
    {
        string str,hld;


        #region Palindrome- Approach 1
        public void isPalindrome()
        {
            string temp = "";
            Console.WriteLine("Enter the word you want to check");
            str = Console.ReadLine();
            hld = str;

            int len = str.Length;
            int i = 0;
            for (i = len-1; i >=0; i--)
            {
                temp = temp + str[i];


            }
            if(temp == hld)
            {
                Console.WriteLine("Yes...{0} is Palindrome",hld);

            }
            else
            {
                Console.WriteLine("No...{0} is not Palindrome", hld);
            }
            Console.ReadKey();

        }
        #endregion

        public void Palindrome()
        {
            

        }




        static void Main(string[] args)
        {
            Program program = new Program();
            program.isPalindrome();

        }
    }
}
