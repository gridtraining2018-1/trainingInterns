using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadingDemo
{
    public class BaseKeyword
    {
        public int id = 25;
        public string name = "Radhey";
    }
    public class Test : BaseKeyword
    {
        public string name = "Mohan";
        public void Display()
        {
            Console.WriteLine("Name is  " + name);
            Console.WriteLine("Name is " + base.name +" "+ base.id);
        }
    }
}
