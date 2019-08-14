using AgentLib;
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
    public partial class Agent_Form : Form
    {
        Label lab_photo =new Label();
        public int idAgent = 0;
        public Agent_Form()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            InitialiserChamps();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label13.Text = textBox1.Text.Trim();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "JPG Files (*.jpg)|*.jpg| all files(*.*)|*.*";
            fd.ShowDialog();
            lab_photo.Text = fd.FileName.ToString();
            pictureBox2.ImageLocation = lab_photo.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IAgent agent = new Agent();

                InitialiserChamps();

                idAgent = agent.Nouveau();
            }
            catch (Exception ex)
            {

                MessageBox.Show("L'erreur suivante est survenue " + ex.Message);
            }
            finally
            {
                ImplementeConnexion.Instance.Conn.Close();
            }

        }
        void InitialiserChamps()
        {

            idAgent = 0;
            textBox1.Clear();
            radioButton1.Checked = true;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox2.SelectedIndex = -1;
            pictureBox2.Image = null;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveAgent();
        }
        void SaveAgent()
        {
            try
            {
                IAgent agent = new Agent();

                if (idAgent == 0 || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || comboBox2.Text == "")
                {
                    MessageBox.Show("Completez tous les champs svp !!!", "Champs Obligatiore", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
                else
                {
                    agent.Id = idAgent;
                    agent.Noms = textBox1.Text;
                    agent.Sex = radioButton1.Checked == true ? Sexe.Masculin : Sexe.Feminin;
                    agent.Adresse = textBox3.Text;
                    agent.Contact = textBox4.Text;
                    agent.Email = textBox2.Text;
                    agent.Fonction = textBox6.Text;
                    agent.Pseudo = textBox5.Text;
                    agent.Niveau = comboBox2.Text;
                    agent.PassWord = textBox7.Text;
                    agent.Photo = pictureBox2.Image;

                    agent.Enregistrer(agent);

                    InitialiserChamps();

                }



            }
            catch (Exception ex)
            {

                MessageBox.Show("Erreureur d'enregistrement " + ex.Message, "Echec", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                ImplementeConnexion.Instance.Conn.Close();
            }
        }
    }
}
