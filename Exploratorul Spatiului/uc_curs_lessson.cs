using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronPdf;


namespace Exploratorul_Spatiului
{
    public partial class uc_curs_lessson : UserControl
    {
        public uc_curs_lessson()
        {
            InitializeComponent();
        }

        private void uc_curs_lessson_Load(object sender, EventArgs e)
        {
            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

            SqlConnection conn;
            conn = new SqlConnection(connstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"select * from cursuri where Id = '" + uc_curs.id.ToString() + "'", conn);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                miniHTMLTextBox1.Text = read["course"].ToString();
                textBox1.Text = read["name"].ToString();
                break;
            }

        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            home home = (home)System.Windows.Forms.Application.OpenForms["home"];
            var panel1 = (System.Windows.Forms.FlowLayoutPanel)home.Controls["flowLayoutPanel1"];
            panel1.Controls.Remove(this);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "pdf files (*.pdf)|*.pdf";
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.Title = "Save PDF";
            saveFileDialog1.FileName = "";

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                var HtmlLine = new HtmlToPdf();
                var pdf = HtmlLine.RenderHtmlAsPdf(miniHTMLTextBox1.Text);
                pdf.SaveAs(path);
                MessageBox.Show("Fisier salvat!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
