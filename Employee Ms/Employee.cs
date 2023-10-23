using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Ms
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();

            DisplayEMp();
        }

        readonly SqlConnection con = new SqlConnection(connectionString : @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\OneDrive\Documents\EMS.mdf;Integrated Security=True;Connect Timeout=30");

        private void DisplayEMp()
        {
            try
            {
                con.Open();

                string Query = "select * from ETBL";

                SqlDataAdapter sda = new SqlDataAdapter(Query,con);

                SqlCommandBuilder builder = new SqlCommandBuilder(sda);

                var ds = new DataSet();

                sda.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

                con.Close();


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {

            Home h = new Home();

            h.Show();

            this.Hide();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {


            try
            {

                if(textBox1.Text==" " || textBox2.Text == " " || textBox3.Text ==" " || textBox4.Text ==" ")
                {

                    MessageBox.Show("MIssing Information");

                    


                }

                else
                {
                    con.Open();

                    string Query = "insert into ETBL values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox2.SelectedItem.ToString() + "','" + dateTimePicker1.Value.Date + "','" + textBox4.Text + "','" + comboBox1.SelectedItem.ToString()+ "','" + comboBox4.SelectedItem.ToString() + "')";

                    SqlCommand cmd = new SqlCommand(Query,con);

                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Record Entered Sucessfully");

                    DisplayEMp();


                }







            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally
            {
                con.Close();
            }

        }

        private void Employee_Load(object sender, EventArgs e)
        {
            DisplayEMp();
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if(textBox1.Text == " ")
                {
                    MessageBox.Show("Enter The Employee Id");
                }
                else
                {
                    con.Open();

                    string query = "delete from ETBL WHERE EmpId = '" + textBox1.Text + "';";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Record Deleted Sucessfully");

                    DisplayEMp();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally
            {
                con.Close();
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            comboBox1.Text = " ";
            textBox3.Text = " ";
            comboBox2.Text = " ";
            textBox4.Text = " ";
            comboBox4.Text = " ";

        }

       


        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

            comboBox4.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {

            con.Open();

            string query = " UPDATE ETBL SET EmpName = @EmpName,EmpAdd=@EmpAdd,EmpPos =@EmpPos , EmpDob= @EmpDob,EmpPhone=@EmpPhone,EmpGen=@EmpGen, EmpEdu=@EmpEdu WHERE  EmpId=@EmpId ";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@EmpName", textBox2.Text);

            cmd.Parameters.AddWithValue("@EmpName", textBox2.Text);
            cmd.Parameters.AddWithValue("@EmpAdd", textBox3.Text);
            cmd.Parameters.AddWithValue("@EmpPos", comboBox2.Text);
            cmd.Parameters.AddWithValue("@EmpDob", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@EmpPhone", textBox4.Text);
            cmd.Parameters.AddWithValue("@EmpGen", comboBox1.Text);
            cmd.Parameters.AddWithValue("@EmpEdu", comboBox4.Text);
            cmd.Parameters.AddWithValue("@EmpId", textBox1.Text);

            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Record Updated Sucessfully");

            DisplayEMp();


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


