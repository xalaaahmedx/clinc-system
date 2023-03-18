using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace clinc
{
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
            DisplayPat();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\xalaa\OneDrive\Documents\clinc1.mdf;Integrated Security=True;Connect Timeout=30");
        private void DisplayPat()
        {
            con.Open();
            string Query = "Select * from PatientTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PatienttDGV.DataSource = ds.Tables[0];
            con.Close();

        }
        private void Clear()
        {
            PNameTb.Text = "";
            PgenTb.SelectedIndex = 0;
            PHivcb.SelectedIndex = 0;
            Paddtb.Text = "";
            Paphonetb.Text = "";
            Pallertb.Text = "";
          
        }


        private void addbtn_Click(object sender, EventArgs e)
        {
            if (PNameTb.Text == "" || Pallertb.Text == "" || Paddtb.Text == "" ||Paphonetb.Text == "" || PgenTb.SelectedIndex == -1 || PHivcb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Inforamtion");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into PatientTbl(PatName,PatGen,PatDOB,PatAdd,PatPhone,Pathiv,Patall)values(@PN,@PG,@PD,@PA,@PP,@PH,@PAll)", con);
                    cmd.Parameters.AddWithValue("@PN", PNameTb.Text);
                    cmd.Parameters.AddWithValue("@PG", PgenTb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PD", PatDate.Value.Date);
                    cmd.Parameters.AddWithValue("@PA", Paddtb.Text);
                    cmd.Parameters.AddWithValue("@PP", Paphonetb.Text);
                    cmd.Parameters.AddWithValue("@PH", PHivcb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PAll", Pallertb.Text);

                    //
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Added");
                    con.Close();
                    DisplayPat();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }


            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            if (PNameTb.Text == "" || Pallertb.Text == "" || Paddtb.Text == "" || Paphonetb.Text == "" || PgenTb.SelectedIndex == -1 || PHivcb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Inforamtion");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update into PatientTbl set PatName=@PN,PatGen=@PG,PatDOB=@PD,PatAdd=@PA,PatPhone=@PP,Pathiv=@PH,Patall=@PAll where PatientId=@PKey", con);
                    cmd.Parameters.AddWithValue("@PN", PNameTb.Text);
                    cmd.Parameters.AddWithValue("@PG", PgenTb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PD", PatDate.Value.Date);
                    cmd.Parameters.AddWithValue("@PA", Paddtb.Text);
                    cmd.Parameters.AddWithValue("@PP", Paphonetb.Text);
                    cmd.Parameters.AddWithValue("@PH", PHivcb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PAll", Pallertb.Text);
                    cmd.Parameters.AddWithValue("@Pkey", Key);
                    //
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Updated");
                    con.Close();
                    DisplayPat();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }


            }
        }
        int Key = 0;
        private void PatienttDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PNameTb.Text = PatienttDGV.SelectedRows[0].Cells[1].Value.ToString();
            PgenTb.SelectedItem = PatienttDGV.SelectedRows[0].Cells[2].Value.ToString();
            PatDate.Text = PatienttDGV.SelectedRows[0].Cells[3].Value.ToString();
            Paddtb.Text = PatienttDGV.SelectedRows[0].Cells[4].Value.ToString();
            Paphonetb.Text = PatienttDGV.SelectedRows[0].Cells[5].Value.ToString();
            PHivcb.SelectedItem = PatienttDGV.SelectedRows[0].Cells[6].Value.ToString();
            Pallertb.Text = PatienttDGV.SelectedRows[0].Cells[7].Value.ToString();
           
            
            





            if (PNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(PatienttDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Patient");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from PatientTbl where PatId=@PKey", con);
                    cmd.Parameters.AddWithValue("@PKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Deleted");
                    con.Close();
                    DisplayPat();
                    Clear();





                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }

        }
    }
    
}
