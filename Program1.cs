using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace logfile1
{
    class Program
    {
        static void WriteFile()
        {
            FileStream f;
            try
            {


            //f = new FileStream("E:\\f.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter("E:\\f.txt",true);
            sw.WriteLine(DateTime.Now);
            sw.WriteLine("jjjhhk");
            sw.Close();
            }
            catch (Exception e)
            {

                throw(e);
            }

            //f.Close();
        }
        static void ReadFile()
        {
            FileStream f1;
            try
            {

           
             f1= new FileStream("E:\\f.txt", FileMode.OpenOrCreate);
            byte[] buffer = new byte[1024];
            int byteRead = f1.Read(buffer, 0, buffer.Length);
            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, byteRead));
            
            }
            catch (Exception e1)
            {

                throw(e1);
            }
            
            f1.Close();
            }


        static void Main(string[] args)
        {
            WriteFile();
            ReadFile();
            Console.ReadKey();
        }
    }
}
