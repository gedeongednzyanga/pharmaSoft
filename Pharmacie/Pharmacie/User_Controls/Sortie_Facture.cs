using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SortieLib;

namespace Pharmacie.User_Controls
{
    public partial class Sortie_Facture : UserControl
    {
        public Sortie_Facture()
        {
            InitializeComponent();
        }

        private void Sortie_Facture_Load(object sender, EventArgs e)
        {
            RefreshData(new Detail_Sortie_Facture());
        }
        
        void RefreshData(IDetails_Sortie detail)
        {

            dataGridView1.DataSource = detail.DetailsSorties();
        }
        void Cherche(Detail_Sortie_Facture fact)
        {
            dataGridView1.DataSource = fact.Research("Affichage_details_sortie_facture", "designationprod", textBox1.Text);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Cherche(new Detail_Sortie_Facture());
        }
    }
}
