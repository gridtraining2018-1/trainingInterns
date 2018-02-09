using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fileHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream f = new FileStream("d:\\b.txt", FileMode.OpenOrCreate);//creating file stream  
            StreamWriter sw = new StreamWriter(f);
            string str = "hello";
            sw.WriteLine(str);
            sw.Close();
            //f.WriteByte(65);//writing byte into stream  
            f.Close();//closing stream  
            Console.ReadKey();



        }
    }
}
