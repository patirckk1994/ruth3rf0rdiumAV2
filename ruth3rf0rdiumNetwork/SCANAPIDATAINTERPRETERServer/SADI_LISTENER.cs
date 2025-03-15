using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ruth3rf0rdium.ruth3rf0rdiumNetwork.abstractclasses;

namespace ruth3rf0rdium.ruth3rf0rdiumNetwork.SCANAPIDATAINTERPRETERServer
{
    public class SADI_LISTENER : LISTENER
    {
        public List<SADI_CONNECTIONTOSADI> connections = new List<SADI_CONNECTIONTOSADI>();
        public override void listen(int port)
        {
            listener = new System.Net.Sockets.TcpListener(port);
            listener.Start();
            listenerthread = new Thread(new ThreadStart(listenerthreadfunction));
            listenerthread.Start();
        }

        public override void listenerthreadfunction()
        {
            while (true)
            {
                TcpClient accepted = listener.AcceptTcpClient();
                lock (listenermutex)
                {
                    var sadicon = new SADI_CONNECTIONTOSADI();
                    sadicon.init(accepted);
                    connections.Add(sadicon);
                }
            }
        }

        public override void stoplistening()
        {
            stoplistener = true;
        }

        public override void update()
        {
            for (int i = 0; i < connections.Count; i++)
            {
                lock (listenermutex)
                {
                    connections[i].update();
                }
            }
        }
    }
}
