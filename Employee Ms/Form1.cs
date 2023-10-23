using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Employee_Ms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

            //  Application.Exit();

            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Username.Text = "  ";

            Password.Text = "  ";


        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
          
               



                if (Username.Text == " " && Password.Text =="  ")
                {
                    MessageBox.Show("Missing Infromation");
                }


                else if (Username.Text =="Username" && Password.Text == "Password")
                {


                    Home H = new Home();

                    H.Show();

                    this.Hide();

                }

                else
                {
                    MessageBox.Show("Login With Your Username And Password");
                }
            }
           

        private void Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
