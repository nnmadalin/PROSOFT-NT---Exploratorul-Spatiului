using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Linq;


namespace Exploratorul_Spatiului
{
    public partial class sign_in : Form
    {
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessge(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        public sign_in()
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new Form1();
            form.Show();
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessge(this.Handle, 0x112, 0xf012, 0);
        }
        string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

        SqlConnection conn;
        private void sign_in_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {

            }

        }

        public static string hash(string x)
        {
            var hash = SHA256.Create();
            byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(x));
            var sb = new StringBuilder();
            for(int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public bool check_email(string x)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(x);
        }

        string fileurl = "";
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string fname = guna2TextBox3.Text;
            string email = guna2TextBox1.Text;
            string pass = guna2TextBox2.Text;
            string pass2 = guna2TextBox4.Text;
            SqlCommand cmd;
            if (pass.Trim() != "" && pass2.Trim() != "" && email.Trim() != "" && fname.Trim() != "")
            {
                if (check_email(email) == false)
                {
                    MessageBox.Show("Email gresit!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool ch = false;
                    cmd = new SqlCommand("select * from users where email = '" + email + "'", conn);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        MessageBox.Show("Email deja existent!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ch = true;
                        break;
                    }
                    if (ch == false)
                    {
                        if (pass == pass2)
                        {
                            byte[] imageData = null;
                            if (fileurl.Trim() != "")
                            {
                                FileStream stream = new FileStream(fileurl, FileMode.Open, FileAccess.Read);
                                BinaryReader brs = new BinaryReader(stream);
                                imageData = brs.ReadBytes((int)stream.Length);
                            }
                            if (imageData != null)
                            {
                                cmd = new SqlCommand(@"insert into users (fname, email, password, rank, avatar) values (@fname, @email, @password, @rank, @avatar)", conn);
                                cmd.Parameters.AddWithValue("@fname", fname);
                                cmd.Parameters.AddWithValue("@email", email);
                                cmd.Parameters.AddWithValue("@password", hash(pass));
                                cmd.Parameters.AddWithValue("@rank", "normal");
                                cmd.Parameters.AddWithValue("@avatar", imageData);
                            }
                            else
                            {
                                cmd = new SqlCommand(@"insert into users (fname, email, password, rank) values (@fname, @email, @password, @rank)", conn);
                                cmd.Parameters.AddWithValue("@fname", fname);
                                cmd.Parameters.AddWithValue("@email", email);
                                cmd.Parameters.AddWithValue("@password", hash(pass));
                                cmd.Parameters.AddWithValue("@rank", "normal");
                            }
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Contul a fost creat cu succes!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conn.Close();
                            Form form = new Form1();
                            form.Show();
                            this.Close();
                        }
                        else
                            MessageBox.Show("Parolele nu corespund!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Completati toate casete!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif";
            DialogResult dr = openFileDialog1.ShowDialog();
            if(dr == DialogResult.OK)
            {
                fileurl = openFileDialog1.FileName.ToString();
                if(openFileDialog1.SafeFileName.Length > 20)
                {
                    label5.Text = openFileDialog1.SafeFileName.Substring(0, 20);
                    
                }
                else
                    label5.Text = openFileDialog1.SafeFileName;
            }
        }
    }
}
