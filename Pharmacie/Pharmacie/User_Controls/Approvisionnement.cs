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
    }
}
