using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacie.Classes;

namespace Pharmacie.User_Controls
{
    public partial class Historique_ES : UserControl
    {
        public Historique_ES()
        {
            InitializeComponent();
        }
        void load_grid()
        {
           dataGridView1.DataSource= DynamicClasses.GetInstance().Load_data("Affichage_Mouvement_Stock");
        }
        private void Historique_ES_Load(object sender, EventArgs e)
        {
            load_grid();
        }
    }
}
