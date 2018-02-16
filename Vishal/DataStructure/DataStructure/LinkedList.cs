using System;
namespace DataStructure
{
    
   
    class LinkedList
    {
        class Node
        {
            public int data;
            public Node next;
            public Node(int data)
            {
                this.data = data;
                next = null;
            }
        }


        static void Main(string[] args)
        {
            Node start;
            Node node1 = new Node(10);
            Node node2 = new Node(20);
            Node node3 = new Node(30);
            start = node1;
            node1.next = node2;
            node2.next = node3;
            while(start!= null)
            {
                Console.WriteLine("Data = {0}",start.data);
                start = start.next;
            }
        }
    }

}
