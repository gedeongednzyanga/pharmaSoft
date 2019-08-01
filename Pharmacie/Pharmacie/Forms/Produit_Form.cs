using ManageSingleConnexion;
using Pharmacie.Classes;
using ProduitLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParametreConnexionLib;

namespace Pharmacie.Forms
{
    public partial class Produit_Form : Form
    {
        int id = 0;
        int idCateg = 0;

        DynamicClasses dn = new DynamicClasses();
        public Produit_Form()
        {
            InitializeComponent();
        }
        void ChargementComboCategorie()
        {
            dn.chargeCombo(categCombo, "designationprod", "categorie");
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                designationTxt.Clear();
                dosageTxt.Clear();
                formeCombo.SelectedIndex = -1;
                categCombo.SelectedIndex = -1;
                stockTxt.Text = "0";

                IProduit pr = new Produit();
                id = pr.Nouveau();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error when renew record, " + ex.Message, "Renew record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("Error when renew record, " + ex.Message, "Renew record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Produit_Form_Load(object sender, EventArgs e)
        {
            ChargementComboCategorie();

        }

        private void categCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dn.retourId("idcat", "categorie", "designationcat", categCombo.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveMedicament();
        }
        void SaveMedicament()
        {
            try
            {
                IProduit medicament = new Produit();

                if (id == 0 || designationTxt.Text == "" || dosageTxt.Text == "" || formeCombo.SelectedIndex == -1 || categCombo.SelectedIndex == -1 || Convert.ToInt32(stockTxt.Text) <= 0)
                {
                    MessageBox.Show("Completez tous les champs svp !!!", "Champs Obligatiore", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
                else
                {
                    medicament.Id = Convert.ToInt32(id);
                    medicament.Designation = designationTxt.Text;
                    medicament.Dosage = dosageTxt.Text;
                    medicament.Forme = formeCombo.SelectedItem.ToString();
                    medicament.Ref_Categ = Convert.ToInt32(idCateg);
                    medicament.QteStock = Convert.ToInt32(stockTxt.Text);

                    medicament.Enregistrer(medicament);

                    MessageBox.Show("Enregistrement reussi svp !!!", "Reussite", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error when saving datas, " + ex.Message, "Saving datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("Error when saving datas, " + ex.Message, "Saving datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
    }
}
