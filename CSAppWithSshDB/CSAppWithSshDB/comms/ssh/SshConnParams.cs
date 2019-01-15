using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSAppWithSshDB.comms;

namespace CSAppWithSshDB.comms.ssh
{
    class SshConnParams : NetCredBase
    {

        public SshConnParams()
        {
            hostName = "192.168.0.50";
            port = 22;
            username = "CSAppWithSshDB";
            password = "how23do44ssh67blanket";
        }
    }
}
