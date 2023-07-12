using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.IO;

namespace Exploratorul_Spatiului
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessge(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public Form1()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessge(this.Handle, 0x112, 0xf012, 0);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new sign_in();
            form.Show();
            this.Hide();
        }
        /// INIT

        public static string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";
        
        SqlConnection conn;
        public static string fullname = "", email = "", ranks = "", id = "";
        public static MemoryStream avatar = null;
        public static byte[] avatar_burt;

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Baza de date nu este pornita!");
            }
        }

        private void guna2TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2Button1_Click(this, new EventArgs());
            }
        }

        public static string hash(string x)
        {
            var hash = SHA256.Create();
            byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(x));
            var sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }

       
            
        bool debug = false;


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (debug == true)
            {
                fullname = "DEBUG";
                ranks = "admin";
                email = "degub@debug.com";
                conn.Close();
                Form form = new home();
                form.Show();
                this.Hide();
            }
            else
            {
                try
                {


                    string _email = guna2TextBox1.Text;
                    string pass = guna2TextBox2.Text;
                    pass = hash(pass);

                    SqlCommand cmd = new SqlCommand(@"select * from users where email = '" + _email + "' and password = '" + pass + "'", conn);
                    SqlDataReader read = cmd.ExecuteReader();
                    bool ch = false;
                    while (read.Read())
                    {
                        ch = true;
                        email = read["email"].ToString();
                        fullname = read["fname"].ToString();
                        ranks = read["rank"].ToString();
                        id = read["id"].ToString();
                        byte[] img = null;
                        if (read["avatar"] != DBNull.Value)
                        {
                            img = (byte[])(read["avatar"]);
                            avatar_burt = (byte[])(read["avatar"]);
                            avatar = new MemoryStream(img);
                        }
                        break;
                    }

                    if (ch == false)
                    {
                        MessageBox.Show("Parola si/sau email gresit", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        guna2TextBox2.Text = "";
                    }
                    else
                    {
                        conn.Close();
                        Form form = new home();
                        form.Show();
                        this.Hide();
                    }
                }
                catch (Exception)
                {
                    ; ;
                }
            }
        }
    }
}
