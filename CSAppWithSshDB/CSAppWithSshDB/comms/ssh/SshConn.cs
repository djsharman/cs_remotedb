/**
 * Handles setting up an SSH connection to a server
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace CSAppWithSshDB.comms.ssh
{
    class SshConn
    {
        SshClient client = null;
        ForwardedPortLocal port = null;

        ~SshConn()
        {
            Console.WriteLine("SSH connection shutting down");
            if (port != null)
            {
                Console.WriteLine("SSH connection stopping port forward");
                port.Stop();
            }
            if (client != null)
            {
                Console.WriteLine("SSH connection disconnecting");
                client.Disconnect();
            }

        }

        public void connect()
        {
            SshConnParams connParams = new SshConnParams();

            Console.WriteLine("Connecting SSH");

            client = new SshClient(connParams.hostName, connParams.port, connParams.username, connParams.password);
            client.Connect();

            Console.WriteLine("SSH connection established");

            var port = new ForwardedPortLocal("127.0.0.1", 53306, "127.0.0.1", 53306);
            client.AddForwardedPort(port);

            port.Exception += delegate (object sender, ExceptionEventArgs e)
            {
                Console.WriteLine(e.Exception.ToString());
            };
            port.Start();

            Console.WriteLine("SSH port forward established");

        }
    }
}
