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
    public partial class manageadvisors : Form
    {
        public manageadvisors()
        {
            InitializeComponent();
            //comboBox1.SelectedIndex = -1;
        }
        //public void ab()
        //{
        //    //var con = Configuration.getInstance().getConnection();
        //    ////SqlDataReader dr;
        //    //SqlCommand cmd = con.CreateCommand();
        //    //cmd.CommandType = CommandType.Text;
        //    ////cmd.CommandText = "select Id from Lookup ";
        //    //cmd.ExecuteNonQuery();
        //    //DataTable dt = new DataTable();
        //    //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    //da.Fill(dt);
        //    //dr = null;
        //   // SqlCommand cmd = new SqlCommand("select * from Lookup", con);
            
        //  /*  while (dr.Read())
        //    {
        //        comboBox1.Text = dr["Id"].ToString();
        //    }
        //  */
        //  foreach (DataRow ROW in dt.Rows)
        //    {
        //        comboBox1.Text = ROW["Id"].ToString();
        //    }
            
        //}

        private void label2_Click(object sender, EventArgs e)
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
        private void INSERT_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            //@Department, @Session,@CGPA, @Address
            SqlCommand cmd = new SqlCommand("Insert into Advisor values (@Id , @Designation , @Salary)", con);
            cmd.Parameters.AddWithValue("Id", textBox1.Text);
            cmd.Parameters.AddWithValue("@Salary", textBox3.Text);
            int des;
            if (comboBox1.SelectedIndex == 0)
            {
                des = 6;
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                des = 7;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                des = 8;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                des = 9;
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                des = 10;
            }
            else
            {
                des = 6;
            }
            cmd.Parameters.AddWithValue("@Designation", des);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void button10_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Advisor", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
 
            dataGridView1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var con = Configuration.getInstance().getConnection();
            //SqlDataReader dr;
            //DataTable dt = new DataTable();
            //dr = null;
            //SqlCommand cmd = new SqlCommand("select * from Lookup", con);
            //cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    comboBox1.Text = dr["Id"].ToString();
            //}
            //dr.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            //@Department, @Session,@CGPA, @Address
            String ID = textBox1.Text;
            SqlCommand cmd = new SqlCommand("UPDATE Advisor set Designation=@Designation , Salary=@Salary where Id= '" + ID + "'", con);
            cmd.Parameters.AddWithValue("@Id", textBox1.Text);
            cmd.Parameters.AddWithValue("@Salary", textBox3.Text);
            int des;
            if (comboBox1.SelectedIndex == 0)
            {
                des = 6;
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                des = 7;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                des = 8;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                des = 9;
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                des = 10;
            }
            else
            {
                des = 6;
            }
            cmd.Parameters.AddWithValue("@Designation", des);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                comboBox1.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();

                //xtCountry.Text = row.Cells[2].Value.ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            String ID = textBox1.Text;
            SqlCommand cmd = new SqlCommand("select * from Advisor where Id= '" + ID + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully searched");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            ////@Department, @Session,@CGPA, @Address
            String id = textBox1.Text;
            //String des = combobox1.Text;
            // if (textBox2.Text.Length == 0 && textBox1.Text.Length != 0)


            SqlCommand cmd = new SqlCommand("delete from Advisor where Id= '" + id + "'", con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Deleted");
        }

        private void manageadvisors_Load(object sender, EventArgs e)
        {
            //ab();

            //try
            //{
                
            //    var con = Configuration.getInstance().getConnection();
            //    SqlCommand cmd = con.CreateCommand();
            //    SqlDataAdapter db = new SqlDataAdapter("Select Id from Person",con);
            //    DataTable dt = new DataTable();
            //    db.Fill(dt);
            //    foreach (DataRow ROW in dt.Rows)
            //    {
            //        comboBox1.Items.Add(ROW["Id"].ToString());
            //    }
            //}
            //catch(Exception exp)
            //{
            //    MessageBox.Show(exp.Message);
            //}
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
