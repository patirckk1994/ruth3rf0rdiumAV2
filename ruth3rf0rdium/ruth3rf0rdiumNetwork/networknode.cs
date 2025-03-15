using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruth3rf0rdium.ruth3rf0rdiumNetwork
{
    public abstract class networknode
    {
        public abstract void fileexists(string hash);
        public abstract void addfiletonetworkifnonexistent(string filename);
    }
}
