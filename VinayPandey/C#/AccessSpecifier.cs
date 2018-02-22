using System;
namespace RectangleApplication
{
	class Rectangle
	{
		public double length;
		public double width;
		public double GetArea()
		{
			return length*width;
		}
		public void Display()
		{
			Console.WriteLine("Length={0}",length);
			Console.WriteLine("width={0}",width);
			Console.WriteLine("Area={0}",GetArea());
		}
	}
	class ExecuteRectangle
	{
		static void Main(String[] args)
		{
			Rectangle r=new Rectangle();
			r.length=Convert.ToDouble(Console.ReadLine());
			r.width=Convert.ToDouble(Console.ReadLine());
			r.Display();
		}
	}
}