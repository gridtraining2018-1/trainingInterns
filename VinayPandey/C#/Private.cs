using System;
namespace RectangleApplication
{
	class Rectangle
	{
		private double length;
		private double width;
		public void AcceptDetails()
		{
			Console.WriteLine("Enter Length:");
			length=Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Enter Width:");
			width=Convert.ToDouble(Console.ReadLine());
		}
		public double GetArea()
		{
			return length*width;
		}
		public void Display()
		{
			Console.WriteLine("Length={0}",length);
			Console.WriteLine("Width={0}",width);
			Console.WriteLine("Area={0}",GetArea());
		}
	}
	class ExecuteRectangle
	{
		static void Main(String[] args)
		{
			Rectangle r=new Rectangle();
			r.AcceptDetails();
			r.Display();
		}
	}
}