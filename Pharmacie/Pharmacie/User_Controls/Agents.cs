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
using AgentLib;
using Pharmacie.Classes;

namespace Pharmacie.User_Controls
{
    public partial class Agents : UserControl
    {
        public Agents()
        {
            InitializeComponent();
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

        private void Agents_Load(object sender, EventArgs e)
        {
            RefreshData(new Agent());
        }
        void RefreshData(IAgent ag)
        {
            dataGridView1.DataSource = ag.AllAgents();
            
        }
        void Recherche(Agent ag)
        {
            dataGridView1.DataSource = ag.Research("Affichage_Agent", "Agent", "fonction", "pseudo", textBox1.Text);

        }
        void loadPhoto(string chamPhoto, string id, PictureBox pic)
        {
            DynamicClasses dn = new DynamicClasses();
            dn.retreivePhoto(chamPhoto, "agent", "idagent", id, pic);
        }
        void clic_grid()
        {
            try
            {
                int i;
                i = dataGridView1.CurrentRow.Index;

                
                //txtid.Text = dataGridView1["ColId", i].Value.ToString();
                label13.Text = dataGridView1["ColNom", i].Value.ToString();
                label14.Text = dataGridView1["ColContact", i].Value.ToString();
                label15.Text = dataGridView1["ColEmail", i].Value.ToString();
                label16.Text = dataGridView1["ColSex", i].Value.ToString();
                label17.Text = dataGridView1["ColAdresse", i].Value.ToString();
                label18.Text = dataGridView1["ColPseudo", i].Value.ToString();
                label19.Text = dataGridView1["ColPassword", i].Value.ToString();
                label20.Text = dataGridView1["ColNiveau", i].Value.ToString();
                label22.Text = dataGridView1["ColFonction", i].Value.ToString();

                loadPhoto("photo", dataGridView1["ColId", i].Value.ToString(), pictureBox2);

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
                Agent_Form frm = new Agent_Form();
                int i;
                i = dataGridView1.CurrentRow.Index;

                frm.idAgent = Convert.ToInt32(dataGridView1["ColId", i].Value.ToString());
                frm.textBox1.Text = dataGridView1["ColNom", i].Value.ToString();
                frm.textBox3.Text = dataGridView1["ColAdresse", i].Value.ToString();
                frm.textBox2.Text = dataGridView1["ColEmail", i].Value.ToString();
                label16.Text = dataGridView1["ColSex", i].Value.ToString();
                frm.textBox6.Text = dataGridView1["ColFonction", i].Value.ToString();
                frm.textBox5.Text = dataGridView1["ColPseudo", i].Value.ToString();
                frm.textBox7.Text = dataGridView1["ColPassword", i].Value.ToString();
                frm.comboBox2.Text = dataGridView1["ColNiveau", i].Value.ToString();
                frm.textBox6.Text = dataGridView1["ColFonction", i].Value.ToString();
                frm.textBox4.Text = dataGridView1["ColContact", i].Value.ToString();
                frm.textBox7.Enabled = false;
                frm.button1.Enabled = false;
                if (dataGridView1["ColSex", i].Value.ToString() == "Masculin")
                {
                    frm.radioButton1.Checked = true;
                }
                else
                {
                    frm.radioButton2.Checked = true;
                }

                loadPhoto("photo", dataGridView1["ColId", i].Value.ToString(), frm.pictureBox2);

                frm.ShowDialog();

            }
            catch (Exception ex)
            {

                MessageBox.Show("L'erreur suivant est survenue : " + ex.Message);
            }
        }
        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            Agent_Form frma = new Agent_Form();
            frma.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //clic_grid();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            clic_grid();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            doubleclic_grid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshData(new Agent());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Recherche(new Agent());
        }
    }
}
