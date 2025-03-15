using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ruth3rf0rdium.ruth3rf0rdiumNetwork.abstractclasses;

namespace ruth3rf0rdium.ruth3rf0rdiumNetwork.NODESERVER
{
    public class NODE_CONNECTIONTOAUTHORITYSERVER : TCPConnector
    {
        public override void connect(string ip, int port)
        {
            client = new TcpClient(ip, port);
            rPacket packet = new rPacket();
            
        }

        public override void update()
        {
            
        }
    }
}
