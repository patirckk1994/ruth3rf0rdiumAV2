using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
namespace ruth3rf0rdium.ruth3rf0rdiumNetwork.abstractclasses
{
    public abstract class LISTENER
    {
        public TcpListener listener;
        public bool stoplistener = false;
        public Thread listenerthread;
        public List<Thread> clientthreads = new List<Thread>();
        public Mutex listenermutex = new Mutex();
       
        public abstract void listen(int port);
        public abstract void stoplistening();
        public abstract void listenerthreadfunction();
        public abstract void update();
    }
}
