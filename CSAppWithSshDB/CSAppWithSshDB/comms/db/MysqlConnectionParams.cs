using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSAppWithSshDB.comms;

namespace CSAppWithSshDB.comms.db
{
    class MysqlConnectionParams : NetCredBase
    {
        public MysqlConnectionParams()
        {
            //hostName = "192.168.0.50";
            hostName = "127.0.0.1";
            port = 53306;
            username = "root";
            password = "college";
        }

        public String getConnectionString()
        {
            String fullString;
            fullString = "datasource=" + hostName + ";";
            fullString += "port=" + port.ToString() + ";";
            fullString += "username=" + username + ";";
            fullString += "password=" + password + ";";

            return fullString;
        }
    }
}
