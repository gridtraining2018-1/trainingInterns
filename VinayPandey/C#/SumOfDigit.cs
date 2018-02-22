using System;
namespace Sum
{
	class SOD
	{
		static void Main()
		{
			int rem,sum=0;
			Console.WriteLine("Enter number");
			int n=Convert.ToInt32(Console.ReadLine());
			while(n>0)
			{
				rem=n%10;
				sum=sum+rem;
				n=n/10;
			}
			Console.WriteLine("Sum of digit is=" + sum);
		}
	}
}