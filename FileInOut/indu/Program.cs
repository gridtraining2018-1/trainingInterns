using System;


namespace operatorOverriding1
{
    class OperatorOverload
    {
        public int num=0;
        public string str = "";
        /*public void add(OperatorOverload ob1, OperatorOverload ob2)
        {

        //    public int sum = 0;
        //sum=ob1+ob2;
        //    return sum;
        }*/
    public static OperatorOverload operator+(OperatorOverload ob1, OperatorOverload ob2)
        {
            OperatorOverload ob = new OperatorOverload();
            ob.num = ob1.num + ob2.num;
            ob.str = ob1.str + ob2.str;
            Console.WriteLine(ob.num);
            Console.WriteLine(ob.str);
            return ob;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OperatorOverload ob1 = new OperatorOverload();
            OperatorOverload ob2 = new OperatorOverload();
            OperatorOverload ob = new OperatorOverload();
            ob1.num = 10;
            ob2.num = 20;
            ob1.str = "hello";
            ob2.str = "shiv";
            ob=ob1 + ob2;
            Console.ReadKey();
        }
    }
}
