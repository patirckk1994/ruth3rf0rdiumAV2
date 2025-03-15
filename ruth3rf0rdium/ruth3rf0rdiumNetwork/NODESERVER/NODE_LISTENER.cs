using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ruth3rf0rdium.ruth3rf0rdiumNetwork.abstractclasses;
using System.Net;
using System.Net.Sockets;
namespace ruth3rf0rdium.ruth3rf0rdiumNetwork.NODESERVER
{
    public class NODE_LISTENER : LISTENER
    {
        public List<NODE_CONNECTIONTOCLIENT> clientconnections = new List<NODE_CONNECTIONTOCLIENT>();
        public override void listen(int port)
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            listenerthread = new Thread(new ThreadStart(listenerthreadfunction));
            listenerthread.Start();
        }

        public override void listenerthreadfunction()
        {
            
            while (!stoplistener)
            {
                
                lock (listenermutex)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    var cl = new NODE_CONNECTIONTOCLIENT();
                    cl.init(client);
                    clientconnections.Add(cl);

                }
               
            }
            listener.Stop();
        }

        public override void stoplistening()
        {
            lock (listenermutex)
                stoplistener = true;
        }

        public override void update()
        {
            while (true)
            {
                lock (listenermutex)
                {
                    foreach(var con in clientconnections)
                    {
                        con.update();
                    }
                }
            }
        }
    }
}
