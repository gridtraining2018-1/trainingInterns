using System;
namespace Arm
{
	class ArmStrong
	{
		static void Main()
		{
			int sum=0,rem;
			int n=Convert.ToInt32(Console.ReadLine());
			int temp=n;
			while(n>0)
			{
				rem=n%10;
				sum=sum+rem*rem*rem;
				n=n/10;
			}
			if(temp==sum)
				Console.WriteLine("Number is ArmStrong");
			else 
				Console.WriteLine("Number is not ArmStrong");
		}
	}
}