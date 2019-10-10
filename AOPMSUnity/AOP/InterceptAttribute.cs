using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.Interception;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.PolicyInjection.Pipeline;

namespace AOPMSUnity
{
    public class LoggingAspect : IInterceptionBehavior, ILogger
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            // Before invoking the method on the original target.   
            WriteLog($"{DateTime.Now.ToString("HH:mm:ss")} --> {input.MethodBase.Name}");
            // Invoke the next behavior in the chain. 
            var result = getNext()(input, getNext);
            return result;

            // After invoking the method on the original target. 
            if (result.Exception != null)
            {
                WriteLog(String.Format("Method {0} threw exception {1} at {2}", input.MethodBase, result.Exception.Message, DateTime.Now.ToString()));
            }
            else
            {
                WriteLog(String.Format("Method {0} returned {1} at {2}", input.MethodBase, result.ReturnValue, DateTime.Now.ToString()));
            }

            return result;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }
        public bool WillExecute { get { return true; } }

        private void WriteLog(string message)
        {
            Log("LOG:" + message);
        }

        public void Log(Exception exception, string caller = "", int line = 0)
        {
            Console.WriteLine($"Exception in {caller} at {line} - " + exception.ToString());
        }

        public void Log(string text, string caller = "", int line = 0)
        {
            Console.WriteLine($"{caller} at {line} - " + text);
        }
    }
}
