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
    public partial class managegroups : Form
    {
        public managegroups()
        {
            InitializeComponent();
        }
        public void combo1()
        {
            SqlConnection con = Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ("Select Id from [Group]");
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
            cmd.CommandText = "Select ID from Student";
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
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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

        private void button5_Click(object sender, EventArgs e)
        {
            assignprojects ap = new assignprojects();
            ap.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            assignadvisors aa = new assignadvisors();
            aa.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            manageevaluations me = new manageevaluations();
            me.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
     
        private void INSERT_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            //@Department, @Session,@CGPA, @Address

            SqlCommand checkId = new SqlCommand("SELECT COUNT(*) FROM GroupStudent WHERE StudentId = '" + comboBox2.Text + "'", con);
            if (checkId.ExecuteScalar() != null)
            {
                int idexist = (int)checkId.ExecuteScalar();
                if (idexist > 0)
                {
                    MessageBox.Show("Dear User,\nThis Student Id has already been assigned a Group.");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Insert into GroupStudent values (@GroupId , @StudentId , @Status , @AssignmentDate)", con);
                    cmd.Parameters.AddWithValue("@GroupId", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@StudentId", comboBox2.Text);
                    int s;
                    if (comboBox3.Text == "Active" || comboBox3.Text == "3")
                    {
                        s = 3;
                    }
                    else if (comboBox3.Text == "Inactive" || comboBox3.Text == "4")
                    {
                        s = 4;
                    }
                    else
                    {
                        s = 3;
                    }
                    cmd.Parameters.AddWithValue("@Status", s);
                    cmd.Parameters.AddWithValue("@AssignmentDate", textBox4.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully saved");
                }
            }

            
        }

        private void managegroups_Load(object sender, EventArgs e)
        {
            combo1();
            combo2();
            var con = Configuration.getInstance().getConnection();
            var dat = new DateTime();
            dat = DateTime.Now;

            String d = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            textBox4.Text = d;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from GroupStudent", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            //@Department, @Session,@CGPA, @Address
            SqlCommand checkId = new SqlCommand("SELECT COUNT(*) FROM GroupProject WHERE GroupId = '" + comboBox2.Text + "'", con);
            if (checkId.ExecuteScalar() != null)
            {
                int idexist = (int)checkId.ExecuteScalar();
                if (idexist > 0)
                {
                    MessageBox.Show("Dear User,\nThis Student Id has already been assigned a Group.");
                }
                else
                {
                    String ID = comboBox2.Text;
                    SqlCommand cmd = new SqlCommand("UPDATE GroupStudent set GroupId=@GroupId , Status =@Status, AssignmentDate=@AssignmentDate where StudentId = '" + ID + "'", con);
                    cmd.Parameters.AddWithValue("@GroupId", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@StudentId", comboBox2.Text);
                    int s;
                    if (comboBox3.Text == "Active" || comboBox3.Text == "3")
                    {
                        s = 3;
                    }
                    else if (comboBox3.Text == "Inactive" || comboBox3.Text == "4")
                    {
                        s = 4;
                    }
                    else
                    {
                        s = 3;
                    }
                    cmd.Parameters.AddWithValue("@Status", s);
                    cmd.Parameters.AddWithValue("@AssignmentDate", textBox4.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully Updated");
                }
            }

            
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

                //xtCountry.Text = row.Cells[2].Value.ToString();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            ////@Department, @Session,@CGPA, @Address
            String id = comboBox2.Text;
            //String des = combobox1.Text;
            // if (textBox2.Text.Length == 0 && textBox1.Text.Length != 0)


            SqlCommand cmd = new SqlCommand("delete from GroupStudent where StudentId= '" + id + "'", con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Deleted");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            String SID = comboBox2.Text;
            String GID = comboBox1.Text;
            SqlCommand cmd = new SqlCommand("select * from GroupStudent where GroupId= '" + GID + "' And StudentId= '" + SID + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully searched");
        }
    }
}
