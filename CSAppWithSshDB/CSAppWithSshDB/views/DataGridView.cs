using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSAppWithSshDB.comms.db;
using MySql.Data.MySqlClient;

namespace CSAppWithSshDB.views
{
    public partial class DataGridView : Form
    {

        private static DataGridView instance = null;

        MySqlDataAdapter adapter;
        DataSet dataSet;

    
        public DataGridView()
        {
            InitializeComponent();
            instance = this;
        }

        public static DataGridView Instance
        {
            get
            {
                return instance;
            }
        }

        private void DataGridView_Load(object sender, EventArgs e)
        {

            try
            {
                // get mysql connection
                MySqlConnection MysqlConn = MysqlServer.Instance.MysqlConn;

                Console.WriteLine("Starting mysql adapter");
                // init adapter
                adapter = new MySqlDataAdapter("SELECT * from employees.employees LIMIT 0,100", MysqlConn);
                adapter.RowUpdated += new MySqlRowUpdatedEventHandler(OnRowUpdating);

                Console.WriteLine("Preparing dataset");

                // grab employees data and attach it to the grid view
                dataSet = new DataSet();
                adapter.Fill(dataSet, "employees");

                Console.WriteLine("Setting gridview datasource");
                dataGridView1.DataSource = dataSet.Tables["employees"];

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        static void OnRowUpdating(object sender, MySqlRowUpdatedEventArgs e)
        {
            
            if (e.Command != null)
            {
                System.Windows.Forms.TextBox cmdDebugBox = DataGridView.Instance.cmdDebugBox;
                cmdDebugBox.Text = "Row Updating...";
                cmdDebugBox.Text += "Command type: -> ";
                cmdDebugBox.Text += e.StatementType.ToString();
                cmdDebugBox.Text += "\r\nCommand text:\r\n";
                cmdDebugBox.Text += e.Command.CommandText.ToString();
                cmdDebugBox.Text += "\r\nParameters:";
                foreach (MySqlParameter p in e.Command.Parameters)
                {
                    cmdDebugBox.Text += "\r\n" + p.ParameterName + " - " +  p.Value;    
                }
                
            }


        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                MySqlCommandBuilder cmdBuilder = new MySqlCommandBuilder(adapter);
                String updateCommand = cmdBuilder.GetUpdateCommand().CommandText;

                adapter.Update(dataSet, "employees");
                //MessageBox.Show("Updated");
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void cmdDebugBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
