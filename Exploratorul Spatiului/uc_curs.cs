using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Web.UI.WebControls;

namespace Exploratorul_Spatiului
{
    public partial class uc_curs : UserControl
    {
        public uc_curs()
        {
            InitializeComponent();
        }

        string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

        SqlConnection conn;

        int x = 40, y = 40;
        public static int id = 0;

        void btn_click_lectie(object sender, EventArgs e)
        {
            home home = (home)Application.OpenForms["home"];
            var panel1 = (System.Windows.Forms.FlowLayoutPanel)home.Controls["flowLayoutPanel1"];
 
            Guna.UI2.WinForms.Guna2Button btn = sender as Guna.UI2.WinForms.Guna2Button;
            id = Convert.ToInt32(btn.Tag);
            UserControl uc = new uc_curs_lessson();
            panel1.Controls.Add(uc);
            panel1.Controls.SetChildIndex(uc, 0);
        }
        void btn_click_quiz(object sender, EventArgs e)
        {
            home home = (home)Application.OpenForms["home"];
            var panel1 = (System.Windows.Forms.FlowLayoutPanel)home.Controls["flowLayoutPanel1"];

            Guna.UI2.WinForms.Guna2Button btn = sender as Guna.UI2.WinForms.Guna2Button;
            id = Convert.ToInt32(btn.Tag);
            UserControl uc = new uc_curs_quiz();
            panel1.Controls.Add(uc);
            panel1.Controls.SetChildIndex(uc, 0);

        }

        bool[] idq = new bool[1000];
        private void uc_curs_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            conn.Open();

            SqlCommand cmd = new SqlCommand(@"SET ARITHABORT ON", conn);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand(@"SET QUOTED_IDENTIFIER ON", conn);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand(@"SET ANSI_NULLS ON", conn);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand(@"select Id from cursuri", conn);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                string x = read["Id"].ToString();
                SqlCommand cmd2 = new SqlCommand(@"select * from cursterminat", conn);
                SqlDataReader read2 = cmd2.ExecuteReader();
                while (read2.Read())
                {
                    if (read2["user"].ToString() == Form1.email && read2["points"].ToString() == "100" && read2["idcurs"].ToString() == x)
                    {
                        idq[Convert.ToInt32(x)] = true;
                        break;
                    }
                }
            }


            cmd = new SqlCommand(@"select Id, name, description from cursuri", conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                int iq = (Convert.ToInt32(read["Id"].ToString())) % 10 + 1;
                Guna.UI2.WinForms.Guna2ShadowPanel panel = new Guna.UI2.WinForms.Guna2ShadowPanel();
                panel.Width = 380;
                panel.Height = 200;
                panel.Location = new Point(x, y);
                panel.FillColor = Color.FromArgb(79, 76, 83);                
                panel.Radius = 10;

                if (idq[Convert.ToInt32(read["Id"].ToString())] == true)
                {
                    panel.ShadowColor = Color.FromArgb(85, 173, 105);
                    panel.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Surrounded;
                    panel.ShadowDepth = 100;
                    panel.ShadowShift = 10;
                }

                Guna.UI2.WinForms.Guna2PictureBox pct = new Guna.UI2.WinForms.Guna2PictureBox();
                pct.Image = System.Drawing.Image.FromFile(Application.StartupPath + "/Data/img_unsplash_course/" + iq.ToString() + ".jpg");
                pct.SizeMode = PictureBoxSizeMode.StretchImage;
                pct.Location = new Point(0, 0);
                pct.Size = new Size(380, 200);
                pct.BorderRadius = 10;

                var txt = new System.Windows.Forms.Label();
                txt.AutoSize = true;            
                txt.TextAlign = ContentAlignment.MiddleLeft;
                txt.Dock = DockStyle.None;
                txt.BackColor = Color.Transparent;                
                txt.Font = new Font("Segoe UI Semibold", 19, FontStyle.Bold);
                txt.ForeColor = Color.White;
                txt.Text = read["name"].ToString();
                txt.MaximumSize = new Size(330, 0);
                txt.Location = new Point(30, 24);

                var txt2 = new System.Windows.Forms.Label();
                txt2.AutoSize = true;
                txt2.TextAlign = ContentAlignment.MiddleLeft;
                txt2.Dock = DockStyle.None;
                txt2.BackColor = Color.Transparent;
                txt2.Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold);
                txt2.ForeColor = Color.White;
                txt2.Text = read["description"].ToString();
                txt2.MaximumSize = new Size(320, 0);
                txt2.Location = new Point(30, 63);

                var btn = new Guna.UI2.WinForms.Guna2Button();
                btn.Size = new Size(123, 35);
                btn.Location = new Point(27, 154);
                btn.FillColor = Color.FromArgb(42, 61, 79);
                btn.Text = "Lectie";
                btn.UseTransparentBackground = true;
                btn.BorderRadius = 10;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 9);
                btn.Tag = read["Id"].ToString();
                btn.Click += new EventHandler(btn_click_lectie);              

                var btn2 = new Guna.UI2.WinForms.Guna2Button();
                btn2.Size = new Size(123, 35);
                btn2.Location = new Point(230, 154);
                btn2.FillColor = Color.FromArgb(42, 61, 79);
                btn2.Text = "Quiz";
                btn2.UseTransparentBackground = true;
                btn2.BorderRadius = 10;
                btn2.ForeColor = Color.White;
                btn2.Font = new Font("Segoe UI", 9);
                btn2.Tag = read["Id"].ToString();
                btn2.Click += new EventHandler(btn_click_quiz);


                pct.Controls.Add(txt);
                pct.Controls.Add(txt2);
                pct.Controls.Add(btn);
                pct.Controls.Add(btn2);
                panel.Controls.Add(pct);
                this.Controls.Add(panel);
                x += 460;
                if(x > 600)
                {
                    x = 40;
                    y += 240;
                }
            }
        }
    }
}
