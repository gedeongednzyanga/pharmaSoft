using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacie.Forms
{
    public partial class Agent_Form : Form
    {
        Label lab_photo =new Label();
        public Agent_Form()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label13.Text = textBox1.Text.Trim();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "JPG Files (*.jpg)|*.jpg| all files(*.*)|*.*";
            fd.ShowDialog();
            lab_photo.Text = fd.FileName.ToString();
            pictureBox2.ImageLocation = lab_photo.Text;
        }
    }
}
