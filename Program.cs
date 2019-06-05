using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DocumentCollection.Log;
using DocumentCollectionData;


namespace DocumentCollection
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Test";
            AppDomain.CurrentDomain.UnhandledException += (sender, eventargs) =>
            {
                Exception e = (Exception)eventargs.ExceptionObject;
                Logger.Info(e);
            };
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;

            DataProcess dataProcess = new DataProcess( @"H:\各工序文件获取格式归类", new string[] { });

            var dt = dataProcess.Collection();

            Console.Read();
        }
    }
}
