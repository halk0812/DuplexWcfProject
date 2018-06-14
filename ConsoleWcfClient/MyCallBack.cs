using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ConsoleWcfClient.ServiceReference;
namespace ConsoleWcfClient
{
    class MyCallBack :INamedPipeBindingServiceCallback ,IDisposable
    {
        NamedPipeBindingServiceClient proxy;    
        public void   CallBackFunction(string str)
        {
            Console.WriteLine(str);
        }
        
        public void callService()
        {
           InstanceContext context = new InstanceContext(this);
           proxy = new NamedPipeBindingServiceClient(context);
           proxy.GetData(5);
        }
        public void NewcallService()
        {
            InstanceContext context = new InstanceContext(this);
            proxy = new NamedPipeBindingServiceClient(context);
            proxy.NewGetData(5);
        }
        public void Dispose()
        {
            proxy.Close();
        }
    }
}
