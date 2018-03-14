using System;
using System.IO;
namespace File 
{
	class Stream
	{
	    public void creating()
		{
			string loc="C:/Users/Lenovo/Desktop/Programs/C#/abc.txt";
			FileInfo file=new FileInfo(loc);
			file.Create();
			Console.WriteLine("file is created");
		}
		public void writing()
		{
			string loc="C:/Users/Lenovo/Desktop/Programs/C#/abc.txt";
			
			FileInfo file=new FileInfo(loc);
			StreamWriter sw=file.CreateText();
			sw.WriteLine("this text iss written by using streamwriter class");
			sw.Close();
		}
        public void reading()
		{
			string loc="C:/Users/Lenovo/Desktop/Programs/C#/abc.txt";
			FileInfo file=new FileInfo(loc);
			StreamReader sr=file.OpenText();
			string data="";
			while((data=sr.ReadLine())!=null)
			{
				Console.WriteLine(data);
			}
		}		
		static void Main()
		{
			Stream st=new Stream();
			//st.creating();
			//st.writing();
			st.reading();
		}
	}
}