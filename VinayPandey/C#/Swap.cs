using System;
namespace swap
{
	class Swap
	{
		static void Main()
		{
			int a,b;
		    a=Convert.ToInt32(Console.ReadLine());
		    b=Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Number Before swap is:" + a + "and" + b);
			a=a*b;
			b=a/b;
			a=a/b;
			Console.WriteLine("Number After Swap is:" + a + "and" + b);
		}
		
	}
}