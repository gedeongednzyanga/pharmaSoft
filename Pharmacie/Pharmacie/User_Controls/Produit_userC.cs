using System;
using ProduitLib;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacie.Forms;

namespace Pharmacie.User_Controls
{
    public partial class Produit_userC : UserControl
    {
        public Produit_userC()
        {
            InitializeComponent();
        }
        //void RefreshData(Malade mal)
        //{
        //    dataGridView1.DataSource = mal.AllMalade();
        //}
        private void Charger_Produit(Produit produit)
        {
            //Produit produit = new Produit();
            dataGridView1.DataSource= produit.AllProduits();

        }
        void clic_grid()
        {
            try
            {
                int i;
                i = dataGridView1.CurrentRow.Index;


                //txtid.Text = dataGridView1["ColId", i].Value.ToString();
                lab_designation.Text = dataGridView1["Designation", i].Value.ToString();
                lab_categorie.Text = dataGridView1["Categ", i].Value.ToString();
                lab_dosage.Text = dataGridView1["Dosage", i].Value.ToString();
                lab_forme.Text = dataGridView1["Forme", i].Value.ToString();
                label8.Text = dataGridView1["Qte", i].Value.ToString();




            }
            catch (Exception ex)
            {
                MessageBox.Show("L'erreur suivant est survenue : " + ex.Message);
            }
        }
        void doubleclic_grid()
        {
            try
            {
                Produit_Form frm = new Produit_Form();
                int i;
                i = dataGridView1.CurrentRow.Index;

                frm.id = Convert.ToInt32(dataGridView1["Numero", i].Value.ToString());
                frm.designationTxt.Text = dataGridView1["Designation", i].Value.ToString();
                frm.categCombo.Text = dataGridView1["Categ", i].Value.ToString();
                frm.dosageTxt.Text = dataGridView1["Dosage", i].Value.ToString();
                frm.formeCombo.Text = dataGridView1["Forme", i].Value.ToString();
                frm.stockTxt.Text = dataGridView1["Qte", i].Value.ToString();
                frm.idCateg =Convert.ToInt32(dataGridView1["RefCateg", i].Value.ToString());
                frm.btnEnregistrer.Text = "Modifier";
                frm.btnNouveau.Enabled = false;
               

                
                frm.ShowDialog();

            }
            catch (Exception ex)
            {

                MessageBox.Show("L'erreur suivant est survenue : " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Charger_Produit(new Produit());
        }

        private void Produit_Load(object sender, EventArgs e)
        {
            Charger_Produit(new Produit());
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int i = dataGridView1.CurrentRow.Index;
                lab_designation.Text = dataGridView1["Column2", i].Value.ToString();
                lab_categorie.Text = dataGridView1["Column3", i].Value.ToString();
                lab_dosage.Text = dataGridView1["Column4", i].Value.ToString();
                lab_forme.Text = dataGridView1["Column5", i].Value.ToString();

            }
            catch (Exception)
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var bd = (BindingSource)dataGridView1.DataSource;
                var dt = (DataTable)bd.DataSource;
                dt.DefaultView.RowFilter = string.Format("Désignation Like '{"+ textBox1.Text+ "}%' OR Désignation Like '%{"+ textBox1.Text + "}'", textBox1);
                dataGridView1.Refresh();
               // (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Désignation Like '{0}%' OR Désignation Like '%{0}'", textBox1.Text);
            }catch(Exception ex)
            {
                MessageBox.Show("Errot"+ex, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void ShowFiche(object formR)
        {
            Repports fiche = formR as Repports;
            fiche.TopLevel = false;
            fiche.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(fiche);
            panel1.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ShowFiche(new Repports());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(this.groupBox2);
            panel1.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            clic_grid();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            doubleclic_grid();
        }
    }
}
