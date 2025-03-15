using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using ruth3rf0rdium.ruth3rf0rdiumNetwork.abstractclasses;
namespace ruth3rf0rdium.ruth3rf0rdiumNetwork.AUTHORITYSERVER
{
    public class AUTH_LISTENER : LISTENER
    {
        TcpListener listener;
        public List<AUTH_CONNECTIONTONODESERVER> connections = new List<AUTH_CONNECTIONTONODESERVER>();
        
        public override void listen(int port)
        {
            stoplistener = false;
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            listenerthread = new Thread(new ThreadStart(listenerthreadfunction));
            listenerthread.Start();
        }

        public override void stoplistening()
        {
            stoplistener = true;
        }
        public override void listenerthreadfunction()
        {
            while (!stoplistener)
            {
                TcpClient accepted = listener.AcceptTcpClient();
                lock (listenermutex)
                {
                    AUTH_CONNECTIONTONODESERVER newcon = new AUTH_CONNECTIONTONODESERVER();
                    
                    newcon.init(accepted);
                    newcon.startthreads();
                    connections.Add(newcon);
                }
            }
        }

        public override void update()
        {
            while (true)
            {
                lock (listenermutex)
                {
                    foreach (var con in connections)
                    {
                        con.update();
                    }
                }
            }
        }
    }
}
