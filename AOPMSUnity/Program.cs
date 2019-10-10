using System;
using Unity.Interception;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.PolicyInjection.Pipeline;

namespace AOPMSUnity
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            
            using (var container = new Unity.UnityContainer())
            {
                container.AddNewExtension<Interception>();

                container.RegisterType(typeof(IDataContainer<string>), typeof(DataContainer)
                                                   , new Interceptor<InterfaceInterceptor>()
                                                   , new InterceptionBehavior<LoggingAspect>());

                container.RegisterType(typeof(IDataManager<string>), typeof(DataManager)
                                                   , new Interceptor<InterfaceInterceptor>()
                                                   , new InterceptionBehavior<LoggingAspect>());

                container.RegisterType<IProcessor, Processor>(
                                                    new Interceptor<InterfaceInterceptor>()
                                                    , new InterceptionBehavior<LoggingAspect>());
                                                    
                var processor = container.Resolve<IProcessor>();
                var result = processor.DoWork();
            }
            
            /*
            Processor processor = DependencyInjector.Retrieve<Processor>();
            var result = processor.DoWork();
            */
        }
    }
}
