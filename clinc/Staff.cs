using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace clinc
{
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
            DisplayRec();

        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-68CAV5O;Initial Catalog=clinic;Integrated Security=True;Pooling=False");

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (RnameTB.Text == "" || Rpassword.Text == "" || RphoneTb.Text == "" || Raddress.Text == "")
            {
                MessageBox.Show("Missing Inforamtion");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update ReceptionistTbl set RecepName=@RN,RecepPhone=@RP,RecepAdd=@RA,RecepPass=@RPA where RecepId =@RKey", con);
                    cmd.Parameters.AddWithValue("@RN", RnameTB.Text);
                    cmd.Parameters.AddWithValue("@RP", RphoneTb.Text);
                    cmd.Parameters.AddWithValue("@RA", Raddress.Text);
                    cmd.Parameters.AddWithValue("@RPA", Rpassword.Text);
                    cmd.Parameters.AddWithValue("@RKey", Key);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Receptionist Updated");
                    con.Close();
                    DisplayRec();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }




            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

                if ( Key==0)
                {
                    MessageBox.Show("Select The Customer Information");
                }
                else
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Delete from ReceptionistTbl where RecepId=@RKey", con);
                        cmd.Parameters.AddWithValue("@RKey", Key);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Receptionist Deleted");
                        con.Close();
                        DisplayRec();
                        Clear();

                

                    

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }

                }

            
        }
        private void DisplayRec()
        {
            con.Open();
            string Query = "Select * from ReceptionistTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            StaffGDV.DataSource = ds.Tables[0];
            con.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (RnameTB.Text == "" || Rpassword.Text == "" || RphoneTb.Text == "" || Raddress.Text == "")
            {
                MessageBox.Show("Missing Inforamtion");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ReceptionistTbl(RecepName,RecepPhone,RecepAdd,RecepPass)values(@RN,@RP,@RA,@RPA)", con);
                    cmd.Parameters.AddWithValue("@RN", RnameTB.Text);
                    cmd.Parameters.AddWithValue("@RP", RphoneTb.Text);
                    cmd.Parameters.AddWithValue("@RA", Raddress.Text);
                    cmd.Parameters.AddWithValue("@RPA", Rpassword.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Receptionist Added");
                    con.Close();
                    DisplayRec();
                    Clear();                    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void Clear()
        {
            RnameTB.Text = "";
            Rpassword.Text = "";
            RphoneTb.Text = "";
            Raddress.Text = "";
            Key = 0;
        }


        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Staff_Load(object sender, EventArgs e)
        {

        }
        int Key = 0;
        private void StaffGDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            RnameTB.Text = StaffGDV.SelectedRows[0].Cells[1].Value.ToString();
            RphoneTb.Text = StaffGDV.SelectedRows[0].Cells[2].Value.ToString();
            Raddress.Text = StaffGDV.SelectedRows[0].Cells[3].Value.ToString();
            Rpassword.Text = StaffGDV.SelectedRows[0].Cells[4].Value.ToString();
            if (RnameTB.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32( StaffGDV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }
    }
}
