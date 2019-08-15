using Pharmacie.Classes;
using PharmacieUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacie.Forms
{
    public partial class Login_Form : Form
    {
        //public delegate void SendId(Login_Form login);
        //public Form1 form1;
        //public delegate void Sendata(string text);


        public Login_Form()
        {
            InitializeComponent();
        }

        //public void FundForm1(Form1 form1)
        //{
        //    this.form1 = form1;
        //}
        //public void FundDataForm1(string data)
        //{
        //    textBox1.Text = data;
        //}


        private void label4_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PubCon.testlog = DynamicClasses.GetInstance().loginTest(textBox1.Text, textBox2.Text);

                if (PubCon.testlog == 1)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Sendata senddata = new Sendata(form1.FundDataLogin);
            //senddata(textBox1.Text);
        }
    }
}
