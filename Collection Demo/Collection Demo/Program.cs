using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region list_Implementation
            int i;

            var names = new List<String>();
            names.Add("Anshu");
            names.Add("Jon Snow");
            names.Add("Shipra");

            //foreach (var name in names)
            foreach (var name in names)
            {
                Console.WriteLine(name);

            }

            for (i = 0; i <= names.Count - 1;)
            {
                //Console.WriteLine(names[i]);
                names.RemoveAt(i);
            }
            //Console.WriteLine(names.IndexOf("Shipra"));
            //names.Remove("Shipra");
            foreach (var name in names)
            {
                Console.WriteLine(name);

            }
            #endregion
            #region Dictonary
            int i;
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "sansa");
            dict.Add(2, "jonsnow");
            dict.Add(3, "ned stark");
            dict.Add(4, "arya");
            foreach (KeyValuePair<int, string> kv in dict)
            {
                Console.WriteLine(kv);
                
            }
            Console.WriteLine("\n");
           
            dict[1] = "Sansa_updated";
            foreach (KeyValuePair<int, string> kv in dict)
            {
                Console.WriteLine(kv);
                
            }
            Console.WriteLine("\n");
            for (i = 1; i <=dict.Count; i++)
            {
                dict[i] = "abc";
            }
            foreach (KeyValuePair<int, string> kv in dict)
            {
                Console.WriteLine(kv);
            }

            #endregion
            Console.ReadKey();

        }
    }
}
