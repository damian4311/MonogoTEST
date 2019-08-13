using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonogoTest
{
    public partial class Form1 : Form
    {
        DataSet ds = new DataSet();
        public Form1()
        {
            InitializeComponent();

            Connect();
            this.dataGridView1.AllowUserToAddRows = false;
        }

        private void Connect()
        {
            string message;
            DBConnector dbConn = new DBConnector();
            ConnectionResult result = dbConn.InitConnection(out message);

            if (result != ConnectionResult.Ok)
            {
                if (result == ConnectionResult.DbCreated )
                {
                    this.fillGrids();
                }
                MessageBox.Show(message);
            }
            else
            {
                this.fillGrids();
            }
        }

        private void fillGrids()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = DBConnector.ConnectionString;
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM Product join Price on Price.Id = Product.Id";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
                
        }

        private void BtnConnectionSetup_Click(object sender, EventArgs e)
        {
            ConnSetup setup = new ConnSetup();
            if (setup.ShowDialog() == DialogResult.OK)
            {
                Connect();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count>0)
            {
                Edit edit = new Edit((int)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Id"].Value);
                if (edit.ShowDialog() == DialogResult.OK)
                {
                    fillGrids();
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Edit edit = new Edit();
            if (edit.ShowDialog() == DialogResult.OK)
            {
                fillGrids();
            }
        }
    }
}
