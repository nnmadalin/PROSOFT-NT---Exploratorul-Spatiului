using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exploratorul_Spatiului
{
    public partial class uc_cont : UserControl
    {
        public uc_cont()
        {
            InitializeComponent();
        }

        private void uc_cont_Load(object sender, EventArgs e)
        {
            guna2TextBox1.Text = Form1.fullname;
            guna2TextBox2.Text = Form1.email;
            guna2TextBox3.Text = Form1.ranks;
        }

    

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(guna2TextBox1.Text.Trim() != "" && guna2TextBox2.Text.Trim() != "")
            {
                string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"update users set fname = @fname, email = @email where id = '"+Form1.id+"'", conn);
                cmd.Parameters.Add("@fname", guna2TextBox1.Text);
                cmd.Parameters.Add("@email", guna2TextBox2.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Cont modificat cu succes", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Form form = new Form1();
                form.Show();
                this.Hide();
            }
        }
    }
}
