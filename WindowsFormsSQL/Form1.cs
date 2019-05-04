using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsSQL
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;

        public Form1()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["test"].ConnectionString;
            con = new SqlConnection(connectionString);
            ShowData();
        }

        private void btnInsertRecord_Click(object sender, EventArgs e)
        {
            
            con.Open();
            cmd = new SqlCommand("INSERT INTO users VALUES('" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtPhone.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show(" Data Has Been Saved in Database ");
            con.Close();
            ShowData();
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            MessageBox.Show("here");
            label1.BackColor = Color.FromArgb(255, 232, 232);
        }

        public void ShowData()
        {
            adpt = new SqlDataAdapter("SELECT * FROM users", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            dt.DefaultView.RowFilter = "firstname = 'Matthew'";
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}
