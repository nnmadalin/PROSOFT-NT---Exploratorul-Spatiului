using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exploratorul_Spatiului
{
    public partial class admin_addnews : Form
    {
        public admin_addnews()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = textBox4.Text;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (uc_admin.statusnews == "add")
            {
                string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

                SqlConnection conn;
                conn = new SqlConnection(connstring);
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"insert into news values (@user, @title, @url_post, @url_image)", conn);
                cmd.Parameters.Add("@user", Form1.email);
                cmd.Parameters.Add("@title", textBox2.Text);
                cmd.Parameters.Add("@url_post", textBox3.Text);
                cmd.Parameters.Add("@url_image", textBox4.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("News salvat!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                uc_admin.status_refresh_3 = true;
                this.Close();
            }
            else
            {
                string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

                SqlConnection conn;
                conn = new SqlConnection(connstring);
                conn.Open();
                SqlCommand cmd;

                cmd = new SqlCommand(@"update [news] set title = @title, url_news = @urlnews, url_image = @urlimg where id = '" + uc_admin.idnews + "'", conn);
                cmd.Parameters.Add("@title", textBox2.Text);
                cmd.Parameters.Add("@urlnews", textBox2.Text);
                cmd.Parameters.Add("@urlimg", textBox2.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("News salvat!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                uc_admin.status_refresh_3 = true;
                this.Close();
            }
        }

        private void admin_addnews_Load(object sender, EventArgs e)
        {
            if (uc_admin.statusnews == "change")
            {
                string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

                SqlConnection conn;
                conn = new SqlConnection(connstring);
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"select * from news where id = '" + uc_admin.idnews + "'", conn);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    textBox2.Text = read["title"].ToString();
                    textBox3.Text = read["url_news"].ToString();
                    textBox4.Text = read["url_image"].ToString();
                    break;
                }
                conn.Close();
            }
        }
    }
}
