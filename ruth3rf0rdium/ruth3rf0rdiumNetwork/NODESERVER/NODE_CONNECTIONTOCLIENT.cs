using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ruth3rf0rdium.ruth3rf0rdiumNetwork.abstractclasses;

namespace ruth3rf0rdium.ruth3rf0rdiumNetwork.NODESERVER
{
    public class NODE_CONNECTIONTOCLIENT : TCPConnection
    {
        public void initprotocol()
        {

        }
        public override void update()
        {
            lock (sendreceivemutex)
            {


                while (incomingpackets.Count != 0)
                {
                    MessageBox.Show("dequeuing packet");
                }
            }
        }
    }
}
