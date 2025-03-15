using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ruth3rf0rdium.ruth3rf0rdiumNetwork.abstractclasses;

namespace ruth3rf0rdium.ruth3rf0rdiumNetwork.CLIENT
{
    public class CL_CONNECTIONTOAUTHORITYSERVER : TCPConnector
    {
        public override void connect(string ip, int port)
        {
            client = new System.Net.Sockets.TcpClient(ip, port);
        }

        public override void update()
        {
            
        }
    }
}
