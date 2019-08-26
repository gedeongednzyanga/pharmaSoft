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
    public partial class Sortie_Service : UserControl
    {
        public Sortie_Service()
        {
            InitializeComponent();
        }

        private void Sortie_Service_Load(object sender, EventArgs e)
        {
            RefreshData(new Detail_sortie_service());
        }
        void RefreshData(IDetails_Sortie detail)
        {

            dataGridView1.DataSource = detail.DetailsSorties();
        }
        void Chercher(Detail_sortie_service sorti)
        {
            dataGridView1.DataSource = sorti.Research("Affichage_details_sortie_service", "designationprod", textBox1.Text);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Chercher(new Detail_sortie_service());
        }
    }
}
