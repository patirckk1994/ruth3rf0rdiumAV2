using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ruth3rf0rdium.ruth3rf0rdiumNetwork.abstractclasses;
using System.Net;
using System.Net.Sockets;
namespace ruth3rf0rdium.ruth3rf0rdiumNetwork.CLIENT
{
    public class CL_CONNECTIONTONODESERVER : TCPConnector
    {
        public override void connect(string ip, int port)
        {
            client = new TcpClient();
            client.Connect(ip,port);
            startthreads();
        }

        public override void update()
        {
          


                while (incomingpackets.Count != 0)
                {
                lock (sendreceivemutex)
                {
                    MessageBox.Show("dequeuing packet");
                }
            }
            
        }
    }
}
