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
        void LoadData()
        {
            int n = 0;
            for (n = 0; n <= 24; n++)
            {
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = "1";
                dataGridView1.Rows[n].Cells[1].Value = "Pacetamole";
                dataGridView1.Rows[n].Cells[2].Value = "Malvidi";
                dataGridView1.Rows[n].Cells[3].Value = "20mg";
                dataGridView1.Rows[n].Cells[4].Value = "Comprilé";
                dataGridView1.Rows[n].Cells[5].Value = "100";
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = "2";
                dataGridView1.Rows[n].Cells[1].Value = "Amidole";
                dataGridView1.Rows[n].Cells[2].Value = "Mwanda";
                dataGridView1.Rows[n].Cells[3].Value = "3mg";
                dataGridView1.Rows[n].Cells[4].Value = "Comprimé";
                dataGridView1.Rows[n].Cells[5].Value = "1300";
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = "3";
                dataGridView1.Rows[n].Cells[1].Value = "Vodca";
                dataGridView1.Rows[n].Cells[2].Value = "Cortide";
                dataGridView1.Rows[n].Cells[3].Value = "50mg";
                dataGridView1.Rows[n].Cells[4].Value = "Sirop";
                dataGridView1.Rows[n].Cells[5].Value = "3000";
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = "4";
                dataGridView1.Rows[n].Cells[1].Value = "Vodca";
                dataGridView1.Rows[n].Cells[2].Value = "Cortide";
                dataGridView1.Rows[n].Cells[3].Value = "50mg";
                dataGridView1.Rows[n].Cells[4].Value = "Sirop";
                dataGridView1.Rows[n].Cells[5].Value = "3000";
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = "5";
                dataGridView1.Rows[n].Cells[1].Value = "Amidole";
                dataGridView1.Rows[n].Cells[2].Value = "Mwanda";
                dataGridView1.Rows[n].Cells[3].Value = "3mg";
                dataGridView1.Rows[n].Cells[4].Value = "Comprimé";
                dataGridView1.Rows[n].Cells[5].Value = "1300";
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = "6";
                dataGridView1.Rows[n].Cells[1].Value = "Pacetamole";
                dataGridView1.Rows[n].Cells[2].Value = "Malvidi";
                dataGridView1.Rows[n].Cells[3].Value = "20mg";
                dataGridView1.Rows[n].Cells[4].Value = "Comprilé";
                dataGridView1.Rows[n].Cells[5].Value = "100";
            }
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
