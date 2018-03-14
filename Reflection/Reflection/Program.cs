using System;
using System.Reflection;

public class MyClass
{
    public virtual int AddNumb(int numb1, int numb2)
    {
        int result = numb1 + numb2;
        return result;
    }

}

class MyMainClass
{
    public static int Main()
    {
        Console.WriteLine("\nReflection.MethodInfo");
        // Create MyClass object
        MyClass myClassObj = new MyClass();
        // Get the Type information.
        Type myTypeObj = myClassObj.GetType();
        // Get Method Information.
        MethodInfo myMethodInfo = myTypeObj.GetMethod("AddNumb");
        object[] mParam = new object[] { 5, 10 };
        // Get and display the Invoke method.
        Console.Write("\nFirst method - " + myTypeObj.FullName + " returns " +
                             myMethodInfo.Invoke(myClassObj, mParam) + "\n");
        return 0;
    }
}