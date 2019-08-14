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

namespace Pharmacie.Forms
{
    public partial class Categorie_Form : Form
    {
        int idCateg = 0;
        DynamicClasses dn = new DynamicClasses();
        public Categorie_Form()
        {
            InitializeComponent();
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            try
            {
                designationTxt.Text = "";

                Categorie cat = new Categorie();

                idCateg = cat.Nouveau();
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        void ChargementListBox(Categorie categ)
        {
            try
            {
                dataGridView1.DataSource= categ.AllCategorie();

            }
            catch (Exception)
            {

                throw;
            }
        }


        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                Categorie cat = new Categorie();

                if (idCateg <= 0 || designationTxt.Text == "")
                {
                    MessageBox.Show("Completez tous les champs svp !!!", "Champs Obligatiore", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
                else
                {
                    cat.Id = idCateg;
                    cat.Designation = designationTxt.Text;

                    cat.Enregistrer(cat);

                    //listBox1.Items.Add(designationTxt.Text);

                    MessageBox.Show("Enregistrement reussi !!!", "Reussite", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Categorie_Form_Load(object sender, EventArgs e)
        {
            ChargementListBox(new Categorie());


        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if(idCateg == 0)
            {
                MessageBox.Show("Veuillez selectionner une ligne dans la liste svp !!!", "Champs vide", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            else
            {
                Categorie categ = new Categorie();
                categ.Supprimer(idCateg);

                MessageBox.Show("Suppression effectuer avec succees !!!", "Champs vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        //private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //   //idCateg = dn.retourId("idcat", "categorie", "designationcat", listBox1.SelectedItem.ToString());
        //   // designationTxt.Text = listBox1.SelectedItem.ToString();
        //}

        //private void Categorie_Form_Load_1(object sender, EventArgs e)
        //{
        //    ChargementListBox();
        //}
    }
}
