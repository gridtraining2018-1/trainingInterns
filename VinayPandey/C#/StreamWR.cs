using System;
using System.IO;
namespace Stream{
	class Wr{
		void writer(){
			FileStream f = new FileStream("C:/Users/Lenovo/Desktop/Programs/C#/output.txt", FileMode.Create);  
        StreamWriter s = new StreamWriter(f);  
  
        s.WriteLine("hello c#");  
        s.Close();  
        
     Console.WriteLine("File created successfully...");  
		}
		void reader(){
			FileStream f = new FileStream("C:/Users/Lenovo/Desktop/Programs/C#/output.txt", FileMode.OpenOrCreate);  
        StreamReader s = new StreamReader(f);  
  
        string line=s.ReadLine();  
        Console.WriteLine(line);  
  
        s.Close();  
        f.Close();  
		}
		static void Main()
		{
			Wr w=new Wr();
			w.writer();
			w.reader();
		}
	}
}