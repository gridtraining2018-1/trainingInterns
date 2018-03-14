using System;
delegate int Del(int n);
namespace Dele{
	class Gates{
		static int n=10;
		public static int add(int p){
			n += p;
			return n;
		}
		public static int div(int t){
		try{
		
			n=n/t;
			
		}
		catch(Exception e){
			Console.WriteLine(e);
		}
		return n;
		}
		
		
		public static int get(){
			return n;
		}
	
	
		static void Main(){
			Del dl=new Del(add);
			Del dl2=new Del(div);
			
			dl(3);
			Console.WriteLine("addition is=" + get());
			dl2(10);
			Console.WriteLine("division is=" + get());
		}
	}
	
}