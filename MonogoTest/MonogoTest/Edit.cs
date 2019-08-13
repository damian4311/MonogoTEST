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
    public partial class Edit : Form
    {
        private int Id;
        public Edit(int _Id = 0)
        {
            InitializeComponent();
            if (_Id != 0)
            {
                Id = _Id;
                fillControls();
            }
        }
        private void fillControls()
        {
            dbObject obj = this.getDbObject();
            txtName.Text = obj.Name;
            txtEan.Text = obj.EAN.ToString();
            txtNet.Text = obj.Net.ToString();
            txtTax.Text = obj.Tax.ToString();
                
        }

        private dbObject getDbObject()
        {
            dbObject dbRow = new dbObject();


            using (SqlConnection conn = new SqlConnection(DBConnector.ConnectionString))
            {
                conn.Open();

                string sql = @"SELECT * FROM Product join Price on Price.Id = Product.Id where Product.Id = @id";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@id", this.Id);

                    var reader = comm.ExecuteReader();

                    int ordId = reader.GetOrdinal("id");
                    int ordName = reader.GetOrdinal("name");
                    int ordEan = reader.GetOrdinal("ean");
                    int ordNet = reader.GetOrdinal("Net");
                    int ordTax = reader.GetOrdinal("Tax");
                    while (reader.Read())
                    {
                        dbRow.Id = reader.GetInt32(ordId);
                        dbRow.Name = reader.GetString(ordName);
                        dbRow.EAN = reader.GetDecimal(ordEan);
                        dbRow.Tax = reader.GetDecimal(ordNet);
                        dbRow.Net = reader.GetInt32(ordTax);
                    }

                    return dbRow;
                }
            }
        }
        private void update()
        {
            using (SqlConnection conn = new SqlConnection(DBConnector.ConnectionString))
            {
                conn.Open();

                string sql = @"UPDATE Product set  Product.name = @name,Product.ean = @ean where Product.Id = @id";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@id", this.Id);
                    comm.Parameters.AddWithValue("@name", txtName.Text);
                    comm.Parameters.AddWithValue("@ean", txtEan.Text);
                    comm.ExecuteNonQuery();
                }
                string sql2 = @"UPDATE Price  Product set  Price.Net = @Net,Price.Tax = @Tax where Price.Id = @id";

                using (SqlCommand comm = new SqlCommand(sql2, conn))
                {
                    comm.Parameters.AddWithValue("@id", this.Id);
                    comm.Parameters.AddWithValue("@Net", txtNet.Text);
                    comm.Parameters.AddWithValue("@Tax", txtTax.Text);
                    comm.ExecuteNonQuery();
                }
                
            }
        }
        private void insert()
        {
            using (SqlConnection conn = new SqlConnection(DBConnector.ConnectionString))
            {
                conn.Open();

                string sql = @"declare @id as int;

                INSERT INTO [dbo].[Product]([name],[ean]) VALUES (@name,@ean)

                select @id = SCOPE_IDENTITY()

                INSERT INTO [dbo].[Price]([Id],[Net],[Tax]) VALUES(@id,@Net,@Tax)

                ";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@name", txtName.Text);
                    comm.Parameters.AddWithValue("@ean", txtEan.Text);

                    comm.Parameters.AddWithValue("@Net", txtNet.Text);
                    comm.Parameters.AddWithValue("@Tax", txtTax.Text);
                    comm.ExecuteNonQuery();
                }

            }
        }

        private class dbObject
        {
            public int Id;
            public string Name;
            public decimal EAN;
            public decimal Net;
            public decimal Tax;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Id != 0)
                    update();
                else
                    insert();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }
    }
}
