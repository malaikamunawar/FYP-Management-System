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
    public partial class manageevaluations : Form
    {
        public manageevaluations()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
        

        public void insertge()
        {
            var con = Configuration.getInstance().getConnection();
            //@Department, @Session,@CGPA, @Address

            SqlCommand cmd = new SqlCommand("Insert into GroupEvaluation values (@GroupId , @EvaluationId , @ObtainedMarks,@EvaluationDate)", con);
            cmd.Parameters.AddWithValue("@GroupId", gid.Text);
            cmd.Parameters.AddWithValue("@EvaluationId", eid.Text);
            cmd.Parameters.AddWithValue("@ObtainedMarks", om.Text);
            cmd.Parameters.AddWithValue("@EvaluationDate", date.Text);
            cmd.ExecuteNonQuery();

        }

        //public void updateevaluation()
        //{
        //    var con = Configuration.getInstance().getConnection();
        //    SqlCommand cmd = new SqlCommand("Update Evaluaton set Name=@Name , TotalMarks=@TotalMarks, TotalWeightage=@TotalWeightage where Id = '" + eid.Text + "'", con);
        //    cmd.Parameters.AddWithValue("@Id", gid.Text);
        //    cmd.Parameters.AddWithValue("@Name", name.Text);
        //    cmd.Parameters.AddWithValue("@TotalMarks", marks.Text);
        //    cmd.Parameters.AddWithValue("@TotalWeightage", wt.Text);
        //    cmd.ExecuteNonQuery();
        //}



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
                gid.Items.Add(ROW["Id"]).ToString();
                //Reg.Text=ROW["Id"].ToString();
            }
        }
        public void combo2()
        {
            SqlConnection con = Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Id from Evaluation";
            //cmd = new SqlCommand("select Id from Person where Id = '" + comboBox1.Text + " '", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow ROW in dt.Rows)
            {
                eid.Items.Add(ROW["Id"]).ToString();
                //Reg.Text=ROW["Id"].ToString();
            }

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
            assignadvisors aa = new assignadvisors();
            aa.Show();
            this.Hide();
        }

        private void manageevaluations_Load(object sender, EventArgs e)
        {
            combo1();
            combo2();
            var con = Configuration.getInstance().getConnection();
            var dat = new DateTime();
            dat = DateTime.Now;

            String d = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            date.Text = d;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void INSERT_Click(object sender, EventArgs e)
        {
            //insertevaluation();
            insertge();
            MessageBox.Show("Successsfully Saved");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select GroupEvaluation.GroupId, Evaluation.Id as EvaluationID, Evaluation.Name,Evaluation.TotalMarks,GroupEvaluation.ObtainedMarks,Evaluation.TotalWeightage, GroupEvaluation.EvaluationDate from Evaluation Join GroupEvaluation ON Evaluation.Id = GroupEvaluation.EvaluationId", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                eid.Text = row.Cells[1].Value.ToString();
                gid.Text = row.Cells[0].Value.ToString();
                om.Text = row.Cells[4].Value.ToString();
                date.Text = row.Cells[6].Value.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Update GroupEvaluation set GroupId=@GroupId , ObtainedMarks=@ObtainedMarks , EvaluationDate=@EvaluationDate where EvaluationId = '" + eid.Text + "'", con);
            cmd.Parameters.AddWithValue("@GroupId", gid.Text);
            //cmd.Parameters.AddWithValue("@ProjectId", comboBox2.Text);
            //cmd.Parameters.AddWithValue("@AdvisorRole", );
            cmd.Parameters.AddWithValue("@ObtainedMarks", om.Text);
            cmd.Parameters.AddWithValue("@EvaluationDate", date.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully updated");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            ////@Department, @Session,@CGPA, @Address

            //String des = combobox1.Text;
            // if (textBox2.Text.Length == 0 && textBox1.Text.Length != 0)


            SqlCommand cmd = new SqlCommand("delete from GroupEvaluation where GroupId ='" + gid.Text + "'", con);
           // deletem();

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            String ID = eid.Text;
            SqlCommand cmd = new SqlCommand("select * from GroupEvaluation where Id= '" + ID + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully searched");
        }
    }
    
}
