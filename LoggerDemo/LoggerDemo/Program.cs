using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerDemo
{
    public class Program
    {
        public void add(int a, int b)
        {
            FileStream fileStream = new FileStream("e:\\log.txt", FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine("--------------Function called-------------");
            streamWriter.WriteLine("\n");
            streamWriter.WriteLine(a);
            streamWriter.WriteLine("\n");
            streamWriter.WriteLine(b);
            streamWriter.WriteLine("\n");
            streamWriter.WriteLine(a+b);
            streamWriter.WriteLine("-------------Result displayed");
            try
            {
                streamWriter.WriteLine("--------------Division Initiated-------------");
                streamWriter.WriteLine("\n");
                streamWriter.WriteLine(a);
                streamWriter.WriteLine("\n");
                streamWriter.WriteLine(b);
                streamWriter.WriteLine("\n");
                streamWriter.WriteLine(a / b);
                streamWriter.WriteLine("-------------Result displayed");



            }
            catch (Exception e)
            {

                streamWriter.WriteLine("Exceptio occured");
                streamWriter.WriteLine(e);
            }

            streamWriter.Close();
            fileStream.Close();






        }
        public static void Main()
        {

            Program program = new Program();
            program.add(5, 0);


        }
    }
        
       
}
