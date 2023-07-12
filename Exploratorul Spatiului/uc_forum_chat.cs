using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exploratorul_Spatiului
{
    public partial class uc_forum_chat : UserControl
    {

        bool close = false;
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        public uc_forum_chat()
        {
            InitializeComponent();

            
            CancellationToken token = tokenSource.Token;
            

            Task t1 = Task.Factory.StartNew(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

                    SqlConnection conn;
                    conn = new SqlConnection(connstring);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"select * from chat where idforum = '" + uc_forum.id + "'", conn);
                    var read = cmd.ExecuteReader();

                    while (read.Read())
                    {
                        //MessageBox.Show("data");

                        if (Convert.ToInt32(read["id"].ToString()) > nmax)
                        {
                            //Console.WriteLine(read["id"].ToString() + " - " + nmax.ToString());
                            nmax = Math.Max(nmax, Convert.ToInt32(read["id"].ToString()));
                            Byte[] avatar = null;

                            Guna2CirclePictureBox pct = new Guna2CirclePictureBox();
                            pct.Location = new Point(x, y);
                            pct.Size = new Size(45, 45);
                            pct.SizeMode = PictureBoxSizeMode.StretchImage;

                            if (read["avatar"] != DBNull.Value)
                            {
                                avatar = (byte[])(read["avatar"]);
                                MemoryStream ms = new MemoryStream(avatar);
                                if (ms != null)
                                    pct.Image = Image.FromStream(ms);
                            }
                            if (InvokeRequired)
                            {
                                this.Invoke(new MethodInvoker(delegate
                                {
                                    flowLayoutPanel1.Controls.Add(pct);
                                }));
                            }
                            else
                            {
                                this.Invoke(new MethodInvoker(delegate
                                {
                                    flowLayoutPanel1.Controls.Add(pct);
                                }));
                            }

                            x = 66;
                            y += 50;

                            Label label = new Label();
                            label.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                            label.Text = read["user"].ToString();
                            label.ForeColor = Color.White;
                            label.Location = new Point(x, y);
                            label.Margin = new System.Windows.Forms.Padding(10, 15, 0, 0);
                            if (InvokeRequired)
                            {
                                this.Invoke(new MethodInvoker(delegate
                                {
                                    flowLayoutPanel1.Controls.Add(label);
                                    flowLayoutPanel1.SetFlowBreak(label, true);
                                }));
                            }
                            else
                            {
                                flowLayoutPanel1.Controls.Add(label);
                                flowLayoutPanel1.SetFlowBreak(label, true);
                            }
                            y += 0;

                            Label tx = new Label()
                            {
                                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                                BackColor = Color.FromArgb(79, 76, 83),
                                Text = read["text"].ToString(),
                                Location = new Point(x, y),
                                BorderStyle = BorderStyle.None,
                                ForeColor = Color.White,
                                Margin = new System.Windows.Forms.Padding(20, 0, 0, 0),
                                MaximumSize = new Size(800, 0),
                                AutoSize = true
                            };
                            if (InvokeRequired)
                            {
                                this.Invoke(new MethodInvoker(delegate
                                {
                                    flowLayoutPanel1.Controls.Add(tx);
                                    y += (tx.Height + 20);
                                    x = 15;
                                    flowLayoutPanel1.SetFlowBreak(tx, true);
                                    flowLayoutPanel1.ScrollControlIntoView(tx);
                                }));
                            }
                            else
                            {
                                flowLayoutPanel1.Controls.Add(tx);
                                y += (tx.Height + 20);
                                x = 15;
                                flowLayoutPanel1.SetFlowBreak(tx, true);
                                flowLayoutPanel1.ScrollControlIntoView(tx);
                            }
                        }

                    }
                    conn.Close();
                }
            }, token);

        }

        void load_one()
        {

            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

            SqlConnection conn;
            conn = new SqlConnection(connstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"select * from chat where idforum = '" + uc_forum.id + "'", conn);
            var read = cmd.ExecuteReader();

            while (read.Read())
            {
                //MessageBox.Show("data");

                if (Convert.ToInt32(read["id"].ToString()) > nmax)
                {
                    //Console.WriteLine(read["id"].ToString() + " - " + nmax.ToString());
                    nmax = Math.Max(nmax, Convert.ToInt32(read["id"].ToString()));
                    Byte[] avatar = null;

                    Guna2CirclePictureBox pct = new Guna2CirclePictureBox();
                    pct.Location = new Point(x, y);
                    pct.Size = new Size(45, 45);
                    pct.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (read["avatar"] != DBNull.Value)
                    {
                        avatar = (byte[])(read["avatar"]);
                        MemoryStream ms = new MemoryStream(avatar);
                        if (ms != null)
                            pct.Image = Image.FromStream(ms);
                    }
                    

                    x = 66;
                    y += 50;

                    Label label = new Label();
                    label.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                    label.Text = read["user"].ToString();
                    label.ForeColor = Color.White;
                    label.Location = new Point(x, y);
                    label.Margin = new System.Windows.Forms.Padding(10, 15, 0, 0);
                    if (InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            flowLayoutPanel1.Controls.Add(label);
                            flowLayoutPanel1.SetFlowBreak(label, true);
                        }));
                    }
                    else
                    {
                        flowLayoutPanel1.Controls.Add(label);
                        flowLayoutPanel1.SetFlowBreak(label, true);
                    }
                    y += 0;

                    Label tx = new Label()
                    {
                        Font = new Font("Segoe UI", 10, FontStyle.Regular),
                        BackColor = Color.FromArgb(79, 76, 83),
                        Text = read["text"].ToString(),
                        Location = new Point(x, y),
                        BorderStyle = BorderStyle.None,
                        ForeColor = Color.White,
                        Margin = new System.Windows.Forms.Padding(20, 0, 0, 0),
                        MaximumSize = new Size(800, 0),
                        AutoSize = true
                    };
                    
                }

            }
            conn.Close();
        }

        int x = 15, y = 26;
        public static int nmax = 0;

        private async void guna2CircleButton1_Click(object sender, EventArgs e)
        {

            await Task.Run(() =>
            {
                
                string text = guna2TextBox1.Text;
                text = text.Replace("ă", "a");
                text = text.Replace("â", "a");
                text = text.Replace("Ă", "A");
                text = text.Replace("Â", "A");
                text = text.Replace("î", "i");
                text = text.Replace("Î", "I");
                text = text.Replace("ș", "s");
                text = text.Replace("Ș", "S");
                text = text.Replace("Ț", "T");
                text = text.Replace("ț", "t");
                if (text.Trim() != "")
                {
                    string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

                    SqlConnection conn;
                    conn = new SqlConnection(connstring);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"insert into chat values (@idforum, @user, @avatar, @text)", conn);
                    cmd.Parameters.Add("@idforum", uc_forum.id);
                    cmd.Parameters.Add("@user", Form1.fullname);
                    if (Form1.avatar_burt != null)
                        cmd.Parameters.Add("@avatar", Form1.avatar_burt);
                    else
                        cmd.Parameters.Add("@avatar", SqlDbType.VarBinary).Value = DBNull.Value;
                    cmd.Parameters.Add("@text", text);
                    if (InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            cmd.ExecuteNonQuery();
                            guna2TextBox1.Text = "";
                        }));
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        guna2TextBox1.Text = "";
                    }
                    conn.Close();

                }
            });
        }

        private void uc_form_chat_Enter(object sender, EventArgs e)
        {

        }

        private async  void guna2Button2_Click(object sender, EventArgs e)
        {
            home home = (home)Application.OpenForms["home"];
            var panel1 = (System.Windows.Forms.FlowLayoutPanel)home.Controls["flowLayoutPanel1"];
            tokenSource.Cancel();
            nmax = 0;
            
            panel1.Controls.Remove(this);
            
        }
        bool ok = false;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2CircleButton1_Click(this, new EventArgs());
            }
        }

        private void uc_form_chat_Load(object sender, EventArgs e)
        {
            nmax = 0;
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

            SqlConnection conn;
            conn = new SqlConnection(connstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"select title from forum where id = '"+ uc_forum.id+"'", conn);
            SqlDataReader read =  cmd.ExecuteReader();
            while (read.Read())
            {
                textBox1.Text = read["title"].ToString();
            }
            conn.Close();

            //load_one();
        }
    }
}
