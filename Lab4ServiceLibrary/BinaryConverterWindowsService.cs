using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Lab4ServiceLibrary
{
    class BinaryConverterWindowsService : ServiceBase
    {
        public ServiceHost serviceHost = null;

        public BinaryConverterWindowsService()
        {
            ServiceName = "WCFWindowsServiceSample";
        }

        public static void Main()
        {
            ServiceBase.Run(new BinaryConverterWindowsService());
        }

        // Start the Windows service.
        protected override void OnStart(string[] args)
        {
            string path = @"c:\temp\except.txt";
            StreamWriter sw = File.CreateText(path);


            if (serviceHost != null)

            {
                serviceHost.Close();
            }
            try
            {
                serviceHost = new ServiceHost(typeof(BinaryConverterService));
                serviceHost.Open();
            }

            catch (Exception e)
            {
                sw.WriteLine("The process failed: {0}",
                e.ToString());
            }
            finally { sw.Close(); }
        }
        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}
