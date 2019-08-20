using System;
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

namespace Pharmacie.User_Controls
{
    public partial class Approvisionnement : UserControl
    {
        public Approvisionnement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Approvisionnement_Form frma = new Approvisionnement_Form();
            frma.ShowDialog();
        }

        private void Approvisionnement_Load(object sender, EventArgs e)
        {
            RefreshData(new Detail_Approv());
        }
        void RefreshData(IDetail_approv detail)
        {
            
            dataGridView1.DataSource = detail.Approvisionnements();
        }
    }
}
