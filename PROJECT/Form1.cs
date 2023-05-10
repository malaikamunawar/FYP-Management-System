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

namespace PROJECT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //textBox2.PasswordChar = '*';
            pictureBox2.BorderStyle = BorderStyle.None;
            pictureBox1.BorderStyle = BorderStyle.None;
            button9.FlatAppearance.BorderColor = Color.FromArgb(6, 16, 43);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            managestudent ms = new managestudent();
            ms.Show();
            //this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            manageadvisors ma = new manageadvisors();
            ma.Show();
            //this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            managegroups mg = new managegroups();
            mg.Show();
            //this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            assignprojects ap = new assignprojects();
            ap.Show();
           // this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            manageevaluations me = new manageevaluations();
            me.Show();
           // this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            assignadvisors aa = new assignadvisors();
            aa.Show();
          //  this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.FlatAppearance.BorderColor = Color.FromArgb(6, 16, 43);
            button9.BackColor = Color.FromArgb(11, 30, 82);
            group g = new group();
            g.Show();
            //this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            evaluation ev = new evaluation();
            ev.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            person p = new person();
            p.Show();
        }
    }
}
