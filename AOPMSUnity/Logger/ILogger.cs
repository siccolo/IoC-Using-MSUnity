using System;
namespace AOPMSUnity
{
    public interface ILogger
    {
        void Log(System.Exception exception, string caller = "", int line = 0);
        void Log(string text, string caller = "", int line=0);
    }
}
