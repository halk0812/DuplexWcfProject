using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DuplexWcfService
{
    [ServiceContract(CallbackContract =typeof(IMyCallBack))]
    public interface INamedPipeBindingService
    {
        [OperationContract(IsOneWay = true)]
        void GetData(int value);

        [OperationContract(IsOneWay = true)]
        void NewGetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

    }
    [ServiceContract]
    public interface IMyCallBack
    {
        [OperationContract(IsOneWay = true)]
        void CallBackFunction(string str);
    }
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool HasError
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string Message
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
