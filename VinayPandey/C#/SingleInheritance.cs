using System;
namespace Single
{
	class A
	{
		public static void fun()
		{
			Console.WriteLine("inside A");
		}
	}
	class B : A
	{
		public static void Main()
		{
			fun();
			Console.WriteLine("inside B");
		}
	}
}