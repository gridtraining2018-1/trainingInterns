using System;
using System.Collections.Generic;

public class ListExample
{
    public static void Main(string[] args)
    {
        // Create a list of strings  
        List<string> nameList = new List<string>();
        nameList.Add("hi");
        nameList.Add("hello");
        nameList.Add("good");

        foreach (string item in nameList)
        {
            Console.WriteLine(item);

        }

        for (int i = 0; i < nameList.Count; )
        {
			//i = 0;
            nameList.RemoveAt(i);

			
        }
		 foreach (string item in nameList)
        {
            Console.WriteLine(item);

        }
       // for(int i=0;)
        //Console.WriteLine(nameList);


        // names.Add("Sonoo Jaiswal");  
        // names.Add("Ankit");  
        // names.Add("Peter");  
        // names.Add("Irfan");  

        // // Iterate list element using foreach loop  
        // foreach (string name in names)  
        // {  
        // Console.WriteLine(name);  
        // }  
    }
}