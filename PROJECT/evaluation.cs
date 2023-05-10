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
    public partial class evaluation : Form
    {
        public evaluation()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void INSERT_Click(object sender, EventArgs e)
        { 
                var con = Configuration.getInstance().getConnection();
                //@Department, @Session,@CGPA, @Address

                SqlCommand cmd = new SqlCommand("Insert into Evaluation values (@Name , @TotalMarks , @TotalWeightage)", con);
                //cmd.Parameters.AddWithValue("@Id", gid.Text);
                cmd.Parameters.AddWithValue("@Name", name.Text);
                cmd.Parameters.AddWithValue("@TotalMarks", marks.Text);
                cmd.Parameters.AddWithValue("@TotalWeightage", wt.Text);
                cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Saved");

            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            //String ID = textBox1.Text;
            SqlCommand cmd = new SqlCommand("Update Evaluation set Name=@Name , TotalMarks=@TotalMarks, TotalWeightage=@TotalWeightage  where Id ='" + textBox1.Text + "'", con);
            cmd.Parameters.AddWithValue("@Name", name.Text);
            cmd.Parameters.AddWithValue("@TotalMarks", marks.Text);
            cmd.Parameters.AddWithValue("@TotalWeightage", wt.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Successfully Updated");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Evaluation", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }
        public void deletem()
        {
            var con = Configuration.getInstance().getConnection();
            String ID = textBox1.Text;
            SqlCommand cmd = new SqlCommand("delete from GroupEvaluation where EvaluationId= (Select Id from evaluation where Id ='" + ID + "')", con);


            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted");
        }
        private void button11_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            ////@Department, @Session,@CGPA, @Address

            //String des = combobox1.Text;
            // if (textBox2.Text.Length == 0 && textBox1.Text.Length != 0)


            SqlCommand cmd = new SqlCommand("delete from Evaluation where Id ='" + textBox1.Text + "'", con);
            deletem();

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                name.Text = row.Cells[1].Value.ToString();
                marks.Text = row.Cells[2].Value.ToString();
                wt.Text = row.Cells[3].Value.ToString();
                //textBox4.Text = row.Cells[3].Value.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            String ID = textBox1.Text;
            SqlCommand cmd = new SqlCommand("select * from Evaluation where Id= '" + ID + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully searched");
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
            assignprojects ap = new assignprojects();
            ap.Show();
            this.Hide();
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
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void evaluation_Load(object sender, EventArgs e)
        {
            textBox1.Text = "ID is auto assigned don't type here";
        }
    }
}
