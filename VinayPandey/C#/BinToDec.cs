using System;
namespace B2D
{
	class BinToDec
	{
		static void Main()
		{
			int i,n,num=0,b=1;
			Console.WriteLine("Enter the binary number");
			n=Convert.ToInt32(Console.ReadLine());
			while(n>0)
			{
				i=n%10;
				num=num+i*b;
				n=n/10;
				b=b*2;
			}
			Console.WriteLine("Decimal number is=" + num);
		}
	}
}