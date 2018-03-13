using System;
namespace Multi
{
public class Person  
{  
    public static void person()  
    {  
        Console.WriteLine( "this is the person class");  
    }  
}  
public class Bird : Person  
{  
    public static void bird()  
    {  
        person();  
        Console.WriteLine( "this is the bird Class");  
    }  
}  
public class Animal : Bird  
{  
    public static void animal()  
    {  
        person();  
        bird();  
        Console.WriteLine( "this is the Animal Class");  
    }  
}  
class M:Animal{
public static void Main()
{
	animal();
}
}
}