using System;
namespace Palin
{
	class Palindrome
	{
		static void Main(String [] args)
		{
			int n,temp,rev,sum=0;
			Console.WriteLine("Enter the number");
			n=Convert.ToInt32(Console.ReadLine());
			temp=n;
			while(n>0)
			{
				rev=n%10;
				sum=sum*10+rev;
				n=n/10;
			}
			Console.WriteLine("reverse number is=" + sum);
			if(sum==temp)
				Console.WriteLine("Number is palindrome");
			else
				Console.WriteLine("Number is not palindrome");
		}
	}
}