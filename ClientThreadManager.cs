using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruth3rf0rdium
{
    public class ClientThreadManager
    {
        
        Mutex clientmutex;
       public void startclient()
        {
            clientmutex = new Mutex();
            clnt cl = new clnt(this);
            new Thread(new ThreadStart(cl.Main)).Start();
            
        }
    }
}
