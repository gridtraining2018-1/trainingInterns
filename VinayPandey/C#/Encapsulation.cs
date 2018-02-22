using System;
namespace AccesSpecifiers
{
	class Student
	{
		//creating setter and getter method for each property
		public string ID{get;set;}
		public string Name{get;set;}
		public string Email{get;set;}
	}
	class Program
	{
		static void Main(String[] args)
		{
			Student student=new Student();
			//setting values
			student.ID="101";
			student.Name="Vinay Pandey";
			student.Email="vinayp092@gmail.com";
			//getting values
			Console.WriteLine("ID="+student.ID);
			Console.WriteLine("Name="+student.Name);
			Console.WriteLine("Email="+student.Email);
		}
	}
}
