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

namespace Employee_Ms
{
    public partial class View : Form
    {


        public View()
        {
            InitializeComponent();
        }


        readonly SqlConnection con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\OneDrive\Documents\EMS.mdf;Integrated Security=True;Connect Timeout=30");

        private void Fetchemp()
        {
            try
            {

                con.Open();

                string query = "select * from ETBL  WHERE EmpId = '" + textBox1.Text + "'";

                SqlCommand cmd = new SqlCommand(query, con);

                DataTable dt = new DataTable();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);

                foreach(DataRow dr in dt.Rows)
                {

                    label11.Text = dr["EmpId"].ToString();
                    label12.Text = dr["EmpName"].ToString();
                    label13.Text = dr["EmpGen"].ToString();
                    label14.Text = dr["EmpAdd"].ToString();
                    label15.Text = dr["EmpPos"].ToString();
                    label16.Text = dr["EmpDob"].ToString();
                    label17.Text = dr["EmpPhone"].ToString();
                    label18.Text = dr["EmpEdu"].ToString();

                    label11.Visible = true;
                    label12.Visible = true;
                    label13.Visible = true;
                    label14.Visible = true;
                    label15.Visible = true;
                    label16.Visible = true;
                    label17.Visible = true;
                    label18.Visible = true;



                }

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefBtn_Click(object sender, EventArgs e)
        {

            Fetchemp();

        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home h = new Home();

            h.Show();

            this.Hide();
        }

        private void HOMEBtn_Click_1(object sender, EventArgs e)
        {
            Home obj = new Home();

            obj.Show();

            this.Hide();
        }
    }
}
