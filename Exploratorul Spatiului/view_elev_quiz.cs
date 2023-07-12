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
    public partial class view_elev_quiz : Form
    {
        public view_elev_quiz()
        {
            InitializeComponent();
        }

        int y = 80;

        private void uc_view_elev_quiz_Load(object sender, EventArgs e)
        {
            guna2TextBox1.Text = uc_admin.titlecourse;

            string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"select * from cursterminat where idcurs = '"+ uc_admin.idcours +"'", conn);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                var panel = new Guna2Panel()
                {
                    Size = new Size(528, 74),
                    Location = new Point(42, y),
                    BackColor = Color.Transparent,
                    BorderRadius = 20,
                    FillColor = Color.SlateBlue
                };

                var label1 = new Label();
                label1.AutoSize = true;
                label1.Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold);
                label1.ForeColor = Color.White;
                label1.Location = new Point(13, 26);
                label1.Text = read["user"].ToString();

                var label2 = new Label();
                label2.AutoSize = true;
                label2.Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold);
                label2.ForeColor = Color.White;
                label2.Location = new Point(386, 26);
                label2.Text = "Puncte: " + read["points"].ToString();

                panel.Controls.Add(label1);
                panel.Controls.Add(label2);
                this.Controls.Add(panel);

                y += 100;
            }
        }
    }
}
