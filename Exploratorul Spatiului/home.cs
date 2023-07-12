using Guna.UI2.Licensing.LightJson;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Exploratorul_Spatiului
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessge(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessge(this.Handle, 0x112, 0xf012, 0);
        }
        public class WebClientWithTimeout : WebClient
        {
            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest wr = base.GetWebRequest(address);
                WebProxy proxy = WebProxy.GetDefaultProxy();
                wr.Timeout = 500; // timeout in milliseconds (ms)
                return wr;
            }
        }

        public static string url_image_day = "", title_image_day = "", desc_image_day = "";
        public static Bitmap image_day;
        private void home_Load(object sender, EventArgs e)
        {
            if (Form1.ranks == "admin")
            {
                guna2Button6.Visible = true;
            }

            try
            {
                string newurl = @"https://api.nasa.gov/planetary/apod?api_key=RqRQAdAyacHoMqssYs8iAWqXxl7qKGErDMPkVFPL&date=" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
                WebClient webClient = new WebClientWithTimeout();
                webClient.Proxy = null;
                dynamic result = JsonValue.Parse(webClient.DownloadString(newurl));
                url_image_day = result["url"];
                title_image_day = result["title"];
                desc_image_day = result["explanation"];
            }
            catch
            {
                url_image_day = Application.StartupPath + "/Data/CrescentPoseiden_Chasiotis_1080.jpg";
                title_image_day = "Crescent Moon Beyond Greek Temple";
            }
            textBox1.Text = Form1.fullname;
            if(Form1.avatar_burt != null)
            {
                guna2CirclePictureBox1.Image = Image.FromStream(Form1.avatar);
            }

            UserControl home = new uc_home();
            flowLayoutPanel1.Controls.Add(home);
            Form form = new Form1();
            form.Hide();
        }
        void standard_color()
        {
            guna2Button1.FillColor = Color.FromArgb(16, 13, 20);
            guna2Button2.FillColor = Color.FromArgb(16, 13, 20);
            guna2Button3.FillColor = Color.FromArgb(16, 13, 20);
            guna2Button4.FillColor = Color.FromArgb(16, 13, 20);
            guna2Button5.FillColor = Color.FromArgb(16, 13, 20);
            guna2Button6.FillColor = Color.FromArgb(16, 13, 20);
            guna2Button7.FillColor = Color.FromArgb(16, 13, 20);
            guna2Button8.FillColor = Color.FromArgb(16, 13, 20);
            flowLayoutPanel1.Controls.Clear();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //42, 61, 79
            standard_color();
            guna2Button1.FillColor = Color.FromArgb(42, 61, 79);
            UserControl home = new uc_home();
            flowLayoutPanel1.Controls.Add(home);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            standard_color();
            guna2Button2.FillColor = Color.FromArgb(42, 61, 79);
            UserControl curs = new uc_curs();
            flowLayoutPanel1.Controls.Add(curs);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            standard_color();
            guna2Button3.FillColor = Color.FromArgb(42, 61, 79);
            UserControl map = new uc_planets();
            flowLayoutPanel1.Controls.Add(map);
        }


        private void guna2Button4_Click(object sender, EventArgs e)
        {
            standard_color();
            guna2Button4.FillColor = Color.FromArgb(42, 61, 79);
            UserControl map = new uc_news();
            flowLayoutPanel1.Controls.Add(map);
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            Form form = new Form1();
            form.Show();
            this.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            standard_color();
            guna2Button7.FillColor = Color.FromArgb(42, 61, 79);
            UserControl uc = new uc_cont();
            flowLayoutPanel1.Controls.Add(uc);
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "/planet_orbit.exe");
            }
            catch
            {
                MessageBox.Show("Ceva nu a mers bine", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            standard_color();
            guna2Button5.FillColor = Color.FromArgb(42, 61, 79);
            UserControl uc = new uc_forum();
            flowLayoutPanel1.Controls.Add(uc);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            standard_color();
            guna2Button6.FillColor = Color.FromArgb(42, 61, 79);
            UserControl uc = new uc_admin();
            flowLayoutPanel1.Controls.Add(uc);
        }
    }
}
