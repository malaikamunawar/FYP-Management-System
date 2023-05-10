using PROJECT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace PROJECT
{
    public partial class assignadvisors : Form
    {
        public assignadvisors()
        {
            InitializeComponent();
        }
        public void combo1()
        {
            SqlConnection con = Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ("Select Id from Advisor");
            //cmd = new SqlCommand("select Id from Person where Id = '" + comboBox1.Text + " '", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow ROW in dt.Rows)
            {
                comboBox1.Items.Add(ROW["Id"]).ToString();
                //Reg.Text=ROW["Id"].ToString();
            }
        }
        public void combo2()
        {
            SqlConnection con = Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select ID from Project";
            //cmd = new SqlCommand("select Id from Person where Id = '" + comboBox1.Text + " '", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow ROW in dt.Rows)
            {
                comboBox2.Items.Add(ROW["Id"]).ToString();
                //Reg.Text=ROW["Id"].ToString();
            }

        }
        private void button8_Click(object sender, EventArgs e)
        {
            manageevaluations me = new manageevaluations();
            me.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            managestudent ms = new managestudent();
            ms.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            manageadvisors ma = new manageadvisors();
            ma.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            managegroups mg = new managegroups();
            mg.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            assignprojects ap = new assignprojects();
            ap.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from ProjectAdvisor", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void assignadvisors_Load(object sender, EventArgs e)
        {
            combo1();
            combo2();
            var con = Configuration.getInstance().getConnection();
            var dat = new DateTime();
            dat = DateTime.Now;

            String d = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            textBox4.Text = d;
        }

        private void INSERT_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            //@Department, @Session,@CGPA, @Address

            SqlCommand checkId = new SqlCommand("SELECT COUNT(*) FROM ProjectAdvisor WHERE ProjectId = '" + comboBox2.Text + "'", con);
            if (checkId.ExecuteScalar() != null)
            {
                int idexist = (int)checkId.ExecuteScalar();
                if (idexist > 0)
                {
                    MessageBox.Show("Dear User,\nThis Project Id has already been assigned an Advisor.");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Insert into ProjectAdvisor values (@AdvisorId , @ProjectId , @AdvisorRole , @AssignmentDate)", con);
                    cmd.Parameters.AddWithValue("@AdvisorId", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@ProjectId", comboBox2.Text);
                    int ar;
                    if (comboBox3.SelectedIndex == 0)
                    {
                        ar = 11;
                    }
                    else if (comboBox3.SelectedIndex == 1)
                    {
                        ar = 12;
                    }
                    else if (comboBox3.SelectedIndex == 2)
                    {
                        ar = 14;
                    }
                    else
                    {
                        ar = 11;
                    }
                    cmd.Parameters.AddWithValue("@AdvisorRole", ar);
                    cmd.Parameters.AddWithValue("@AssignmentDate", textBox4.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Saved");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();

            SqlCommand checkId = new SqlCommand("SELECT COUNT(*) FROM ProjectAdvisor WHERE ProjectId = '" + comboBox2.Text + "'", con);
            if (checkId.ExecuteScalar() != null)
            {
                int idexist = (int)checkId.ExecuteScalar();
                if (idexist > 1)
                {
                    MessageBox.Show("dear user,\nan advisor id has already been assigned to this project id.");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Update ProjectAdvisor set AdvisorId=@AdvisorId , AdvisorRole=@AdvisorRole , AssignmentDate=@AssignmentDate where ProjectId = '" + comboBox2.Text + "'", con);
                    cmd.Parameters.AddWithValue("@AdvisorId", comboBox1.Text);
                    //cmd.Parameters.AddWithValue("@ProjectId", comboBox2.Text);
                    //cmd.Parameters.AddWithValue("@AdvisorRole", );
                    int ar;
                    if (comboBox3.SelectedIndex == 0)
                    {
                        ar = 11;
                    }
                    else if (comboBox3.SelectedIndex == 1)
                    {
                        ar = 12;
                    }
                    else if (comboBox3.SelectedIndex == 2)
                    {
                        ar = 14;
                    }
                    else
                    {
                        ar = 11;
                    }
                    cmd.Parameters.AddWithValue("@AdvisorRole", ar);
                    cmd.Parameters.AddWithValue("@AssignmentDate", textBox4.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully updated");
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
                var con = Configuration.getInstance().getConnection();
                String PID = comboBox2.Text;
                SqlCommand cmd = new SqlCommand("select * from ProjectAdvisor where ProjectId= '" + PID + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully searched");
            //}
            //else if (comboBox2.Text == null)
            //{
            //    var con = Configuration.getInstance().getConnection();
            //    String AID = comboBox1.Text;
            //    SqlCommand cmd = new SqlCommand("select * from ProjectAdvisor where AdvisorId= '" + AID + "'", con);
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);
            //    dataGridView1.DataSource = dt;

            //    cmd.ExecuteNonQuery();
            //    MessageBox.Show("Successfully searched");
            //}
            //else
            //{
            //    var con = Configuration.getInstance().getConnection();
            //    String PID = comboBox2.Text;
            //    SqlCommand cmd = new SqlCommand("select * from ProjectAdvisor where AdvisorId= '" + PID + "'", con);
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);
            //    dataGridView1.DataSource = dt;

            //    cmd.ExecuteNonQuery();
            //    MessageBox.Show("Successfully searched");
            //}


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                comboBox1.Text = row.Cells[0].Value.ToString();
                comboBox2.Text = row.Cells[1].Value.ToString();
                comboBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            ////@Department, @Session,@CGPA, @Address
            String aid = comboBox1.Text;
            //String des = combobox1.Text;
            // if (textBox2.Text.Length == 0 && textBox1.Text.Length != 0)


            SqlCommand cmd = new SqlCommand("delete from ProjectAdvisor where AdvisorId= '" + aid + "'", con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
