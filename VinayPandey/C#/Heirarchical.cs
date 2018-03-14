using System;
namespace Heirarchical{
class A  //base class    
{  
    public static void msg()  
    {  
        Console.WriteLine( "this is A class Method");  
    }  
}  
class B : A  
{  
    public static void info()  
    {  
        msg();  
        Console.WriteLine( "this is B class Method");  
    }   
} 
class C : A  
    {  
        public static void getinfo()  
        {  
            msg();  
            Console.WriteLine( "this is C class Method");  
        }  
    } 
	class D:C
	{
		public static void Main()
		{
			getinfo();
			Console.WriteLine("inside main");
		}
	}
}