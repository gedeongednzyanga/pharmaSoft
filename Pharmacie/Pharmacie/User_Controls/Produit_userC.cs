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
using ApprovisionnementLib;
using Pharmacie.Reports;
using Pharmacie.Classes;

namespace Pharmacie.User_Controls
{
    public partial class Produit_userC : UserControl
    {
        int code_prod;
       
        public Produit_userC()
        {
            InitializeComponent();
        }
       
        private void Get_Detail_Approv(Detail_Approv approv)
        {
            dataGridView2.DataSource = approv.OneProduiDetail(code_prod);
        }
        private void Charger_Produit(Produit produit)
        {
            dataGridView1.DataSource= produit.AllProduits();
        }
        void clic_grid()
        {
            try
            {
                int i;
                i = dataGridView1.CurrentRow.Index;
                code_prod = Convert.ToInt32(dataGridView1["Numero", i].Value.ToString());
                lab_designation.Text = dataGridView1["Designation", i].Value.ToString();
                lab_categorie.Text = dataGridView1["Categ", i].Value.ToString();
                lab_dosage.Text = dataGridView1["Dosage", i].Value.ToString();
                lab_forme.Text = dataGridView1["Forme", i].Value.ToString();
                lab_stock.Text = dataGridView1["Qte", i].Value.ToString();
                Get_Detail_Approv(new Detail_Approv());
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
           Get_Detail_Approv(new Detail_Approv());
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                recherche(new Produit());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Errot"+ex, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void recherche(Produit produit)
        {

            dataGridView1.DataSource = produit.Research("Affichage_Produit", "Produit", "Catégorie", "Forme", textBox1.Text);
        }
        //private void recherche(Produit produit)
        //{
        //    dataGridView1.DataSource = produit.AllProduits();
        //}
        void ShowFiche(object formR)
        {
            Repports fiche = formR as Repports;
            fiche.TopLevel = false;
            fiche.Dock = DockStyle.Fill;
            fiche.crystalReportViewer1.ReportSource = new Fiche_Stock_detail();
            fiche.crystalReportViewer1.Refresh();
            panel1.Controls.Clear();
            panel1.Controls.Add(fiche);
            panel1.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            groupBox_detail.Visible = false;
            groupBox_Fiche.Visible = true;
            Fiche_Stock_detail fiche = new Fiche_Stock_detail();
            DynamicClasses.GetInstance().call_Rapport(code_prod);
            fiche.Database.Tables["ConsommationMoyenne"].SetDataSource(DynamicClasses.GetInstance().ds.Tables[0]);
            fiche.Database.Tables["Affichage_Mouvement_Stock"].SetDataSource(DynamicClasses.GetInstance().ds.Tables[1]);
            crystalReportViewer1.ReportSource = fiche;
            crystalReportViewer1.Refresh();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            groupBox_Fiche.Visible = false;
            groupBox_detail.Visible = true;

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            clic_grid();
           
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            doubleclic_grid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void label16_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                //int i = dataGridView1.Columns.IndexOf(Numero);
                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur ==> " + ex.Message, "Erreur ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //int i = dataGridView1.Columns.IndexOf(Numero);
               // dataGridView3.Sort(new TriClasse(SortOrder.Descending));
               // dataGridView1.Sort(new TriClasse(SortOrder.Descending));

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur ==> "+ ex.Message,"Erreur ...",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Repports rep = new Repports();
            Fiche_Stock fiche_stock = new Fiche_Stock();
            fiche_stock.SetDataSource(DynamicClasses.GetInstance().call_report("Affichage_Mouvement_Stock", "designationprod", lab_designation.Text.Trim()));
            rep.crystalReportViewer1.ReportSource = fiche_stock;
            rep.crystalReportViewer1.Refresh();
            rep.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Repports rep = new Repports();
            Liste_ProduitPv liste_prod = new Liste_ProduitPv();
            //fiche_stock.SetDataSource(DynamicClasses.GetInstance().call_report("Affichage_Mouvement_Stock", "designationprod", lab_designation.Text.Trim()));
            rep.crystalReportViewer1.ReportSource = liste_prod;
            rep.crystalReportViewer1.Refresh();
            rep.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
          //  Array.Reverse(dataGridView1.Columns["", dataGridView1.Columns.IndexOf[1]);
        }
    }
}
