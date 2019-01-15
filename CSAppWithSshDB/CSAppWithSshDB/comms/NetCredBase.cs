/** 
 * System.Net.NetworkCredential doesn't have a port property, so we define our own creds class here
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAppWithSshDB.comms
{
    class NetCredBase
    {

        public String hostName { get; set; }
        public int port { get; set; }
        public String username { get; set; }
        public String password { get; set; }
    }
}
