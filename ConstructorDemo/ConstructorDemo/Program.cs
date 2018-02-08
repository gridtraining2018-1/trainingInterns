using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDemo
{
    public class DefaultCons
    {
        public DefaultCons()
        {
            Console.WriteLine("This is Defaault constructor");
           
           
            
        }
    }
    public class ParaCons
    {
        int id;
        string name;
        public ParaCons(int i, string n)
        {
            id = i;
            name = n;
        }
        ~ParaCons()
        {
            Console.WriteLine("Destructor invoked");
        }
        public void Display()
        {
            Console.WriteLine(id + " " + name);
        }
    }

    public class ThisKey
    {
        public int id;
        public string name;

        public ThisKey(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public void Display()
        {
            Console.WriteLine(id +" "+ name);
           
        }
    }

    public static class StaticClass
    {
        public static float pi = 3.14f;

        public static int cube(int n)
        {
            return n * n * n;
        }
    }

    public class Employee
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    }


    class Program
    {
        public enum Season { WINTER = 10, SPRING, SUMMER, FALL }
        public enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat };

        static void Main(string[] args)
        {
            // DefaultCons defaultCons = new DefaultCons();
            //ParaCons paraCons = new ParaCons(25, "Anshuman");
            //paraCons.Display();
            //ThisKey thisKey = new ThisKey(44, "Jon");
            //thisKey.Display();
            //Console.WriteLine("Value of PI is " + StaticClass.pi);
            //Console.WriteLine("Cube is "+ StaticClass.cube(9));
            int x = (int)Season.WINTER;
            int y = (int)Season.SUMMER;
            Console.WriteLine("WINTER = {0}", x);
            Console.WriteLine("SUMMER = {0}", y);
            int m = (int)Days.Sun;
            int o = (int)Days.Mon;
            int p = (int)Days.Sat;
            Console.WriteLine("Sun = {0}", m);
            Console.WriteLine("Mon = {0}", o);
            Console.WriteLine("Sat = {0}", p);

            Employee employee = new Employee();
            employee.Name = "Anshuman";
            Console.Write("\nThe name is " + employee.Name);
            Console.ReadKey();

        }
    }
}
