using Guna.UI2.WinForms;
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
    public partial class uc_news : UserControl
    {
        public uc_news()
        {
            InitializeComponent();
        }

        int x = 40, y = 40;

        void openurl(object sender, EventArgs e)
        {
            var pct = sender as Guna2PictureBox;
            try
            {
                System.Diagnostics.Process.Start(pct.Tag.ToString());
            }
            catch {
                MessageBox.Show("Link invalid", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uc_news_Load(object sender, EventArgs e)
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"select * from [news]", conn);
            SqlDataReader read = cmd.ExecuteReader();
            int i = 0;
            while (read.Read())
            {
                Guna.UI2.WinForms.Guna2Panel panel = new Guna.UI2.WinForms.Guna2Panel()
                {
                    BorderRadius = 10,
                    Size = new Size(274, 280),
                    Location = new Point(x, y)
                };
                string id = read["id"].ToString();
                int iq = Convert.ToInt32(id) % 10 + 1;
                Guna.UI2.WinForms.Guna2PictureBox pct = new Guna2PictureBox()
                {                    
                    InitialImage = Image.FromFile(Application.StartupPath + @"/Data/img_unsplash_course/" + iq.ToString() + ".jpg"),
                    ErrorImage = Image.FromFile(Application.StartupPath + @"/Data/img_unsplash_course/" + iq.ToString() + ".jpg"),
                    BorderRadius = 10,
                    Location = new Point(0, 0),
                    Size = new Size(274, 280),
                    Tag = read["url_news"].ToString(),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                try
                {
                    pct.ImageLocation = read["url_image"].ToString();
                }
                catch(Exception ex)
                {
                    pct.ImageLocation = Application.StartupPath + @"/Data/img_unsplash_course/" + iq.ToString() + ".jpg";
                }

                //MessageBox.Show(Application.StartupPath + @"/Data/img_unsplash_course/" + iq.ToString() + ".jpg");
                var label = new Label()
                {
                    Text = read["title"].ToString(),
                    MaximumSize = new Size(250, 0),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.None,
                    Parent = pct,
                    BackColor = Color.Transparent,
                    Font = new Font("Segoe UI Semibold", 17, FontStyle.Bold),
                    ForeColor = Color.White
                };
                label.Location = new Point(pct.Width / 2 - label.Width / 2, pct.Height / 2 - label.Height / 2);

                pct.Controls.Add(label);
                panel.Controls.Add(pct);
                panel1.Controls.Add(panel);

                pct.Click += new EventHandler(openurl);

                if (x >= 610)
                {
                    x = 40;
                    y += 300;
                }
                else
                    x += 333;

                i++;
            }
            conn.Close();
        }
    }
}
