using System;
namespace N2C
{
	class NumberToChar
	{
		static void Main()
		{
			int sum=0,rem,n;
			Console.WriteLine("Enter the number");
			n=Convert.ToInt32(Console.ReadLine());
			while(n>0)
			{
				rem=n%10;
				sum=sum*10+rem;
				n=n/10;
			}
			n=sum;
			while(n>0)
			{
				rem=n%10;
				switch(rem)
				{
					case 1:
					Console.Write("one\t");
					break;
					case 2:
					Console.Write("two\t");
					break;
					case 3:
					Console.Write("three\t");
					break;
					case 4:
					Console.Write("four\t");
					break;
					case 5:
					Console.Write("five\t");
					break;
					case 6:
					Console.Write("six\t");
					break;
					case 7:
					Console.Write("seven\t");
					break;
					case 8:
					Console.Write("eight\t");
					break;
					case 9:
					Console.Write("nine\t");
					break;
					case 0:
					Console.Write("zero\t");
					break;
					default:
					Console.Write("kuchh bhi");
					break;
				}
				n=n/10;
			}
		}
	}
}