using DG.MiniHTMLTextBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Exploratorul_Spatiului
{
    public partial class admin_addquiz : Form
    {
        public admin_addquiz()
        {
            InitializeComponent();
        }

        int index = 1, n = 1;
        public static string[] question = new string[10000];
        public static string[] ans1 = new string[10000];
        public static string[] ans2 = new string[10000];
        public static string[] ans3 = new string[10000];
        public static string[] ans4 = new string[10000];
        public static string[] anscorrect = new string[10000];
        
        void clear()
        {
            miniHTMLTextBox1.Text = "";
            miniHTMLTextBox2.Text = "";
            miniHTMLTextBox3.Text = "";
            miniHTMLTextBox4.Text = "";
            miniHTMLTextBox5.Text = "";

            guna2CustomCheckBox1.Checked = false;
            guna2CustomCheckBox2.Checked = false;
            guna2CustomCheckBox3.Checked = false;
            guna2CustomCheckBox4.Checked = false;
        }
        public void salvare_now()
        {
            question[index] = Convert.ToString(miniHTMLTextBox1.Text);
            ans1[index] = Convert.ToString(miniHTMLTextBox2.Text);
            ans2[index] = Convert.ToString(miniHTMLTextBox3.Text);
            ans3[index]  = Convert.ToString(miniHTMLTextBox4.Text);
            ans4[index] = Convert.ToString(miniHTMLTextBox5.Text);
            
            
            string t = "";
            if (guna2CustomCheckBox1.Checked == true)
                t += "a";
            if (guna2CustomCheckBox2.Checked == true)
                t += "b";
            if (guna2CustomCheckBox3.Checked == true)
                t += "c";
            if (guna2CustomCheckBox4.Checked == true)
                t += "d";
            anscorrect[index] = t;
        }
      
        void load_text()
        {
            label1.Text = "Intrebarea " + index;
            miniHTMLTextBox1.Text = question[index];
            miniHTMLTextBox2.Text = ans1[index];
            miniHTMLTextBox3.Text = ans2[index];
            miniHTMLTextBox4.Text = ans3[index];
            miniHTMLTextBox5.Text = ans4[index];


            guna2CustomCheckBox1.Checked = false;
            guna2CustomCheckBox2.Checked = false;
            guna2CustomCheckBox3.Checked = false;
            guna2CustomCheckBox4.Checked = false;
            if (anscorrect[index] != null)
            {
                for (int i = 0; i < anscorrect[index].Length; i++)
                {
                    if (anscorrect[index][i].ToString() == "a")
                        guna2CustomCheckBox1.Checked = true;
                    else if (anscorrect[index][i].ToString() == "b")
                        guna2CustomCheckBox2.Checked = true;
                    else if (anscorrect[index][i].ToString() == "c")
                        guna2CustomCheckBox3.Checked = true;
                    else if (anscorrect[index][i].ToString() == "d")
                        guna2CustomCheckBox4.Checked = true;
                }
            }
        }

        void delete_quiz_existent()
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

            SqlConnection conn;
            conn = new SqlConnection(connstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete from quiz where idcurs = '" + uc_admin.idcours + "'", conn);
            cmd.ExecuteNonQuery();
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            salvare_now();
            if (index < n)
            {
                index++;
                load_text();
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            salvare_now();
            if (index >= 2)
            {
                index--;
                load_text();
            }
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            salvare_now();
            n++;
            index = n;
            miniHTMLTextBox1.Text = "";
            miniHTMLTextBox2.Text = "";
            miniHTMLTextBox3.Text = "";
            miniHTMLTextBox4.Text = "";
            miniHTMLTextBox5.Text = "";
            guna2CustomCheckBox1.Checked = false;
            guna2CustomCheckBox2.Checked = false;
            guna2CustomCheckBox3.Checked = false;
            guna2CustomCheckBox4.Checked = false;
            label1.Text = "Intrebarea " + index.ToString();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Esti sigur ca vrei sa stergi intrebarea " + index.ToString() + " ?", "Sterge intrebare", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dr == DialogResult.OK && n > 1)
            {
                for(int i = index; i < n; i++)
                {
                    string a = question[i], b = ans1[i], c = ans2[i], d = ans3[i], ee = ans4[i], f = anscorrect[i];
                    question[i] = question[i + 1];
                    ans1[i] = ans1[i + 1];
                    ans2[i] = ans2[i + 1];
                    ans3[i] = ans3[i + 1];
                    ans4[i] = ans4[i + 1];
                    anscorrect[i] = anscorrect[i + 1];
                    question[i + 1] = a;
                    ans1[i + 1] = b;
                    ans2[i + 1] = c;
                    ans3[i + 1] = d;
                    ans4[i + 1] = ee;
                    anscorrect[i + 1] = f;                    
                }
                n--;
                index = 1;
                load_text();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            delete_quiz_existent();
            salvare_now();
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

            SqlConnection conn;
            conn = new SqlConnection(connstring);
            conn.Open();            
            for(int i = 1; i <= n; i++)
            {
                SqlCommand cmd = new SqlCommand(@"insert into quiz values (@idcurs, @user, @question, @answer1, @answer2, @answer3, @answer4, @correctanswer)", conn);
                cmd.Parameters.Add("@idcurs", uc_admin.idcours);
                cmd.Parameters.Add("@user", Form1.email);

                if (String.IsNullOrEmpty(question[i]))
                    cmd.Parameters.Add("@question", DBNull.Value);
                else
                    cmd.Parameters.Add("@question", question[i]);

                if (String.IsNullOrEmpty(ans1[i]))
                    cmd.Parameters.Add("@answer1", DBNull.Value);
                else
                    cmd.Parameters.Add("@answer1", ans1[i]);

                if (String.IsNullOrEmpty(ans2[i]))
                    cmd.Parameters.Add("@answer2", DBNull.Value);
                else
                    cmd.Parameters.Add("@answer2", ans2[i]);

                if (String.IsNullOrEmpty(ans3[i]))
                    cmd.Parameters.Add("@answer3", DBNull.Value);
                else
                    cmd.Parameters.Add("@answer3", ans3[i]);

                if (String.IsNullOrEmpty(ans4[i]))
                    cmd.Parameters.Add("@answer4", DBNull.Value);
                else
                    cmd.Parameters.Add("@answer4", ans4[i]);

                if (String.IsNullOrEmpty(anscorrect[i]))
                    cmd.Parameters.Add("@correctanswer", DBNull.Value);
                else
                    cmd.Parameters.Add("@correctanswer", anscorrect[i]);

                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Quiz salvat", "Salvat cu succes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            conn.Close();
            this.Close();
        }

        private void add_quiz_Load(object sender, EventArgs e)
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

            SqlConnection conn;
            conn = new SqlConnection(connstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"select * from quiz where idcurs = '"+ uc_admin.idcours + "'", conn);
            SqlDataReader read = cmd.ExecuteReader();
            bool check = false;
            while (read.Read())
            {
                question[n] = read["question"].ToString();
                ans1[n] = read["answer1"].ToString();
                ans2[n] = read["answer2"].ToString();
                ans3[n] = read["answer3"].ToString();
                ans4[n] = read["answer4"].ToString();
                anscorrect[n] = read["correctanswer"].ToString();
                n++;
                check = true;
            }
            if (check == true)
            {
                load_text();
                n--;
            }
            ///to do
            ///de adaugat elementele in vector
            ///inainte de adaugare trebuie dat delete
            ///de fct sistem quiz
            ///            
            
            conn.Close();
        }
    }
}
