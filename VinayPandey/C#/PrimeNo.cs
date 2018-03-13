using System;
namespace Prime
{
	class PrimeNumber
	{
		static void Main(String[] args)
		{
			int flag=0;
			Console.WriteLine("Enter the number");
			int n=Convert.ToInt32(Console.ReadLine());
			for(int i=2;i<=n/2;i++)
			{
				if(n%i==0)
				{
					Console.WriteLine("Number is not Prime");
					flag=1;
					break;
				}
			}
			if(flag==0)
				Console.WriteLine("Number is prime=" + n);
		}
	}
}