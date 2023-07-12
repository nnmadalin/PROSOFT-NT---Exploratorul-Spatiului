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

namespace Exploratorul_Spatiului
{
    public partial class add_topic : Form
    {
        public add_topic()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string text = guna2TextBox1.Text;
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";
            SqlConnection conn;
            conn = new SqlConnection(connstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"insert into forum values (@user, @title)", conn);
            cmd.Parameters.Add("@user", Form1.email);
            cmd.Parameters.Add("@title", text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Topic adaugat!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            UserControl uc = new uc_forum();
            uc_forum.check = true;
            this.Close();

        }
    }
}
