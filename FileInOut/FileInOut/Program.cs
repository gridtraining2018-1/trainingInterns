using System;
using System.IO;

namespace FileInOut
{
   
        class Program
        {
            static void Main(string[] args)
            {
            /*  try
              {
                  // Specifying file location  
                  string loc = "F:\\abc.txt";
                  // Creating FileInfo instance  
                  FileInfo file = new FileInfo(loc);
                  // Creating an empty file  
                  file.Create();
                  Console.WriteLine("File is created Successfuly");
              }
              catch (IOException e)
              {
                  Console.WriteLine("Something went wrong: " + e);
              }
              */
            /*
          FileStream f = new FileStream("e:\\output.txt", FileMode.OpenOrCreate);
          StreamReader s = new StreamReader(f);

          string line = s.ReadLine();
          Console.WriteLine(line);

          s.Close();
          f.Close();
          */
            FileStream f = new FileStream("e:\\a.txt", FileMode.OpenOrCreate);
            StreamReader s = new StreamReader(f);

            string line = "";
            while ((line = s.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            s.Close();
            f.Close();
            Console.ReadKey();
        }
        }
    }
