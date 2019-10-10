using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Unity.Interception;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.PolicyInjection.Pipeline;

namespace AOPMSUnity
{
    public class Processor: IProcessor
    {
        IDataManager<string> _DataManager;
        public Processor(IDataManager<string> dataManager)
        {
            Console.WriteLine("Processor()");
            _DataManager = dataManager;
        }
        
        public async Task DoWork()//static async Task 
        {
            //var data = new Data();
            //var loaded = await data.Load();
            var loaded = await _DataManager.Load();

            //_DataManager.Pull().ForEach(e => Console.WriteLine(e));
            var all = _DataManager.Pull();
            foreach (var item in all)
            {
                Console.WriteLine(item);
            }

            var l = new List<string>() { "a1", "b1", "c1" };
            //var saved = await data.Put(l); 
            var saved = await _DataManager.Put(l);

            return;
        }
    }
}
