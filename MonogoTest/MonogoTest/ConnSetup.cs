using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonogoTest
{
    public partial class ConnSetup : Form
    {
        public ConnSetup()
        {
            InitializeComponent();

            txtUser.Enabled = txtPass.Enabled = !chkIntSec.Checked;
        }

        private void ChkIntSec_CheckedChanged(object sender, EventArgs e)
        {
            txtUser.Enabled = txtPass.Enabled = !chkIntSec.Checked;
        }

        private void BtnTestConn_Click(object sender, EventArgs e)
        {
            DBConnector dbCon = new DBConnector();
            if (dbCon.TestConnection(txtServer.Text, txtDb.Text, txtUser.Text, txtPass.Text, chkIntSec.Checked))
            {
                MessageBox.Show("Connection OK");
            }
            else
            {
                MessageBox.Show("Connection Failed");
            }
        }

        private void BtnSetConn_Click(object sender, EventArgs e)
        {
            DBConnector dbCon = new DBConnector();
            dbCon.SetConnection(txtServer.Text, txtDb.Text, txtUser.Text, txtPass.Text, chkIntSec.Checked);
            this.DialogResult = DialogResult.OK;
            this.Close();
       
        }
    }

}
