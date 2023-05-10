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
    public partial class group : Form
    {
        public group()
        {
            InitializeComponent();
        }

        private void group_Load(object sender, EventArgs e)
        {
            textBox1.Text = "ID is auto assigned don't type here";
            var con = Configuration.getInstance().getConnection();
            var dat = new DateTime();
            dat = DateTime.Now;

            String d = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            textBox2.Text = d;
        }
        public void deletee()
        {
            var con = Configuration.getInstance().getConnection();
            String ID = textBox1.Text;
            SqlCommand cmd = new SqlCommand("delete from GroupEvaluation where GroupId= (Select Id from evaluation where Id ='" + ID + "')", con);


            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted from GroupEvaluation");
        }
        public void deletes()
        {
            var con = Configuration.getInstance().getConnection();
            String ID = textBox1.Text;
            SqlCommand cmd = new SqlCommand("delete from GroupStudent where GroupId= (Select Id from evaluation where Id ='" + ID + "')", con);


            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted from GroupStudent");
        }
        public void deletep()
        {
            var con = Configuration.getInstance().getConnection();
            String ID = textBox1.Text;
            SqlCommand cmd = new SqlCommand("delete from GroupProject where GroupId= (Select Id from evaluation where Id ='" + ID + "')", con);


            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted from GroupProject");
        }
        private void INSERT_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            //@Department, @Session,@CGPA, @Address
            SqlCommand cmd = new SqlCommand("Insert into [Group] values ( @Created_On)", con);
            //cmd.Parameters.AddWithValue("Id", textBox1.Text);
            cmd.Parameters.AddWithValue("@Created_On", textBox2.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            ////@Department, @Session,@CGPA, @Address

            //String des = combobox1.Text;
            // if (textBox2.Text.Length == 0 && textBox1.Text.Length != 0)


            
            
            deletee();
            deletep();
            deletes();
            SqlCommand cmd = new SqlCommand("delete from [Group] where Id ='" + textBox1.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted");
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from [Group]", con);
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
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                //xtCountry.Text = row.Cells[2].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            managestudent ms= new managestudent();
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

        private void button8_Click(object sender, EventArgs e)
        {
            manageevaluations me = new manageevaluations();
            me.Show();
            this.Hide();

        }
    }
}
