using Lab4ServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverterDLL
{
    public class BinaryConverterLib
    {
        public string RequestToBinaryConverter(int n)
        {
            string response = "";

            ChannelFactory<IBinaryConverter> factory = null;
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                EndpointAddress address = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/Lab4ServiceLibrary/Service1/");
                factory = new ChannelFactory<IBinaryConverter>(binding, address);
                IBinaryConverter channel = factory.CreateChannel();
                response = channel.GetBinary(n);
                factory.Close();
            }
            catch (Exception ex)
            {
                if (factory != null)
                {
                    factory.Abort();
                }
                response = ex.ToString();
            }
            return response;
        }
    }
}
