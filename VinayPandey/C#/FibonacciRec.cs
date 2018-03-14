using System;
namespace Rec
{
	class Fibonacci
	{
		static int Main()
		{
			int n,i=0,c;
			n=Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Fibonacci Series is:");
			for(c=1;c<=n;c++)
			{
				Console.Write(Fib(i)+ " ");
				i++;
			}
			return 0;
		}
		static int Fib(int n)
		{
			if(n==0)
				return 0;
			else if(n==1)
				return 1;
			else
				return (Fib(n-1)+Fib(n-2));
		}
	}
}