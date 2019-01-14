using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAppWithSshDB.comms.db
{
    class MysqlConnectionParams
    {
        private String hostName = "192.168.0.50";
        private int port = 53306;
        private String username = "root";
        private String password = "college";

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
