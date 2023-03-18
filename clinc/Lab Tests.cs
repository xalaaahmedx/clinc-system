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
    public partial class Lab_Tests : Form
    {
        public Lab_Tests()
        {
            InitializeComponent();
            DisplayTest();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-68CAV5O;Initial Catalog=clinic;Integrated Security=True;Pooling=False");
        private void DisplayTest()
        {
            con.Open();
            string Query = "Select * from TestTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            LabTestDGV.DataSource = ds.Tables[0];
            con.Close();

        }
        int Key = 0;
        private void Clear()
        {
            LabTestTb.Text = "";
            LabCostTb.Text = "";
            Key = 0;



        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (LabCostTb.Text == "" || LabTestTb.Text == "")
            {
                    MessageBox.Show("Missing Inforamtion");
            }
            else
            {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into LabTestTbl(TestName,TestCost)values(@TN,@TC)", con);
                        cmd.Parameters.AddWithValue("@TN", LabTestTb.Text);
                        cmd.Parameters.AddWithValue("@TC", LabCostTb.Text);


                        //
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Test Added");
                        con.Close();
                        DisplayTest();
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
                this.Hide();
            }

            private void DelBtn_Click(object sender, EventArgs e)
            {
            if (Key == 0)
            {
                MessageBox.Show("Select The Lab Test");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from TestTbl where TestNum=@TKey", con);
                    cmd.Parameters.AddWithValue("@TKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Lab Test Deleted");
                    con.Close();
                    DisplayTest();
                    Clear();





                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }

        }

        private void LabTestDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LabTestTb.Text = LabTestDGV.SelectedRows[0].Cells[1].Value.ToString();
            LabCostTb.Text = LabTestDGV.SelectedRows[0].Cells[2].Value.ToString();
           
            if (LabTestTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(LabTestDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (LabCostTb.Text == "" || LabTestTb.Text == "")
            {
                MessageBox.Show("Missing Inforamtion");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update LabTestTbl set TestName=@TN,TestCost=@TC where TestNum=@TKey", con);
                    cmd.Parameters.AddWithValue("@TN", LabTestTb.Text);
                    cmd.Parameters.AddWithValue("@TC", LabCostTb.Text);
                    cmd.Parameters.AddWithValue("@TKey",Key);

                    //
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Test Updated");
                    con.Close();
                    DisplayTest();
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
