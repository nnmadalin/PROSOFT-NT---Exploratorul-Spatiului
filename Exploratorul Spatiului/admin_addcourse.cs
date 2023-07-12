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
    public partial class admin_addcourse : Form
    {
        public admin_addcourse()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string titlu = textBox2.Text;
            titlu = titlu.Replace("ă", "a");
            titlu = titlu.Replace("â", "a");
            titlu = titlu.Replace("Ă", "A");
            titlu = titlu.Replace("Â", "A");
            titlu = titlu.Replace("î", "i");
            titlu = titlu.Replace("Î", "I");
            titlu = titlu.Replace("ș", "s");
            titlu = titlu.Replace("Ș", "S");
            titlu = titlu.Replace("Ț", "T");
            titlu = titlu.Replace("ț", "t");
            string descriere = textBox3.Text;
            descriere = descriere.Replace("ă", "a");
            descriere = descriere.Replace("â", "a");
            descriere = descriere.Replace("Ă", "A");
            descriere = descriere.Replace("Â", "A");
            descriere = descriere.Replace("î", "i");
            descriere = descriere.Replace("Î", "I");
            descriere = descriere.Replace("ș", "s");
            descriere = descriere.Replace("Ș", "S");
            descriere = descriere.Replace("Ț", "T");
            descriere = descriere.Replace("ț", "t");
            string content = miniHTMLTextBox1.Text;
            content = content.Replace("ă", "a");
            content = content.Replace("â", "a");
            content = content.Replace("Ă", "A");
            content = content.Replace("Â", "A");
            content = content.Replace("î", "i");
            content = content.Replace("Î", "I");
            content = content.Replace("ș", "s");
            content = content.Replace("Ș", "S");
            content = content.Replace("Ț", "T");
            content = content.Replace("ț", "t");

            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

            SqlConnection conn;
            conn = new SqlConnection(connstring);
            conn.Open();
            if (uc_admin.statuccours == "add")
            {
                SqlCommand cmd = new SqlCommand(@"insert into cursuri values (@user, @titlu, @descriere, @curs)", conn);
                cmd.Parameters.Add("@user", Form1.email);

                if (String.IsNullOrEmpty(titlu))
                    cmd.Parameters.Add("@titlu", DBNull.Value);
                else
                    cmd.Parameters.Add("@titlu", titlu);

                if (String.IsNullOrEmpty(descriere))
                    cmd.Parameters.Add("@descriere", DBNull.Value);
                else
                    cmd.Parameters.Add("@descriere", descriere);
                
                if(String.IsNullOrEmpty(content))
                    cmd.Parameters.Add("@curs", DBNull.Value);
                else
                    cmd.Parameters.Add("@curs", content);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Curs adaugat!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE cursuri SET  name = @titlu, description = @descriere,course = @curs WHERE Id = '"+ uc_admin.idcours.ToString() + "'", conn);
                //cmd.Parameters.Add("@user", Form1.email);
                if (String.IsNullOrEmpty(titlu))
                    cmd.Parameters.Add("@titlu", DBNull.Value);
                else
                    cmd.Parameters.Add("@titlu", titlu);

                if (String.IsNullOrEmpty(descriere))
                    cmd.Parameters.Add("@descriere", DBNull.Value);
                else
                    cmd.Parameters.Add("@descriere", descriere);

                if (String.IsNullOrEmpty(content))
                    cmd.Parameters.Add("@curs", DBNull.Value);
                else
                    cmd.Parameters.Add("@curs", content);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Curs Modificat!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            conn.Close();
            uc_admin.status_refresh = true;
            this.Close();
        }

        private void admin_addcourse_Load(object sender, EventArgs e)
        {
            if(uc_admin.statuccours == "change")
            {
                textBox1.Text = "Modifica curs";
                this.Text = "Modifica curs";
                guna2Button1.Text = "Modifica curs";
                //uc_admin.idcours.ToString()
                string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

                SqlConnection conn;
                conn = new SqlConnection(connstring);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from cursuri where Id = '"+ uc_admin.idcours.ToString() + "'", conn);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    textBox2.Text = read["name"].ToString();
                    textBox3.Text = read["description"].ToString();
                    miniHTMLTextBox1.Text = read["course"].ToString();
                }

                conn.Close();
            }
        }

        private void miniHTMLTextBox1_Load(object sender, EventArgs e)
        {

        }
    }
}
