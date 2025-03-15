using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruth3rf0rdium
{
    public class ListenerThreadManager
    {
        List<bool> threadstermination = new List<bool>();

        Mutex listenermutex;
        public void startserver()
        {
            listenermutex = new Mutex();
            serv newserv = new serv(this);
            new Thread(new ThreadStart(newserv.Main)).Start();
        }
    }
}
