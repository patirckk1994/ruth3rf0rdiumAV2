using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ruth3rf0rdium.ruth3rf0rdiumNetwork;
using ruth3rf0rdium.ruth3rf0rdiumNetwork.AUTHORITYSERVER;
using ruth3rf0rdium.ruth3rf0rdiumNetwork.CLIENT;
using ruth3rf0rdium.ruth3rf0rdiumNetwork.NODESERVER;
using ruth3rf0rdium.ruth3rf0rdiumNetwork.SCANAPIDATAINTERPRETERServer;
namespace ruth3rf0rdium
{
    public class AV
    {
        CROWDAVDB db = new CROWDAVDB();
        globalnetwork gnt = new globalnetwork();
        localnodenetwork lnt = new localnodenetwork();

        public NODE_LISTENER nl;
        public AUTH_LISTENER al;
        public SADI_LISTENER sl;
        public NODE_CONNECTIONTOAUTHORITYSERVER nctas;
        public CL_CONNECTIONTONODESERVER cctns;
        public CL_CONNECTIONTOAUTHORITYSERVER cctas;
        public enum role
        {
            AUTHORITYSERVER,
            NODESERVER,
            CLIENT
        }
        System.Threading.Mutex mutex;
        role rl;
        public void init(role rl)
        {
            this.rl = rl;
        }
       
        public void update()
        {
            if (al != null)
                al.update();
            if (nl != null)
                nl.update();
            if (nctas != null)
                nctas.update();
            if (cctns != null)
                cctns.update();
            if (cctas != null)
                cctas.update();
        }
        
        public string[] ListAllFilesOnOS()
        {
            return null;
        }
        public bool checkifresultexistsinnetwork(string filename)
        {
            return false;
        }
        public void AddNewFileToNetwork(string filename)
        {

        }
    }
}
