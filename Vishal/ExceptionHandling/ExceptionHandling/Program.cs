using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ExceptionHandling
{
    class Program : exceptionHandling
    {
        public static void Main(string[] args)
        {
            ExceptionHandling.Program program = new ExceptionHandling.Program();
            program.ProgramWithotException();
            //What is the Problem If u not handling the exception?
            //1. End user dose not able to undrestand the exception.
            //2. If the expcetion know to end user the it is very harmful for appliction and user.
            //3. streamreader does not close so until they use resourse.
            program.ProgramWithFileNotFoundException();
        }
    }
}
