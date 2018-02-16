using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class exceptionHandling
    {
        public void ProgramWithotException()
        {
            System.IO.StreamReader streamReader = new System.IO.StreamReader("C:\\Users\\Vishal Jaiswal\\Documents\\Form.txt");
            Console.WriteLine(streamReader.ReadToEnd());
            streamReader.Close();
        }
        public void ProgramWithFileNotFoundException()
        {

        }      
    }
}
