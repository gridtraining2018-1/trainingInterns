using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace day7
{
    public abstract class abstractExample
    {
       private int  a;
        public abstract void display() ;
    }
    class Program:abstractExample
    {
        static void Main(string[] args)
        {
            try
            {
           

                  List<string> nameList = new List<string>();
                  
                             
                nameList.Add("abc");
                nameList.Add("def");
                foreach (string item in nameList)
                {

                    Console.WriteLine(item);
                   // nameList.Remove(item);
                }
                for (int i = 0; i < nameList.Count; )
                {
                    nameList.RemoveAt(i);
                }
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("firstElement", "123");

                dict.Add("firstElement2", "123");

                foreach (string key in dict.Keys)
                {
                    Console.WriteLine("Key " + key + "Value" + dict[key]);
                   // dict[key] = "456";
                }

                for (int i = 0; i < dict.Keys.Count; i++)
                {
                    //dict.ElementAt(i).Value.ToString();
                    dict[dict.ElementAt(i).Key] = "678";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
            new Program().display();
            new Program().TryExample();
            Type type = typeof(Program);
            bool check = type.IsClass;
            Console.Write(type);
        }

        public override void display()
        {
            Console.WriteLine("Its abstract class method");
            Console.ReadKey();
            FileStream file = new FileStream("text.txt", FileMode.Create);
            StreamReader fl;

           
            StreamWriter f= new StreamWriter(file);
            f.Write("tfytgkhgbcdhgsjha");
            f.Flush();
           
            fl = new StreamReader(file);

            string aa = fl.ReadLine();
            aa = fl.ReadLine();
            Console.WriteLine(aa);
            Console.ReadKey();
            f.Close();
           
            fl.Close();
            StreamWriter fn = new StreamWriter("text.txt", append: true);
            fn.Write("\n  append the data");
            fn.Close();
            file.Close();


        }
        public void TryExample()
        {
            int firstNum = 0,secondNum=12;
            #region "This is try catch region"
            try
            {
                firstNum = secondNum / firstNum;
            }
            catch
            {
                try
                {
                    throw new Exception("this is divide exception");
                } 
                catch(Exception e)
                {

                    Console.WriteLine(e);
                    Console.ReadKey();

                } 
            }
            #endregion
        }
    }
}
