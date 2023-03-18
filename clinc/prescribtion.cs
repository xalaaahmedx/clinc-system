using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace clinc
{
    public partial class prescribtion : Form
    {
        public prescribtion()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-68CAV5O;Initial Catalog=clinic;Integrated Security=True;Pooling=False");
        private void DisplayDoc()
        {
            con.Open();
            string Query = "Select * from prescribtionTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DoctorDGV.DataSource = ds.Tables[0];
            con.Close();

        }
        private void Clear()
        {
            DNameTb.Text = "";
            Docphonetb.Text = "";
            Daddtb.Text = "";
            DexperTb.Text = "";
            Docpass.Text = "";
            DgenTb.SelectedIndex = 0;
            Dspeccb.SelectedIndex = 0;
            Key = 0;




        }

        private void prescribtion_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
