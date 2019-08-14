using MaladeLib;
using ManageSingleConnexion;
using Pharmacie.Classes;
using PharmacieUtilities;
using SortieLib;
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
    public partial class Sortie_Facture_Form : Form
    {
        int idEnteteSortie = 0;
        int idDetailSortie = 0;
        int idProduit = 0;
        int stock = 0;
        int idMalade = 0;
        DynamicClasses dn = new DynamicClasses();
        public Sortie_Facture_Form()
        {
            InitializeComponent();
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ajouter();
        }
        void Ajouter()
        {
            try
            {
                IDetails_Sortie detail = new Detail_Sortie_Facture();

                int rowCount;

                if (idEnteteSortie == 0)
                {
                    MessageBox.Show("Avant chaque opération d'enregistrement veuillez cliqué d'abord sur le bouton Nouveau en bas du formulaire", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (comboBox1.SelectedIndex == -1 || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Completez tous les champs svp !!!", "Champs Obligatiore", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
                else if (stock <= 0 || stock < int.Parse(textBox3.Text))
                {
                    MessageBox.Show("Vérifiez votre stock avant d'effectuer cette opération!!!", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
                else
                {
                    rowCount = dataGridView2.Rows.Count;

                    if (rowCount == 0)
                    {
                        idDetailSortie = detail.Nouveau();
                        dataGridView2.Rows.Add(idDetailSortie.ToString(), comboBox1.Text, textBox3.Text, textBox4.Text, Convert.ToInt32(textBox3.Text) * Convert.ToInt32(textBox4.Text));
                        label8.Text = dataGridView2.Rows.Count.ToString() + " médicaments";
                        //idDetailSortie = 0;
                    }
                    else
                    {
                        idDetailSortie = idDetailSortie + 1;
                        //for (int i = 0; i < dataGridView2.Rows.Count; i++)
                        //{


                        //    if (comboBox1.Text == dataGridView2.Rows[i].Cells[1].Value.ToString())
                        //    {
                        //        MessageBox.Show("Ce médicament existe dans cette commande", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    }
                        //    else
                        //    {
                        dataGridView2.Rows.Add(idDetailSortie.ToString(), comboBox1.Text, textBox3.Text, textBox4.Text, Convert.ToInt32(textBox3.Text) * Convert.ToInt32(textBox4.Text));
                        label8.Text = dataGridView2.Rows.Count.ToString() + " médicaments";
                        //idDetailSortie = 0;
                        //}
                        //}
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("L'erreur suivant est survenue : "+ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Nouveau();
        }
        void Nouveau()
        {
            try
            {
                IEntete_Sortie entete = new Entete_Sortie_Facture();

                idEnteteSortie = entete.Nouveau();

                button4.Enabled = false;

                button2.Enabled = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show("L'erreur suivant est survenue : " + ex.Message);
            }
        }
        void RefreshData(Malade mal)
        {
            dataGridView3.DataSource = mal.AllMalade();
        }
        void SelectData()
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Malade mal = new Malade();


                    mal = (Malade)dataGridView1.SelectedRows[0].DataBoundItem;

                    idMalade = mal.Id;

                }

            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error when Selecting data, " + ex.Message, "Selecting data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when Selecting data, " + ex.Message, "Selecting data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (ImplementeConnexion.Instance.Conn != null)
                {
                    if (ImplementeConnexion.Instance.Conn.State == System.Data.ConnectionState.Open)
                        ImplementeConnexion.Instance.Conn.Close();
                }
            }
        }
        private void Sortie_Facture_Form_Load(object sender, EventArgs e)
        {
            RefreshData(new Malade());
            dn.chargeCombo(comboBox1, "designationprod", "produit");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            idProduit = dn.retourId("idproduit", "produit", "designationprod", comboBox1.Text);
            stock = dn.retourStock("quatitestock", "produit", "designationprod", comboBox1.Text);
            label10.Text = stock.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveEntete(); 
        }
        void SaveEntete()
        {
            try
            {

                IEntete_Sortie entete = new Entete_Sortie_Facture();
                if (idMalade == 0)
                {
                    MessageBox.Show("Veuillez selectionner le malade dans le tableau à gauche !!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if(dataGridView2.Rows.Count == 0)
                    MessageBox.Show("Veuillez ajouter des médicaments dans le tableau !!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    entete.Id = idEnteteSortie;
                    entete.UserSession = UserSession.GetInstance().UserName.ToString();
                    entete.Ref = idMalade;

                    entete.Enregistrer(entete);

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

                IDetails_Sortie detail = new Detail_Sortie_Facture();

                for (int i = 0; i < (dataGridView2.Rows.Count); i++)
                {

                    detail.Id  = Convert.ToInt32(dataGridView2[0, i].Value.ToString());
                    detail.Ref_Produit = dn.retourId("idproduit", "produit", "designationprod", dataGridView2[1, i].Value.ToString());
                    detail.Quantite = Convert.ToInt32(dataGridView2[2, i].Value.ToString());
                    detail.Pu = Convert.ToInt32(dataGridView2[3, i].Value.ToString());
                    detail.Ref_Entete = idEnteteSortie;

                    detail.Enregistrer(detail);

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

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            SelectData();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView3.CurrentRow.Index;
            idMalade = int.Parse(dataGridView3["colN", i].Value.ToString());
        }
    }
}
