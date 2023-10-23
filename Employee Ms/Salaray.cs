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
    public partial class Salaray : Form
    {
        public Salaray()
        {
            InitializeComponent();
        }


        readonly SqlConnection con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\OneDrive\Documents\EMS.mdf;Integrated Security=True;Connect Timeout=30");



        private void Fetchemp()
        {




            try
            {



                if (Eid.Text == "  ")
                {
                    MessageBox.Show("Enter Employee ID");
                }
                else
                {

                    con.Open();

                    string query = "select * from ETBL  WHERE EmpId = '" + Eid.Text + "'";

                    SqlCommand cmd = new SqlCommand(query, con);

                    DataTable dt = new DataTable();

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    sda.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {

                        En.Text = dr["EmpName"].ToString();
                        Ep.Text = dr["EmpPos"].ToString();


                    }

                    con.Close();
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







            private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home obj = new Home();

            obj.Show();

            this.Hide();
        }

        private void FetchBtn_Click(object sender, EventArgs e)
        {
            Fetchemp();
        }

        int Dailybase;
        int total;

        private void ViewBtn_Click(object sender, EventArgs e)
        {


            if (Ep.Text == "")
            {
                MessageBox.Show("Select An Employee");
            }

            else if (Wd.Text == " " || Convert.ToInt32(Wd.Text) > 28)
            {

                MessageBox.Show(" Enter a Valid Number Of Days ");

            }

            else
            {
               if(Ep.Text== "Manager")
                {
                    Dailybase = 1200;
                }
                 else if (Ep.Text == "Senior Developer")
                {
                    Dailybase = 1000;
                }

                else if (Ep.Text == "Junior Developer")
                {
                    Dailybase = 950;
                }
                else
                {
                    Dailybase = 800;
                }

                total = Dailybase * Convert.ToInt32(Wd.Text);

                SS.Text = "  Employee Id :  "    + Eid.Text +  "  \n  "  + "Employee Name : "         +   En.Text  + "  \n  " + "Employee Position :  "     +    Ep.Text  + "  \n  "      +   "Daily Salary :  "  +  Dailybase  +  "  \n  "  +  "Total Amount :  " +  total;

            }

        }
    }
}
