using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Runtime.Caching;
using System.Data.SqlClient;

namespace Exploratorul_Spatiului
{
    public partial class uc_home : UserControl
    {
        public uc_home()
        {
            InitializeComponent();
        }

        int id = 0, id_forum = 0;
        private void uc_home_Load(object sender, EventArgs e)
        {
            try
            {
                if (home.url_image_day.ToString().Trim() != "" && home.title_image_day.ToString().Trim() != "" && home.image_day == null)
                {
                    guna2PictureBox1.ImageLocation = home.url_image_day;
                    home.image_day = (Bitmap)guna2PictureBox1.Image;
                    textBox1.Text = home.title_image_day;
                }
                else if(guna2PictureBox1.ImageLocation != home.url_image_day)
                {
                    guna2PictureBox1.Image = home.image_day;
                    textBox1.Text = home.title_image_day;
                }
            }
            catch
            {
                ; ;
            }

            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"select * from cursuri order by Id desc", conn);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                id = Convert.ToInt32(read["Id"].ToString());
                label1.Text = read["name"].ToString();
                break;
            }
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(5, guna2PictureBox2.Height / 2 - label1.Height / 2);
            label1.MaximumSize = new Size(190, 0);
            guna2PictureBox2.Controls.Add(label1);

            cmd = new SqlCommand(@"select * from forum order by id desc", conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                id_forum = Convert.ToInt32(read["id"].ToString());
                label6.Text = read["title"].ToString();
                break;
            }

            label6.BackColor = Color.Transparent;
            label6.Location = new Point(5, guna2PictureBox3.Height / 2 - label6.Height / 2);
            label6.MaximumSize = new Size(190, 0);
            guna2PictureBox3.Controls.Add(label6);
        }

        private void go_course(object sender, EventArgs e)
        {
            uc_curs.id = id;
            home home = (home)Application.OpenForms["home"];
            var panel1 = (System.Windows.Forms.FlowLayoutPanel)home.Controls["flowLayoutPanel1"];
            UserControl uc = new uc_curs_lessson();
            panel1.Controls.Add(uc);
            panel1.Controls.SetChildIndex(uc, 0);
        }

        private void go_forum(object sender, EventArgs e)
        {
            home home = (home)Application.OpenForms["home"];
            var panel1 = (System.Windows.Forms.FlowLayoutPanel)home.Controls["flowLayoutPanel1"];
            uc_forum.id = id_forum.ToString();
            uc_forum_chat.nmax = 0;
            UserControl uc = new uc_forum_chat();
           
        }
    }
}
