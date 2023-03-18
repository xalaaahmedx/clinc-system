using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;

namespace clinc
{
    public partial class Doctors : Form
    {
        public Doctors()
        {
            InitializeComponent();
            DisplayDoc();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-68CAV5O;Initial Catalog=clinic;Integrated Security=True;Pooling=False");
        private void DisplayDoc()
        {
            con.Open();
            string Query = "Select * from DoctorTbl";
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


        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (DNameTb.Text == "" || Docpass.Text == "" || Daddtb.Text == "" || DgenTb.SelectedIndex == -1 || Dspeccb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Inforamtion");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into DoctorTbl(DocName,DocDOF,DocGen,DocSpec,DocEXP,DocPhone,DocAdd,DocPass)values(@DN,@DD,@DG,@DS,@DE,@DP,@DA,@DPA)", con);
                    cmd.Parameters.AddWithValue("@DN", DNameTb.Text);
                    cmd.Parameters.AddWithValue("@DD", docDate.Value.Date);
                    cmd.Parameters.AddWithValue("@DG", DgenTb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DS", Dspeccb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DE", DexperTb.Text);
                    cmd.Parameters.AddWithValue("@DP", Docphonetb.Text);
                    cmd.Parameters.AddWithValue("@DA", Daddtb.Text);
                    cmd.Parameters.AddWithValue("@DPA", Docpass.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor Added");
                    con.Close();
                    DisplayDoc();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }


            }
            
        
        
        }
        int Key = 0;
        private void DoctorDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DNameTb.Text = DoctorDGV.SelectedRows[0].Cells[1].Value.ToString();
            docDate.Text = DoctorDGV.SelectedRows[0].Cells[2].Value.ToString();
            DgenTb.SelectedItem = DoctorDGV.SelectedRows[0].Cells[3].Value.ToString();
            Dspeccb.SelectedItem = DoctorDGV.SelectedRows[0].Cells[4].Value.ToString();
            DexperTb.Text=DoctorDGV.SelectedRows[0].Cells[5].Value.ToString();
            Docphonetb.Text=DoctorDGV.SelectedRows[0].Cells[6].Value.ToString();
            Daddtb.Text=DoctorDGV.SelectedRows[0].Cells[7].Value.ToString();
            Docpass.Text = DoctorDGV.SelectedRows[0].Cells[8].ToString();


            
            
            
            if (DNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32( DoctorDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            if (DNameTb.Text == "" || Docpass.Text == "" || Daddtb.Text == "" || DgenTb.SelectedIndex == -1 || Dspeccb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Inforamtion");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update  DoctorTbl set DocName=@DN,DocDOF=@DD,DocGen=@DG,DocSpec=@DS,DocEXP=@DE,DocPhone=@DP,DocAdd=@DA,DocPass=@DPA where DocId=@DKey", con);
                    cmd.Parameters.AddWithValue("@DN", DNameTb.Text);
                    cmd.Parameters.AddWithValue("@DD", docDate.Value.Date);
                    cmd.Parameters.AddWithValue("@DG", DgenTb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DS", Dspeccb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DE", DexperTb.Text);
                    cmd.Parameters.AddWithValue("@DP", Docphonetb.Text);
                    cmd.Parameters.AddWithValue("@DA", Daddtb.Text);
                    cmd.Parameters.AddWithValue("@DPA", Docpass.Text);
                    cmd.Parameters.AddWithValue("@DKey", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor Edited");
                    con.Close();
                    DisplayDoc();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Customer Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from DoctorTbl where DocId=@DKey", con);
                    cmd.Parameters.AddWithValue("@DKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor Deleted");
                    con.Close();
                    DisplayDoc();
                    Clear();





                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
