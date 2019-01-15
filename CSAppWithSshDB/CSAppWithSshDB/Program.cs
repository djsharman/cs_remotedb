using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSAppWithSshDB.comms.ssh;

namespace CSAppWithSshDB
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // make an ssh connection
                SshConn sshConn = new SshConn();
                sshConn.connect();

                //System.Threading.Thread.Sleep(1000);

                // run the main dialog which connects to the mysql server
                Application.Run(new CSAppWithSshDB.views.DataGridView());
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
