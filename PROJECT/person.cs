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
    public partial class person : Form
    {
        public person()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void INSERT_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            //@Department, @Session,@CGPA, @Address

            SqlCommand cmd = new SqlCommand("Insert into Person values ( @FirstName , @LastName , @Contact ,@Email,@DateOfBirth,@Gender)", con);
            cmd.Parameters.AddWithValue("@FirstName", fname.Text);
            cmd.Parameters.AddWithValue("@LastName", lname.Text);
            int ar;
            if (gender.SelectedIndex == 0)
            {
                ar = 1;
            }
            else if (gender.SelectedIndex == 1)
            {
                ar = 2;
            }

            else
            {
                ar = 1;
            }
            
            cmd.Parameters.AddWithValue("@Contact", contact.Text);
            cmd.Parameters.AddWithValue("@Email", email.Text);
            cmd.Parameters.AddWithValue("@Gender", ar);
            DateTime date = new DateTime();
           // string pattern = "0:yyyy/mm/yy h:mm:ss zzz";
            date = DateTime.Parse(dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@DateofBirth", date);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Saved");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Person", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            //String ID = textBox1.Text;
            SqlCommand cmd = new SqlCommand("Update Person set FirstName=@FirstName ,LastName=@LastName , Contact=@Contact, Email=@Email, DateOfBirth=@DateOfBirth, Gender=@Gender  where Id ='" + id.Text + "'", con);
            cmd.Parameters.AddWithValue("@FirstName", fname.Text);
            cmd.Parameters.AddWithValue("@LastName", lname.Text);
            int ar;
            if (gender.SelectedIndex == 0)
            {
                ar = 1;
            }
            else if (gender.SelectedIndex == 1)
            {
                ar = 2;
            }

            else
            {
                ar = 1;
            }

            cmd.Parameters.AddWithValue("@Contact", contact.Text);
            cmd.Parameters.AddWithValue("@Email", email.Text);
            cmd.Parameters.AddWithValue("@Gender", ar);
            DateTime date = new DateTime();
            // string pattern = "0:yyyy/mm/yy h:mm:ss zzz";
            date = DateTime.Parse(dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@DateofBirth", date);

            cmd.ExecuteNonQuery();
           

            MessageBox.Show("Successfully Updated");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                id.Text = row.Cells[0].Value.ToString();
                fname.Text = row.Cells[1].Value.ToString();
                lname.Text = row.Cells[2].Value.ToString();
                contact.Text = row.Cells[3].Value.ToString();
                email.Text = row.Cells[4].Value.ToString();
                dateTimePicker1.Text= row.Cells[5].Value.ToString();
                gender.Text = row.Cells[6].Value.ToString();
            }
        }

        private void person_Load(object sender, EventArgs e)
        {
            id.Text = "Don't type here, select from table";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            String ID = id.Text;
            SqlCommand cmd = new SqlCommand("select * from Person where Id= '" + ID + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully searched");
        }
        public void deleteg()
        {
            var con = Configuration.getInstance().getConnection();
            String ID = id.Text;
            SqlCommand cmd = new SqlCommand("delete from GroupStudent where StudentId= (Select Id from Person where Id ='" + ID + "')", con);


            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted from GroupStudent");
        }
        public void deletes()
        {
            var con = Configuration.getInstance().getConnection();
            String ID = id.Text;
            SqlCommand cmd = new SqlCommand("delete from Student where Id= (Select Id from Person where Id ='" + ID + "')", con);


            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted from Student");
        }
        private void button11_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            ////@Department, @Session,@CGPA, @Address

            //String des = combobox1.Text;
            // if (textBox2.Text.Length == 0 && textBox1.Text.Length != 0)


            SqlCommand cmd = new SqlCommand("delete from Person where Id ='" + id.Text + "'", con);
            deleteg();
            deletes();

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted");
        }
    }
    
}
