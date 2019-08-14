using ManageSingleConnexion;
using PharmacieUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacie.Forms
{
    public partial class Configuration_Form : Form
    {
        ConnexionType connexionType = new ConnexionType();
        public Configuration_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    File.WriteAllText(ClsConstantes.Table.serveur, comboBox2.Text.ToString());
                    File.WriteAllText(ClsConstantes.Table.database, textBox1.Text.ToString());
                    File.WriteAllText(ClsConstantes.Table.user, textBox2.Text.ToString());
                    File.WriteAllText(ClsConstantes.Table.password, textBox3.Text.ToString());
                    ClsGetdatas.GetInstance().Testeconne = 1;
                    this.Close();
                    ClsConnexion.GetInstance().connecter();
                }
                else
                {
                    MessageBox.Show("Completez tous les champ !!!", "Saisie Obligatoire", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            Environment.Exit(0);
        }
    }
}
