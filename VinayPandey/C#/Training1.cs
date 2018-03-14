using System;
namespace Training
{
	public class A
	{
		A(int n)
		{
			Console.WriteLine("Constructor" + n);
		}
		void show()
		{
			Console.WriteLine("constructor called");
		}
		static void Main()
		{
			A a=new A(5);
			Training.B c=new Training.B(1);
			a.show();
		/*Console.WriteLine("Enter the number to add");
		int a=int.Parse(Console.ReadLine());
		int b=int.Parse(Console.ReadLine());
		a=a+b;
		Console.WriteLine("sum is=" + a);*/
		}
	}
}