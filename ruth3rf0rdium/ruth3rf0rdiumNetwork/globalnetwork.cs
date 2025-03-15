using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruth3rf0rdium.ruth3rf0rdiumNetwork
{
    internal class globalnetwork : networknode
    {
        public List<localnodenetwork> lnts = new List<localnodenetwork>();
        public void sumupnetwork()
        {

        }
        public void broadcastnetworkdelta(List<localnodenetwork> removed, List<localnodenetwork> added)
        {

        }

        public override void fileexists(string hash)
        {
        }

        public override void addfiletonetworkifnonexistent(string filename)
        {
        }
    }
}
