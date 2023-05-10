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
    public partial class assignprojects : Form
    {
        public assignprojects()
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
                comboBox2.Items.Add(ROW["Id"]).ToString();
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
                comboBox1.Items.Add(ROW["Id"]).ToString();
                //Reg.Text=ROW["Id"].ToString();
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
                    }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            manageevaluations me = new manageevaluations();
            me.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            assignadvisors aa = new assignadvisors();
            aa.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            managegroups mg = new managegroups();
            mg.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            manageadvisors ma = new manageadvisors();
            ma.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            managestudent ms = new managestudent();
            ms.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        //public Boolean isdatevalid()
        //{
        //    Boolean t;
        //    DateTime temp;
        //    if (DateTime.TryParse(textBox3.Text, out temp))
        //    {
        //        t = true;   
        //    }
        //    else
        //    {
        //        t = false;
        //    }
        //    return t;
        //}
        private void button11_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            ////@Department, @Session,@CGPA, @Address
            String gid = comboBox2.Text;
            //String des = combobox1.Text;
            // if (textBox2.Text.Length == 0 && textBox1.Text.Length != 0)


            SqlCommand cmd = new SqlCommand("delete from GroupProject where GroupId= '" + gid + "'", con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from GroupProject", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            String GID = comboBox2.Text;
            SqlCommand cmd = new SqlCommand("select * from GroupProject where GroupId= '" + GID + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully searched");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            var dat = new DateTime();
            dat = DateTime.Now;

            String d = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            String GID = comboBox2.Text;
            SqlCommand cmd = new SqlCommand("UPDATE GroupProject set ProjectId=@ProjectId, AssignmentDate=@AssignmentDate where GroupId= '" + GID + "'", con);
            //cmd.Parameters.AddWithValue("@GroupId", comboBox2.Text);
            cmd.Parameters.AddWithValue("@ProjectId", comboBox1.Text);
            cmd.Parameters.AddWithValue("@AssignmentDate", dat);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
            //SqlCommand checkId = new SqlCommand("SELECT COUNT(*) FROM GroupProject WHERE GroupId = '" + comboBox2.Text + "'", con);
            //if (checkId.ExecuteScalar() != null)
            //{
            //    int idexist = (int)checkId.ExecuteScalar();
            //    if (idexist > 0)
            //    {
            //        MessageBox.Show("Dear User,\nThis Group Id has already been assigned a project.\nTry a different Group Id to insert data or update the Project Id as per requirements.");
            //    }
            //    else
            //    {

            //    }
            //}


        }

        private void INSERT_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            var dat = new DateTime();
            dat = DateTime.Now;
            
            String d = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            //textBox3.Text = d;
            SqlCommand checkId = new SqlCommand("SELECT COUNT(*) FROM GroupProject WHERE GroupId = '" + comboBox2.Text + "'" , con);
            if (checkId.ExecuteScalar() != null)
            {
                int idexist = (int)checkId.ExecuteScalar();
                if (idexist > 0)
                {
                    MessageBox.Show("Dear User,\nThis Group Id has already been assigned a project.\nTry a different Group Id to insert data or update the Project Id as per requirements.");
                }
                else
                {
      
                    SqlCommand cmd = new SqlCommand("Insert into GroupProject values (@GroupId , @ProjectId , @AssignmentDate)", con);
                    cmd.Parameters.AddWithValue("GroupId", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@ProjectId", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@AssignmentDate", dat);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully saved");
                }
            }
            //int Exist = (int)checkId.ExecuteScalar();

            //if (Exist>0)
            //{

            //}
            //else
            //{
            //    MessageBox.Show("Group Id exists.\nTry a different Group Id to insert data.");
            //}
            //@Department, @Session,@CGPA, @Address

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    comboBox1.Text = row.Cells[0].Value.ToString();
                    comboBox2.Text = row.Cells[1].Value.ToString();
                    textBox3.Text = row.Cells[2].Value.ToString();

                    //xtCountry.Text = row.Cells[2].Value.ToString();
                }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void assignprojects_Load(object sender, EventArgs e)
        {
            combo1();
            combo2();
            var con = Configuration.getInstance().getConnection();
            var dat = new DateTime();
            dat = DateTime.Now;

            String d = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            textBox3.Text = d;
        }
    }
}
