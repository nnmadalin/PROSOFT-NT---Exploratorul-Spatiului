using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exploratorul_Spatiului
{
    public partial class uc_forum : UserControl
    {
        public uc_forum()
        {
            InitializeComponent();
        }
        int x = 10, y = 20;

        public static string id;
        void click_forum_picture(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2PictureBox pct = sender as Guna.UI2.WinForms.Guna2PictureBox;
            id = pct.Tag.ToString();

            home home = (home)Application.OpenForms["home"];
            var panel1 = (System.Windows.Forms.FlowLayoutPanel)home.Controls["flowLayoutPanel1"];
            uc_forum_chat.nmax = 0;
            UserControl uc = new uc_forum_chat();
            panel1.Controls.Add(uc);
            panel1.Controls.SetChildIndex(uc, 0);
            
        }
        void click_forum_label(object sender, EventArgs e)
        {
            Label label = sender as Label;
            id = label.Tag.ToString();

            home home = (home)Application.OpenForms["home"];
            var panel1 = (System.Windows.Forms.FlowLayoutPanel)home.Controls["flowLayoutPanel1"];
            uc_forum_chat.nmax = 0;
            UserControl uc = new uc_forum_chat();
            panel1.Controls.Add(uc);
            panel1.Controls.SetChildIndex(uc, 0);
            
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            var frm = new add_topic();
            frm.Show();
        }

        public static bool check = false;

        private async void refresh()
        {
            await Task.Run(() =>
            {
                string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

                SqlConnection conn;
                conn = new SqlConnection(connstring);
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"select id, title from forum", conn);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    int iq = Convert.ToInt32(read["id"].ToString()) % 10 + 1;

                    Guna.UI2.WinForms.Guna2Panel panel = new Guna.UI2.WinForms.Guna2Panel();
                    panel.Size = new Size(411, 238);
                    panel.Location = new Point(x, y);
                    panel.BorderRadius = 10;


                    Guna.UI2.WinForms.Guna2PictureBox pct = new Guna.UI2.WinForms.Guna2PictureBox();
                    pct.Image = Image.FromFile(Application.StartupPath + "/Data/img_unsplash_forum/" + iq.ToString() + ".jpg");
                    pct.SizeMode = PictureBoxSizeMode.StretchImage;
                    pct.Location = new Point(0, 0);
                    pct.Size = new Size(411, 238);
                    pct.BorderRadius = 10;
                    pct.Tag = (iq - 1).ToString();

                    Label title = new Label
                    {

                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.None,
                        Parent = panel,
                        BackColor = Color.Transparent,
                        Font = new Font("Segoe UI Semibold", 17, FontStyle.Bold),
                        ForeColor = Color.White,
                        Text = read["title"].ToString(),
                        MaximumSize = new Size(330, 0),
                        Tag = (iq - 1).ToString()
                    };
                    title.Location = new Point(pct.Width / 2 - title.Width / 2, pct.Height / 2 - title.Height / 2);
                    title.BringToFront();

                    if (InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            pct.Controls.Add(title);
                            panel.Controls.Add(pct);
                            panel1.Controls.Add(panel);
                        }));
                    }
                    else
                    {
                        pct.Controls.Add(title);
                        panel.Controls.Add(pct);
                        panel1.Controls.Add(panel);
                    }
                    

                    pct.Click += new EventHandler(click_forum_picture);
                    title.Click += new EventHandler(click_forum_label);

                    //MessageBox.Show(x.ToString());
                    if (x >= 510)
                    {
                        y += 270;
                        x = 10;
                    }
                    else
                        x += 500;
                }
            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (check == true)
            {
                refresh();
                check = false;
            }
        }

        private void uc_forum_Load(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
