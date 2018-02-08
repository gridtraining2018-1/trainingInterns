using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region Ultimate Sum
namespace delegatesAdd 
{
    delegate int Sum(int n1, int n2);
    class Program
    {
       static int n3;
        
		public static int add(int n1, int n2)
        {

            try {
                n3 = n1 + n2;
                

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return n3;

        }
   
        
        public static void  getnum()
        {
            Console.WriteLine("sum={0}",n3);
        }
        static void Main(string[] args)
        {
           
            var names = new List<string>();
            //List<string<Int16>>=new List 
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "One");
            dict.Add(2, "Two");
            dict.Add(3, "Three");
            Console.WriteLine("Dictionary is: ");
            foreach (KeyValuePair<int, string> item in dict)
            {
                Console.Write("Key: {0}, Value: {1}\n", item.Key, item.Value);
            }
            for (int i = 0; i < dict.Count; i++)
            {
                dict[i+1] = "abc";
            }
            Console.Write("After Updation Dictionary is:");
            foreach (KeyValuePair<int, string> item in dict)
            {
                Console.Write("\nKey: {0}, Value: {1}", item.Key, item.Value);
            }
            Dictionary<int, Dictionary<int,string>> info = new Dictionary<int, Dictionary<int, string>> {
                {1, new Dictionary<int, string> {
    {101, "Rahul"},
    {102, "ajay"},
    {103, "amit"},
    {104, "shipra siddhu"}
    }},
    {2, new Dictionary<int, string> {
    {101, "Exodus"},
    {102, "40"},
    {103, "Gen"},
    {104, "Lev"}
    }}}; 
            foreach(KeyValuePair<int, KeyValuePair<int,string>> item1 in info)
            {
                foreach ()
                {
                    Console.WriteLine("\nKey: {0},");
                }
            }

            /*names.Add("rahul");
            names.Add("ajay");
            names.Add("ashish");
            names.Add("amit");
            names.Add("anshu");
            int length = names.Count;
            int s = 0;
            //int n=names.IndexOf("ashish");
            for(s=0; s< names.Count; )
            {
                Console.WriteLine(s);
                //Console.WriteLine(names[s]);
                names.RemoveAt(s);
                
            }
            
            Console.WriteLine("After deletion");
            foreach(var ss in names)
                Console.WriteLine(ss);
             */
            /*Sum objsum = new Sum(add);
            objsum(5, 6);
            Program.getnum();*/
            //Console.WriteLine(n);
            Console.ReadKey();
           
           
        }
    }
}

#endregion
