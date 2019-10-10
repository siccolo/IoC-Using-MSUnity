using System;
 
namespace AOPMSUnity
{
    public class Logger:ILogger
    {
        public Logger()
        {
        }

        public void Log(Exception exception
                , [System.Runtime.CompilerServices.CallerMemberName] string caller = ""
                , [System.Runtime.CompilerServices.CallerLineNumber] int line = 0
            )
        {
            Console.WriteLine($"Exception in {caller} at {line} - " + exception.ToString() );
        }

        public void Log(string text
                , [System.Runtime.CompilerServices.CallerMemberName] string caller = ""
                , [System.Runtime.CompilerServices.CallerLineNumber] int line = 0)
        {
            Console.WriteLine($"{caller} at {line} - " + text);
        }
    }
}
