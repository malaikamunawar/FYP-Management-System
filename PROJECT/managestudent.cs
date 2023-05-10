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

namespace PROJECT
{
    public partial class managestudent : Form
    {
        public managestudent()
        {
            InitializeComponent();
        }

        public void combo()
        {
            SqlConnection con = Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select ID from Person";
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
            private void button4_Click(object sender, EventArgs e)
        {
            managegroups mg = new managegroups();
            mg.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            var con =  Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void INSERT_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            //@Department, @Session,@CGPA, @Address
            SqlCommand cmd = new SqlCommand("Insert into Student values (@Id , @RegistrationNo)", con);
            cmd.Parameters.AddWithValue("Id", comboBox1.Text);
            cmd.Parameters.AddWithValue("@RegistrationNo", textBox2.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            manageadvisors ma = new manageadvisors();
            ma.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void button8_Click(object sender, EventArgs e)
        {
            manageevaluations me = new manageevaluations();
            me.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            //@Department, @Session,@CGPA, @Address
            String ID = comboBox1.Text;
            SqlCommand cmd = new SqlCommand("UPDATE Student set RegistrationNo=@RegistrationNo where Id= '" + ID + "'", con);
           cmd.Parameters.AddWithValue("@Id", comboBox1.Text);
            cmd.Parameters.AddWithValue("@RegistrationNo", textBox2.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    comboBox1.Text = row.Cells[0].Value.ToString();
                    textBox2.Text = row.Cells[1].Value.ToString();
                    //xtCountry.Text = row.Cells[2].Value.ToString();
                }
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            ////@Department, @Session,@CGPA, @Address
            String id = comboBox1.Text;
            //String des = combobox1.Text;
            // if (textBox2.Text.Length == 0 && textBox1.Text.Length != 0)
   
            
                SqlCommand cmd = new SqlCommand("delete from Student where Id= '" + id + "'"  , con);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully deleted");
            
            //if (textBox1.Text.Length == 0 && textBox2.Text.Length != 0)
            //{
            //    SqlCommand cmd = new SqlCommand("delete from Student where RegistrationNo= '" + reg + "'", con);

            //    cmd.ExecuteNonQuery();
            //    MessageBox.Show("Successfully deleted");
            //}

        }

        private void button9_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            String ID = comboBox1.Text;
            SqlCommand cmd = new SqlCommand("select * from Student where Id= '" + ID + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully searched");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void managestudent_Load(object sender, EventArgs e)
        {
            combo();
        }
    }
}
