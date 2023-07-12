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
using Guna.UI2.WinForms;

namespace Exploratorul_Spatiului
{
    public partial class uc_curs_quiz : UserControl
    {
        public uc_curs_quiz()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            home home = (home)Application.OpenForms["home"];
            var panel1 = (System.Windows.Forms.FlowLayoutPanel)home.Controls["flowLayoutPanel1"];
            panel1.Controls.Remove(this);
        }

        int index = 1, nmax = 0;
        double point = 0, perquestion = 0;
        public static string[] question = new string[10000];
        public static string[] ans1 = new string[10000];
        public static string[] ans2 = new string[10000];
        public static string[] ans3 = new string[10000];
        public static string[] ans4 = new string[10000];

        void load_text()
        {
            label4.Text = "Intrebari ramase: " + (nmax - index).ToString();
            

            
            guna2ProgressBar1.Value = index;
            label1.Text = "Puncte: " + Convert.ToInt32(point);
            guna2HtmlLabel1.Text = question[index];

            if (ans1[index] != "")
                guna2HtmlLabel2.Text = ans1[index];
            else
            {
                guna2HtmlLabel2.Visible = false;
                guna2CheckBox1.Visible = false;
            }

            if (ans2[index] != "")
                guna2HtmlLabel3.Text = ans2[index];
            else
            {
                guna2HtmlLabel3.Visible = false;
                guna2CheckBox2.Visible = false;
            }

            if (ans3[index] != "")
                guna2HtmlLabel4.Text = ans3[index];
            else
            {
                guna2HtmlLabel4.Visible = false;
                guna2CheckBox3.Visible = false;
            }

            if (ans4[index] != "")
                guna2HtmlLabel5.Text = ans4[index];
            else
            {
                guna2HtmlLabel5.Visible = false;
                guna2CheckBox4.Visible = false;
            }
        }
        void clear()
        {
            guna2CheckBox1.Visible = true;
            guna2CheckBox2.Visible = true;
            guna2CheckBox3.Visible = true;
            guna2CheckBox4.Visible = true;

            guna2CheckBox1.Checked = false;
            guna2CheckBox2.Checked = false;
            guna2CheckBox3.Checked = false;
            guna2CheckBox4.Checked = false;

            guna2CheckBox1.Enabled = true;
            guna2CheckBox2.Enabled = true;
            guna2CheckBox3.Enabled = true;
            guna2CheckBox4.Enabled = true;

            guna2HtmlLabel2.Enabled = true;
            guna2HtmlLabel3.Enabled = true;
            guna2HtmlLabel4.Enabled = true;
            guna2HtmlLabel5.Enabled = true;

            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel5.BackColor = Color.Transparent;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ///red = DarkRed
            ///green = SeaGreen

            bool a = false, b = false, c = false, d = false;
            if (anscorrect[index] != null)
            {
                for (int i = 0; i < anscorrect[index].Length; i++)
                {
                    if (anscorrect[index][i].ToString() == "a")
                        a = true;
                    else if (anscorrect[index][i].ToString() == "b")
                        b = true;
                    else if (anscorrect[index][i].ToString() == "c")
                        c = true;
                    else if (anscorrect[index][i].ToString() == "d")
                        d = true;
                }
            }

            if (guna2Button3.Text == "Validare")
            {
                guna2Button3.Text = "Next";
                bool verf = true;
                guna2CheckBox1.Enabled = false;
                guna2CheckBox2.Enabled = false;
                guna2CheckBox3.Enabled = false;
                guna2CheckBox4.Enabled = false;
                if (guna2CheckBox1.Visible == true)
                {
                    if(guna2CheckBox1.Checked == true && a == true)
                    {
                        guna2HtmlLabel2.BackColor = Color.SeaGreen;
                    }
                    else if (guna2CheckBox1.Checked == true && a == false)
                    {
                        guna2HtmlLabel2.BackColor = Color.DarkRed;
                        verf = false;
                    }
                    else if (guna2CheckBox1.Checked == false && a == true)
                    {
                        guna2HtmlLabel2.BackColor = Color.SeaGreen;
                        verf = false;
                    }
                }
                if (guna2CheckBox2.Visible == true)
                {
                    if (guna2CheckBox2.Checked == true && b == true)
                    {
                        guna2HtmlLabel3.BackColor = Color.SeaGreen;
                    }
                    else if (guna2CheckBox2.Checked == true && b == false)
                    {
                        guna2HtmlLabel3.BackColor = Color.DarkRed;
                        verf = false;
                    }
                    else if (guna2CheckBox2.Checked == false && b == true)
                    {
                        guna2HtmlLabel3.BackColor = Color.SeaGreen;
                        verf = false;
                    }
                }
                if (guna2CheckBox3.Visible == true)
                {
                    if (guna2CheckBox3.Checked == true && c == true)
                    {
                        guna2HtmlLabel4.BackColor = Color.SeaGreen;
                    }
                    else if (guna2CheckBox3.Checked == true && c == false)
                    {
                        guna2HtmlLabel4.BackColor = Color.DarkRed;
                        verf = false;
                    }
                    else if (guna2CheckBox3.Checked == false && c == true)
                    {
                        guna2HtmlLabel4.BackColor = Color.SeaGreen;
                        verf = false;
                    }
                }
                if (guna2CheckBox4.Visible == true)
                {
                    if (guna2CheckBox4.Checked == true && d == true)
                    {
                        guna2HtmlLabel5.BackColor = Color.SeaGreen;
                    }
                    else if (guna2CheckBox4.Checked == true && d == false)
                    {
                        guna2HtmlLabel5.BackColor = Color.DarkRed;
                        verf = false;
                    }
                    else if (guna2CheckBox4.Checked == false && d == true)
                    {
                        guna2HtmlLabel5.BackColor = Color.SeaGreen;
                        verf = false;
                    }
                }
                if(verf == true)
                {
                    point += perquestion;
                    label1.Text = "Puncte: " + Convert.ToInt32(point);
                }
            }
            else
            {
                guna2Button3.Text = "Validare";
                clear();
                if (index == nmax)
                {
                    label4.Visible = false;
                    label1.Visible = false;
                    guna2ProgressBar1.Visible = false;
                    guna2HtmlLabel1.Visible = false;
                    guna2CheckBox1.Visible = false;
                    guna2CheckBox2.Visible = false;
                    guna2CheckBox3.Visible = false;
                    guna2CheckBox4.Visible = false;
                    guna2HtmlLabel2.Visible = false;
                    guna2HtmlLabel3.Visible = false;
                    guna2HtmlLabel4.Visible = false;
                    guna2HtmlLabel5.Visible = false;
                    guna2Button3.Visible = false;

                    textBox3.Visible = true;
                    textBox4.Text += point;
                    textBox4.Text += " puncte.";
                    textBox4.Visible = true;

                    string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

                    SqlConnection conn = new SqlConnection(connstring);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"insert into cursterminat values (@idcurs, @user, @point)", conn);
                    cmd.Parameters.Add("@idcurs", uc_curs.id);
                    cmd.Parameters.Add("@user", Form1.email);
                    cmd.Parameters.Add("@point", point);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                else
                {
                    index++;
                    load_text();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public static string[] anscorrect = new string[10000];

        private void uc_curs_quiz_Load(object sender, EventArgs e)
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"select * from quiz where idcurs = '" + uc_curs.id + "'", conn);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                nmax++;
                question[nmax] = read["question"].ToString();
                ans1[nmax] = read["answer1"].ToString();
                ans2[nmax] = read["answer2"].ToString();
                ans3[nmax] = read["answer3"].ToString();
                ans4[nmax] = read["answer4"].ToString();
                anscorrect[nmax] = read["correctanswer"].ToString();
            }

            cmd = new SqlCommand(@"select * from cursuri where Id = '" + uc_curs.id + "'", conn);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                textBox2.Text = read["name"].ToString();
                label2.Text = "Adaugat de: " + read["user"];
            }


            cmd = new SqlCommand(@"select * from cursterminat where idcurs = '" + uc_curs.id + "'", conn);
            read = cmd.ExecuteReader();
            int maxim = 0;
            while (read.Read())
            {
                if (read["user"].ToString() == Form1.email)
                    maxim = Math.Max(maxim, Convert.ToInt32(read["points"].ToString()));
            }
            label3.Text = "Punctaj maxim obtinut: " + maxim.ToString();
            conn.Close();
            guna2ProgressBar1.Maximum = nmax;
            perquestion = 100.00 / Convert.ToDouble(nmax);
            load_text();
        }
    }
}
