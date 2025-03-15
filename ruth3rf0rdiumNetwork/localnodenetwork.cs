using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ruth3rf0rdium.ruth3rf0rdiumNetwork
{
    public class localnodenetwork : networknode
    {
        public nodeServercontactdata server;
        public List<nodeServercontactdata> otherservers = new List<nodeServercontactdata>();
        public List<clientcontactdata> contacts = new List<clientcontactdata>();
        
        public override void addfiletonetworkifnonexistent(string filename)
        {
            throw new NotImplementedException();
        }

   

        public override void fileexists(string hash)
        {
            throw new NotImplementedException();
        }
    }
}
