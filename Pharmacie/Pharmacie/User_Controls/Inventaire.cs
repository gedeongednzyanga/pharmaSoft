using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProduitLib;

namespace Pharmacie.User_Controls
{
    public partial class Inventaire : UserControl
    {
        int code_prod;
        int i;
        string dosage, forme, categorie;
        public Inventaire()
        {
            InitializeComponent();
        }
        void Load_Product (Produit produit)
        {
            dataGridView1.DataSource = produit.AllProduits();
        }
        void clic_grid()
        {
            try
            {
                int i;
                i = dataGridView1.CurrentRow.Index;
                code_prod = Convert.ToInt32(dataGridView1["Numero", i].Value.ToString());
                lab_designation.Text = dataGridView1["Designation", i].Value.ToString();
                categorie = dataGridView1["Categ", i].Value.ToString();
                dosage = dataGridView1["Dosage", i].Value.ToString();
                forme = dataGridView1["Forme", i].Value.ToString();
                lab_stock.Text = dataGridView1["Qte", i].Value.ToString();
               // Get_Detail_Approv(new Detail_Approv());
            }
            catch (Exception ex)
            {
                MessageBox.Show("L'erreur suivant est survenue : " + ex.Message);
            }
        }

        private void Inventaire_Load(object sender, EventArgs e)
        {
            Load_Product(new Produit());
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            clic_grid();
        }

        private void Qte_physique_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(Qte_physique.Text)){
                    Qte_physique.Text = "0";
                }
                else {
                    if (int.Parse(lab_stock.Text) < int.Parse(Qte_physique.Text))
                    {
                        lab_ecart.Text = (int.Parse(Qte_physique.Text) - int.Parse(lab_stock.Text)).ToString();
                    }
                    else { lab_ecart.Text = (int.Parse(lab_stock.Text) - int.Parse(Qte_physique.Text)).ToString(); }
                } 
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Qte_physique_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox3.Text.Trim());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            else
                return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add(i + 1, lab_designation.Text.Trim(), dosage, forme,categorie, lab_stock.Text.Trim(),
                categorie, Qte_physique.Text.Trim(), lab_ecart.Text.Trim());
            i = i + 1;
        }
    }
}
