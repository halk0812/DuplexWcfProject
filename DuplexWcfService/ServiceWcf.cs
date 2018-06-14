using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace DuplexWcfService
{
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.PerCall)]
    public class ServiceWcf : INamedPipeBindingService
    {
        public void GetData(int value)
        {
            IMyCallBack callback = OperationContext.Current.GetCallbackChannel<IMyCallBack>();
            callback.CallBackFunction("Calling from Call Back");
            for(int i=0; i<value;i++)
            {
                callback.CallBackFunction(i.ToString());
                Thread.Sleep(1000);
            }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.HasError)
            {
                composite.Message += "Suffix";
            }
            return composite;
        }

        public void NewGetData(int value)
        {
            IMyCallBack callback = OperationContext.Current.GetCallbackChannel<IMyCallBack>();
            callback.CallBackFunction("Calling from Call Back");
            for (int i = 0; i < value; i++)
            {
                callback.CallBackFunction($"I am NewCallback: {i}");
                Thread.Sleep(1000);
            }
        }
    }
}
