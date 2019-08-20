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
        public Form1 form1;
        //public delegate void SendId(Login_Form login);
        public delegate void Sendata(string text);
        


        public Login_Form()
        {
            InitializeComponent();
        }

        public void FundForm1(Form1 form1)
        {
            this.form1 = form1;
        }
        public void FundDataForm1(string data)
        {
            textBox1.Text = data;
        }
        void Envoyer()
        {
            Sendata send = new Sendata(form1.FundDataLogin);
            send(UserSession.GetInstance().UserName);
        }

        private void label4_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PubCon.testlog = DynamicClasses.GetInstance().loginTest(textBox1.Text, textBox2.Text);
                Envoyer();
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

        private void Login_Form_Load(object sender, EventArgs e)
        {
            //SendId sendId = new SendId(form1.Fundform_Login);
            //sendId(this);
        }
    }
}
