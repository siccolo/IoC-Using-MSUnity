using System;
using System.Threading.Tasks;

namespace AOPMSUnity
{
    public interface IProcessor
    {
        Task DoWork();
    }
}
