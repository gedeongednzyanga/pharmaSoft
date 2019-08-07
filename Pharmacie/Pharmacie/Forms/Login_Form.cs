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

            //var form = new Form1();
            //SendId sendId = new SendId(form.Fundform_Login);
            //sendId(this);
            //form.Show();

            Form1 frm = new Form1();
            frm.lab_user.Visible = false;
            frm.lab_user.Text = this.textBox1.Text.Trim();
            frm.lab_user.Visible = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Sendata senddata = new Sendata(form1.FundDataLogin);
            //senddata(textBox1.Text);
        }
    }
}
