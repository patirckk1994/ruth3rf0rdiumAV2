using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ruth3rf0rdium
{
    public class clientcontactdata
    {
        public int UUID;
        public Socket clientsocket;
        public string ipaddress;
        //int port;
       public string username;
        public string password;
        public string bitcoinaddress;
        public string email;
        public bool scanneravailable;
        
    }
}
