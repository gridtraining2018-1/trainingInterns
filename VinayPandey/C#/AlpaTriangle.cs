using System;
 namespace Alpha
 {
	 class Triangle
	 {
		 static void Main()
		 {
			 char ch='A';
			 int i,j,k,m,n;
			 Console.WriteLine("Enter the range for printing the alphabet");
			 n=Convert.ToInt32(Console.ReadLine());
			 for(i=1;i<=n;i++)
			 {
				 for(j=n;j>=i;j--)
					 Console.Write(" ");
				 for(k=1;k<=i;k++)
					 Console.Write(ch++);
				 ch--;
				 for(m=1;m<i;m++)
					 Console.Write(--ch);
				 Console.Write("\n");
				 ch='A';
			 }
		 }
	 }
 }