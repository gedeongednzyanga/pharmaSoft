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

            RefreshData(new Fournisseurs(), new Detail_Approv());
            dn.chargeCombo(comboBox1, "designationprod", "produit");
            
        }
        void RefreshData(Fournisseurs four, IDetail_approv detail)
        {
            dataGridView3.DataSource = four.Fournisseur();
            dataGridView1.DataSource = detail.Approvisionnements();
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

        
        

        private void button2_Click(object sender, EventArgs e)

        {
            //GenererId();
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if(idApprov == 0 || idDetailApprov == 0 || idProduit == 0 || idFournisseur == 0 || comboBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || maskedTextBox2.Text == "" || maskedTextBox1.Text == "")

        //            MessageBox.Show("Completez tous les champs svp !!!", "Champs Obligatiore", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
        //        else
        //        {

                    
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
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

            ChargementCombobox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            idProduit = dn.retourId("idproduit", "produit", "designationprod", comboBox1.Text);
        }


       

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ajouter();
        }
        void SaveApprov()
        {
            try
            {

                Approvisionnement approv = new Approvisionnement();
                if (idFournisseur == 0)
                {
                    MessageBox.Show("Veuillez selectionner le fournisseur dans le tableau à gauche !!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (dataGridView2.Rows.Count == 0)
                    MessageBox.Show("Veuillez ajouter des médicaments dans le tableau !!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    approv.Id = idApprov;
                    approv.UserSession = UserSession.GetInstance().UserName.ToString();
                    approv.Ref_Fourni = idFournisseur;

                    approv.Enregistrer(approv);

                    SaveDetail();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("L'erreur suivant est survenue : " + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        void SaveDetail()
        {
            try
            {

                IDetail_approv detail = new Detail_Approv();

                for (int i = 0; i < (dataGridView2.Rows.Count); i++)
                {

                    detail.Id = Convert.ToInt32(dataGridView2[0, i].Value.ToString());
                    detail.RefProduit = dn.retourId("idproduit", "produit", "designationprod", dataGridView2[1, i].Value.ToString());
                    detail.Quantite = Convert.ToInt32(dataGridView2[2, i].Value.ToString());
                    detail.Pu = Convert.ToInt32(dataGridView2[3, i].Value.ToString());
                    detail.DateFabric = DateTime.Parse(dataGridView2[4, i].Value.ToString());
                    detail.DateExpiration = DateTime.Parse(dataGridView2[5, i].Value.ToString());
                    detail.RefApprov = idApprov;

                    detail.Enregistrer(detail);

                    ChargementCombobox();

                }


                dataGridView2.Rows.Clear();
                button4.Enabled = true;
                button2.Enabled = false;
                //idEnteteSortie = 0;

            }
            catch (Exception ex)
            {

                MessageBox.Show("L'erreur suivant est survenue : " + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        void Ajouter()
        {
            try
            {
                IDetail_approv detail = new Detail_Approv();

                int rowCount;

                if (idApprov == 0)
                {
                    MessageBox.Show("Avant chaque opération d'enregistrement veuillez cliqué d'abord sur le bouton Nouveau en bas du formulaire", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (comboBox1.SelectedIndex == -1 || textBox3.Text == "" || textBox2.Text == "" || maskedTextBox2.Text == "" || maskedTextBox1.Text == "")
                {
                    MessageBox.Show("Completez tous les champs svp !!!", "Champs Obligatiore", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
                else if (int.Parse(textBox3.Text) <= 0)
                {
                    MessageBox.Show("Impossible d'enregistrer une quantité inférieur ou egal à 0 !!!", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    textBox3.ForeColor = Color.Red;
                }
                else
                {
                    textBox3.ForeColor = Color.Black;
                    rowCount = dataGridView2.Rows.Count;

                    if (rowCount == 0)
                    {
                        idDetailApprov = detail.Nouveau();
                        dataGridView2.Rows.Add(idDetailApprov.ToString(), comboBox1.Text, textBox2.Text, textBox3.Text, maskedTextBox2.Text,maskedTextBox1.Text);
                        label8.Text = dataGridView2.Rows.Count.ToString() + " médicaments";
                        //idDetailSortie = 0;
                    }
                    else
                    {
                        idDetailApprov = idDetailApprov + 1;
                        //for (int i = 0; i < dataGridView2.Rows.Count; i++)
                        //{


                        //    if (comboBox1.Text == dataGridView2.Rows[i].Cells[1].Value.ToString())
                        //    {
                        //        MessageBox.Show("Ce médicament existe dans cette commande", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    }
                        //    else
                        //    {
                        dataGridView2.Rows.Add(idDetailApprov.ToString(), comboBox1.Text, textBox2.Text, textBox3.Text, maskedTextBox2.Text, maskedTextBox1.Text);
                        label8.Text = dataGridView2.Rows.Count.ToString() + " médicaments";
                        //idDetailSortie = 0;
                        //}
                        //}
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("L'erreur suivant est survenue : " + ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        void Nouveau()
        {
            try
            {
                Approvisionnement entete = new Approvisionnement();

                idApprov = entete.Nouveau();

                button4.Enabled = false;

                button2.Enabled = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show("L'erreur suivant est survenue : " + ex.Message);
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView3.CurrentRow.Index;
            idFournisseur = int.Parse(dataGridView3["colN", i].Value.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Nouveau();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SaveApprov();

        }
    }
}
