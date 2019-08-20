﻿using ManageSingleConnexion;
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
        public int id = 0;
        public int idCateg = 0;
   
        DynamicClasses dn = new DynamicClasses();

        public Produit_Form()
        {
            InitializeComponent();
        }
        //public Produit_Form(int code_prod, string produit, string dosage, string forme, string categorie, int stock_pro)
        //{
        //    this.code_prod = code_prod; this.produit = produit; this.dosage = dosage; this.forme = forme;
        //    this.categorie = categorie; this.stock_pro = stock_pro;
        //    InitializeComponent();
        //    //id = this.code_prod; designationTxt.Text = this.produit; dosageTxt.Text = this.dosage;
        //    //formeCombo.Text = this.forme; categCombo.Text = this.categorie;
        //    //stockTxt.Text = this.stock_pro.ToString();
        //}
        void ChargementComboCategorie()
        {
            dn.chargeCombo(categCombo, "designationcat", "categorie");
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            InitialiserChamps();
            this.Close();
        }
        void InitialiserChamps()
        {
            designationTxt.Clear();
            dosageTxt.Clear();
            formeCombo.SelectedIndex = -1;
            categCombo.SelectedIndex = -1;
            stockTxt.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                InitialiserChamps();

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
          idCateg =  dn.retourId("idcat", "categorie", "designationcat", categCombo.Text);
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

                if (id == 0 || designationTxt.Text == "" || dosageTxt.Text == "" || formeCombo.SelectedIndex == -1 || categCombo.Text == "" || Convert.ToInt32(stockTxt.Text) <= 0)
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

                    MessageBox.Show("Enregistrement reussi !!!", "Reussite", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
