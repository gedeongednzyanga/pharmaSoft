using ApprovisionnementLib;
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
    public partial class Approvisionnement_Form : Form
    {
        int idApprov = 0;
        int idDetailApprov = 0;
        int idProduit = 0;
        int idFournisseur = 0;
        DynamicClasses dn = new DynamicClasses();
        UserSession us = new UserSession();
        public Approvisionnement_Form()
        {
            InitializeComponent();
        }

        void ChargementCombobox()
        {
            dn.chargeCombo(comboBox1, "designationprod", "produit");
            dn.chargeCombo(comboBox2, "nomsf", "fournisseur");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void InitialiserChamps()
        {
            idApprov = 0;
            idDetailApprov = 0;
            idProduit = 0;
            idFournisseur = 0;
            comboBox1.SelectedIndex = -1;
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox2.Clear();
            maskedTextBox1.Clear();
            comboBox2.SelectedIndex = -1;
        }
        void Initialise()
        {
            idDetailApprov = 0;
            idProduit = 0;
            comboBox1.SelectedIndex = -1;
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox2.Clear();
            maskedTextBox1.Clear();
        }
        void GenererId()
        {
            try
            {
                DialogResult result = new DialogResult();
                Approvisionnement approv = new Approvisionnement();
                IDetail_approv detailapprov = new Detail_Approv();

                if (idApprov != 0)
                {
                   result = MessageBox.Show("Voulez-vous continuez pour le fournisseur " + comboBox2.Text + " ?","Question",MessageBoxButtons.YesNo,MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        Initialise();
                        idDetailApprov = detailapprov.Nouveau();
                    }
                }
                else
                {
                    InitialiserChamps();
                    idApprov = approv.Nouveau();
                    idDetailApprov = detailapprov.Nouveau();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("L'erreur suivant est survenue : " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GenererId();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(idApprov == 0 || idDetailApprov == 0 || idProduit == 0 || idFournisseur == 0 || comboBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || maskedTextBox2.Text == "" || maskedTextBox1.Text == "" || comboBox2.Text == "")
                    MessageBox.Show("Completez tous les champs svp !!!", "Champs Obligatiore", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                else
                {

                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        void SaveDataApprovisionnement()
        {
            Approvisionnement approv = new Approvisionnement();

            approv.Id = idApprov;
            approv.UserSession = UserSession.GetInstance().UserName;
            approv.Ref_Fourni = idFournisseur;

            approv.Enregistrer(approv);
        }
        void SaveDataDetailApprovisionnement()
        {
            IDetail_approv approv = new Detail_Approv();

            approv.Id = idDetailApprov;
            approv.Quantite = Convert.ToInt32(textBox2.Text);
            approv.Pu = Convert.ToInt32(textBox3);
            approv.DateFabric = DateTime.Parse(maskedTextBox2.Text);
            approv.DateExpiration = DateTime.Parse(maskedTextBox1.Text);
            approv.RefProduit = Convert.ToInt32(idProduit);
            approv.RefApprov = Convert.ToInt32(idApprov);

            approv.Enregistrer(approv);

        }


        private void Approvisionnement_Form_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            idProduit = dn.retourId("idproduit", "produit", "designationprod", comboBox1.Text);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            idProduit = dn.retourId("idfourni", "fournisseur", "nomsf", comboBox2.Text);
        }
    }
}
