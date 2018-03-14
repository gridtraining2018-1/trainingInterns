using System;
namespace DecToBin
{
	class DeciToBina
	{
		static void Main()
		{
			int []a=new int [10];
			int i;
			Console.WriteLine("Enter the Number to convert into binary");
			int n=Convert.ToInt32(Console.ReadLine());
			for(i=0;n>0;i++)
			{
				a[i]=n%2;
				n=n/2;
			}
			Console.WriteLine("Binary number is:");
			for(i=i-1;i>=0;i--)
			{
				Console.Write(a[i]);
			}
		}
	}
}