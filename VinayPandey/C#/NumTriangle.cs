using System;
namespace Num
{
	class Triangle
	{
		static void Main()
		{
			int i,j,k,m,n;
			Console.WriteLine("Enter the range");
			n=Convert.ToInt32(Console.ReadLine());
			for(i=1;i<=n;i++)
			{
				for(j=1;j<=n-i;j++)
					Console.Write(" ");
				for(k=1;k<=i;k++)
					Console.Write(k);
				for(m=i-1;m>=1;m--)
					Console.Write(m);
				Console.Write("\n");
			}
		}
	}
}