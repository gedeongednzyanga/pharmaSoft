using ManageSingleConnexion;
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
    public partial class Configuration_Form : Form
    {
        ConnexionType connexionType;
        public Configuration_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            Login_Form frmg = new Login_Form();
            Connexion cx = new Connexion();
            cx.Serveur = comboBox2.Text;
            cx.Database = textBox1.Text;
            cx.User = textBox2.Text;
            cx.Password = textBox3.Text;
            ImplementeConnexion.Instance.Initialise(cx, connexionType);
            ImplementeConnexion.Instance.Conn.Open();
            MessageBox.Show("Connexion établie", "Message Serveur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //frm.Show();
            frmg.ShowDialog();
            this.Hide();
        }
        void ChargerServer()
        {
            comboBox2.Items.Add(".");
            comboBox2.Items.Add("local");
            comboBox2.Items.Add(@".\SQLEXPRESS");
            comboBox2.Items.Add(string.Format(@"{0}", Environment.MachineName));
            comboBox2.SelectedIndex = 3;
        }
        private void Login_Form_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetNames(typeof(ConnexionType));
            comboBox1.SelectedIndex = 0;
            ChargerServer();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    connexionType = ConnexionType.SQLServer;
                    break;
                case 1:
                    connexionType = ConnexionType.MySQL;
                    break;
                case 2:
                    connexionType = ConnexionType.PostGrsSQL;
                    break;
                case 3:
                    connexionType = ConnexionType.Oracle;
                    break;
                case 4:
                    connexionType = ConnexionType.Access;
                    break;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
