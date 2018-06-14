using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCallBack obj = new MyCallBack();
            obj.callService();
            obj.NewcallService();
            Console.Read();
            obj.Dispose();
        }
    }
}
