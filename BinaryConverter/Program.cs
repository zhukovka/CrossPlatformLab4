using Lab4ServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost serviceHost =
                                 new ServiceHost(serviceType: typeof(BinaryConverterService)))
            {
                try
                {
                    // Open the service, and close it again when the user
                    // presses a key
                    foreach (System.ServiceModel.Description.ServiceEndpoint se in serviceHost.Description.Endpoints)
                    {
                        Console.WriteLine("Address: {0}", se.Address);
                        Console.WriteLine("Binding: {0}", se.Binding.Name);
                        Console.WriteLine("Contract: {0}", se.Contract.Name);
                        Console.WriteLine();

                    }
                    serviceHost.Open();
                    Console.WriteLine("The service is running…");
                    Console.ReadLine();
                    serviceHost.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
        }
    }
}
