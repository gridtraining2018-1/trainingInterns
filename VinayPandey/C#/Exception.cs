using System;
namespace ExceptionH
{
	class Handling
	{
		static void Main()
		{
			int a=5,b=0,c;
			try
			{
				c=a/b;
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}