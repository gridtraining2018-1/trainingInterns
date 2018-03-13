using System;
namespace Dir
{
	class Fact
	{
		static void Main(String[] args)
		{
			int n,fact=1;
			Console.WriteLine("Enter number");
			n=Convert.ToInt32(Console.ReadLine());
			for(int i=1;i<=n;i++)
				fact=fact*i;
			Console.WriteLine("factorial is=" + fact);
		}
	}
}