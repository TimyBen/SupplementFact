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

namespace SupplementFact
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeComponent();
            this.ActiveControl = txt_email;
            txt_email.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = @"Data Source=VIBEZ; Initial Catalog=Facts_Products; Integrated Security=True";
            cnn.Open();

            string user_id = txt_email.Text;
            string password = txt_Password.Text;
            string sql = "Select ACCT_ID, PASSWORD FROM tblUsers WHERE UserID='" + txt_email.Text + "' AND Password='" + txt_Password.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login Successful !");
                using (frmMain frmM = new frmMain())
                {
                    frmM.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Invalid Login!, please Check your Username and Password.");
            }
            //MessageBox.Show("Conncetion Open !");
            cnn.Close();
        }
    }
}
