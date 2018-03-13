using System;
namespace first
{
	class c1
	{
		public void fun()
		{
			Console.WriteLine("inside first");
		}
	}
}
namespace second
{
	class c1
	{
		public void fun()
		{
			Console.WriteLine("inside second");
		}
	}
}
class Test
{
	static void Main()
	{
		first.c1 fc=new first.c1();
		second.c1 sc=new second.c1();
		fc.fun();
		sc.fun();
		//Console.Readkey();
	}
}