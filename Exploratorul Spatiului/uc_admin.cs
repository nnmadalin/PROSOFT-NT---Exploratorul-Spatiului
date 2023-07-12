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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.IO;

namespace Exploratorul_Spatiului
{
    public partial class uc_admin : UserControl
    {
        public uc_admin()
        {
            InitializeComponent();
        }

        public static string statuccours = "add", statusnews = "add", titlecourse = "";
        public static int idcours = 0, iduser = 0, idnews = 0;
        public static bool status_refresh = false, status_refresh_2 = false, status_refresh_3 = false;
        string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\exsp_db.mdf;Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets=true;";

        void load_table_curs()
        {
            guna2DataGridView1.Rows.Clear();
            guna2DataGridView1.Refresh();
         
            
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"select * from cursuri", conn);
            SqlDataReader read = cmd.ExecuteReader();
            int i = 0;
            while (read.Read())
            {
                guna2DataGridView1.Rows.Insert(i, read["Id"], read["user"], read["name"], read["description"]);
                i++;
            }
            conn.Close();
            
        }

        void load_table_user()
        {
            guna2DataGridView2.Rows.Clear();
            guna2DataGridView2.DataSource = null;
            guna2DataGridView2.Refresh();

            
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"select * from [users] where email != '"+Form1.email+"'", conn);
            SqlDataReader read = cmd.ExecuteReader();
            int i = 0;
            while (read.Read())
            {
                guna2DataGridView2.Rows.Insert(i, read["id"], read["fname"], read["email"], read["rank"]);
                i++;
            }
            conn.Close();
            guna2DataGridView2.Refresh();
        }
        
        void load_table_news()
        {
            guna2DataGridView3.Rows.Clear();
            guna2DataGridView3.DataSource = null;
            guna2DataGridView3.Refresh();

            
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"select * from [news]", conn);
            SqlDataReader read = cmd.ExecuteReader();
            int i = 0;
            while (read.Read())
            {
                guna2DataGridView3.Rows.Insert(i, read["id"], read["user"], read["title"], read["url_news"], read["url_image"]);
                i++;
            }
            conn.Close();
            guna2DataGridView3.Refresh();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }
      

        private void uc_admin_Load(object sender, EventArgs e)
        {
            load_table_curs();
            load_table_user();
            load_table_news();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var send = (Guna.UI2.WinForms.Guna2DataGridView)sender;
            if (e.ColumnIndex == 4)
            {
                statuccours = "change";
                int row = e.RowIndex;
                idcours = Convert.ToInt32(send.Rows[row].Cells[0].Value.ToString());

                Form form = new admin_addcourse();
                form.Show();
            }
            else if (e.ColumnIndex == 5)
            {
                int row = e.RowIndex;
                int id = Convert.ToInt32(send.Rows[row].Cells[0].Value.ToString());

                DialogResult dr = MessageBox.Show("Esti sigur ca vrei sa stergi acest curs? (ID = " + id.ToString() + ")" , "Sterge curs", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                if (dr == DialogResult.OK)
                {

                   
                    SqlConnection conn = new SqlConnection(connstring);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"Delete from cursuri where Id = '" + id + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    status_refresh = true;
                    MessageBox.Show("Curs sters!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (e.ColumnIndex == 6)
            {
                int row = e.RowIndex;
                idcours = Convert.ToInt32(send.Rows[row].Cells[0].Value.ToString());

                Form form = new admin_addquiz();
                form.Show();
            }
            else if (e.ColumnIndex == 7)
            {
                int row = e.RowIndex;
                int id = Convert.ToInt32(send.Rows[row].Cells[0].Value.ToString());

                DialogResult dr = MessageBox.Show("Esti sigur ca vrei sa stergi acest quiz? (ID curs = " + id.ToString() + ")", "Sterge quiz", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                if (dr == DialogResult.OK)
                {
                    SqlConnection conn = new SqlConnection(connstring);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"Delete from quiz where idcurs = '" + id + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    status_refresh = true;
                    MessageBox.Show("Quiz sters!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (e.ColumnIndex == 8)
            {
                int row = e.RowIndex;
                idcours = Convert.ToInt32(send.Rows[row].Cells[0].Value.ToString());
                titlecourse = send.Rows[row].Cells[2].Value.ToString();

                Form form = new view_elev_quiz();
                form.Show();
            }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            statusnews = "add";
            Form form = new admin_addnews();
            form.Show();
        }

        private void guna2DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var send = (Guna.UI2.WinForms.Guna2DataGridView)sender;
            int row = e.RowIndex;
            if (e.ColumnIndex == 4)
            {
                statusnews = "change";
                idnews = Convert.ToInt32(send.Rows[row].Cells[0].Value.ToString());
                Form frm = new admin_addnews();
                frm.Show();
            }
            else if (e.ColumnIndex == 5)
            {
                int id = Convert.ToInt32(send.Rows[row].Cells[0].Value.ToString());

                DialogResult dr = MessageBox.Show("Esti sigur ca vrei sa stergi acesta stire? (ID stire = " + id.ToString() + ")", "Sterge quiz", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                if (dr == DialogResult.OK)
                {

                   
                    SqlConnection conn = new SqlConnection(connstring);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"Delete from news where id = '" + id + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    status_refresh_3 = true;
                    MessageBox.Show("Stire stersa!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var send = (Guna.UI2.WinForms.Guna2DataGridView)sender;
            int row = e.RowIndex;
            if (e.ColumnIndex == 4)
            {
                DialogResult dr = MessageBox.Show("Esti sigur ca vrei sa schimbi rankul pentru user = " + send.Rows[row].Cells[1].Value.ToString() + " ?", "Schimba rank", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dr == DialogResult.Yes)
                {
                    
                    SqlConnection conn = new SqlConnection(connstring);
                    conn.Open();
                    if (send.Rows[row].Cells[3].Value.ToString() == "admin")
                    {
                        SqlCommand cmd = new SqlCommand(@"update users set rank = @rank where email = @email", conn);
                        cmd.Parameters.Add("@rank", "normal");
                        cmd.Parameters.Add("@email", send.Rows[row].Cells[2].Value.ToString().Trim());
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand(@"update users set rank = @rank  where email = @email", conn);
                        cmd.Parameters.Add("@rank", "admin");
                        cmd.Parameters.Add("@email", send.Rows[row].Cells[2].Value.ToString().Trim());
                        cmd.ExecuteNonQuery();
                    }
                    
                    conn.Close();
                    MessageBox.Show("Rank user modificat!!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    status_refresh_2 = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            statuccours = "add";
            Form frm = new admin_addcourse();
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (status_refresh == true)
            {
                load_table_curs();
                status_refresh = false;
                
            }
            if (status_refresh_2 == true)
            {
                load_table_user();
                status_refresh_2 = false;
            }
            if (status_refresh_3 == true)
            {
                load_table_news();
                status_refresh_3 = false;
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
