using System;  
   public class Employee  
    {  
		public string Name{get; set;}
		public string Email{get; set;}
		public int Id{ get; set;}
	}  
   class TestEmployee{  
       public static void Main(string[] args)  
        {  
            Employee e1 = new Employee();  
            e1.Name = "Sonoo Jaiswal";
            e1.Id=1;
            e1.Email="vinayp092@gmail.com";			
            Console.WriteLine("Employee Name: " + e1.Name + " id:" + e1.Id + " email:" + e1.Email);  
  
        }  
    }  