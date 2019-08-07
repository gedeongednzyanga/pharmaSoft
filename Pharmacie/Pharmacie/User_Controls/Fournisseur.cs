using ManageSingleConnexion;
using Pharmacie.Classes;
using ApprovisionnementLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacie.User_Controls
{
    public partial class Fournisseur : UserControl
    {
        int idFournisseur = 0;
        public Fournisseur()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            int n = 0;
            for (n = 0; n <= 24; n++)
            {
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = "1";
                dataGridView1.Rows[n].Cells[1].Value = "Pacetamole";
                dataGridView1.Rows[n].Cells[2].Value = "Malvidi";
                dataGridView1.Rows[n].Cells[3].Value = "20mg";
                dataGridView1.Rows[n].Cells[4].Value = "Comprilé";
                dataGridView1.Rows[n].Cells[5].Value = "100";
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = "2";
                dataGridView1.Rows[n].Cells[1].Value = "Amidole";
                dataGridView1.Rows[n].Cells[2].Value = "Mwanda";
                dataGridView1.Rows[n].Cells[3].Value = "3mg";
                dataGridView1.Rows[n].Cells[4].Value = "Comprimé";
                dataGridView1.Rows[n].Cells[5].Value = "1300";
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = "3";
                dataGridView1.Rows[n].Cells[1].Value = "Vodca";
                dataGridView1.Rows[n].Cells[2].Value = "Cortide";
                dataGridView1.Rows[n].Cells[3].Value = "50mg";
                dataGridView1.Rows[n].Cells[4].Value = "Sirop";
                dataGridView1.Rows[n].Cells[5].Value = "3000";
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = "4";
                dataGridView1.Rows[n].Cells[1].Value = "Vodca";
                dataGridView1.Rows[n].Cells[2].Value = "Cortide";
                dataGridView1.Rows[n].Cells[3].Value = "50mg";
                dataGridView1.Rows[n].Cells[4].Value = "Sirop";
                dataGridView1.Rows[n].Cells[5].Value = "3000";
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = "5";
                dataGridView1.Rows[n].Cells[1].Value = "Amidole";
                dataGridView1.Rows[n].Cells[2].Value = "Mwanda";
                dataGridView1.Rows[n].Cells[3].Value = "3mg";
                dataGridView1.Rows[n].Cells[4].Value = "Comprimé";
                dataGridView1.Rows[n].Cells[5].Value = "1300";
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = "6";
                dataGridView1.Rows[n].Cells[1].Value = "Pacetamole";
                dataGridView1.Rows[n].Cells[2].Value = "Malvidi";
                dataGridView1.Rows[n].Cells[3].Value = "20mg";
                dataGridView1.Rows[n].Cells[4].Value = "Comprilé";
                dataGridView1.Rows[n].Cells[5].Value = "100";
            }
        }

        private void Fournisseur_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void InitialiseChamps()
        {
            idFournisseur = 0;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ApprovisionnementLib.Fournisseurs fournisseur = new ApprovisionnementLib.Fournisseurs();

                InitialiseChamps();

                idFournisseur = fournisseur.Nouveau();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                ImplementeConnexion.Instance.Conn.Close();
            }
        }
        void SaveData()
        {
            try
            {

                ApprovisionnementLib.Fournisseurs fournisseur = new ApprovisionnementLib.Fournisseurs();

                if (idFournisseur == 0 || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "")
                    MessageBox.Show("Completez tous les champs svp !!!", "Champs Obligatiore", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                else
                {
                    fournisseur.Id = idFournisseur;
                    fournisseur.Nom = textBox2.Text;
                    fournisseur.TypePersonne = comboBox1.Text.ToString();
                    fournisseur.Adresse = textBox3.Text;
                    fournisseur.Contact = textBox4.Text;
                    fournisseur.Email = textBox5.Text;
                    fournisseur.Enregistrer(fournisseur);

                    InitialiseChamps();
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
        void DeleteData()
        {
            try
            {
                ApprovisionnementLib.Fournisseurs fournisseur = new ApprovisionnementLib.Fournisseurs();

                if (idFournisseur == 0)
                    MessageBox.Show("Erreur lor du suppression, veuillez selectionné une ligne dans le tableau de fournisseur", "Delete error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    fournisseur.Supprimer(idFournisseur);

                    InitialiseChamps();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erreureur lors de suppression : " + ex.Message, "Echec", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                ImplementeConnexion.Instance.Conn.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
    }
}
