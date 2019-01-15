/**
 * 
 * Handles connections to MySQL DB  
 * throws Exception if we cannot connect to the server
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace CSAppWithSshDB.comms.db
{
    class MysqlServer
    {

        private static MysqlServer instance = null;
        private static readonly object padlock = new object();
        public MySqlConnection MysqlConn { get;  }

        private MysqlServer()
        {
            // fetch connection params string
            MysqlConnectionParams MysqlConnectionParams = new MysqlConnectionParams();
            String connParams = MysqlConnectionParams.getConnectionString();
            Console.WriteLine("Connecting to Mysql Server");
            // make connection
            this.MysqlConn = new MySqlConnection(connParams);

            Console.WriteLine("Mysql Server connection established");
        }

        public static MysqlServer Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MysqlServer();
                    }
                    return instance;
                }

            }
        }
    }
}


