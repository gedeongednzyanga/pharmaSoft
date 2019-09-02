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
using Pharmacie.Classes;

namespace Pharmacie.User_Controls
{
    public partial class Inventaire : UserControl
    {
        int code_prod;
        int i;
        string dosage, forme;
        double pu, pt;
        DateTime expiration;
        public Inventaire()
        {
            InitializeComponent();
        }
        void Load_Product ()
        {
            dataGridView1.DataSource = DynamicClasses.GetInstance().Load_data("Affichage_Produit_Pv_Dexpir");
        }
        void clic_grid()
        {
            try
            {
                int i;
                i = dataGridView1.CurrentRow.Index;
                code_prod = Convert.ToInt32(dataGridView1["Numéro", i].Value.ToString());
                lab_designation.Text = dataGridView1["Produit", i].Value.ToString();
                expiration =Convert.ToDateTime(dataGridView1["D. Expiration", i].Value.ToString());
                dosage = dataGridView1["Dosage", i].Value.ToString();
                forme = dataGridView1["Forme", i].Value.ToString();
                lab_stock.Text = dataGridView1["Stock", i].Value.ToString();
                pu = Convert.ToDouble(dataGridView1["Pu", i].Value.ToString());
                pt = Convert.ToDouble(dataGridView1["PT", i].Value.ToString());
                // Get_Detail_Approv(new Detail_Approv());
            }
            catch (Exception)
            {
                MessageBox.Show("Impossible de faire l'inventaire pour ce produit !!!", "Message...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Inventaire_Load(object sender, EventArgs e)
        {
            Load_Product();
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

        private void button2_Click(object sender, EventArgs e)
        {
            //dataGridView1.Sort(new TriClasse(SortOrder.Ascending));
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
            dataGridView2.Rows.Add(i + 1, lab_designation.Text.Trim(), dosage, forme, lab_stock.Text.Trim(), Qte_physique.Text.Trim(),
                lab_ecart.Text.Trim(),  pu, pt, expiration.ToShortDateString());
            i = i + 1;
        }
    }
}
