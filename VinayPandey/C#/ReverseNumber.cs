using System;
namespace Rev
{
	class Reverse
	{
		static void Main()
		{
			int n,rem,sum=0;
			n=Convert.ToInt32(Console.ReadLine());
			    while(n>0)
				{
					rem=n%10;
					sum=sum*10+rem;
					n=n/10;
				}
				Console.WriteLine("Reversed Number is=" + sum);
		}
	}
}