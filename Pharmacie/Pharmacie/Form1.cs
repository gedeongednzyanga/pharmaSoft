using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacie.Forms;
using Pharmacie.User_Controls;

namespace Pharmacie
{
    public partial class Form1 : Form
    {
        int t1 = 35;
        int t2 = 35;
        public Form1()
        {
            InitializeComponent();
        }
        void hover_label(Label label)
        {
            label.Font =new Font(label.Font, FontStyle.Underline);
            
        }
        void leave_label(Label label)
        {
            label.Font = new Font(label.Font, FontStyle.Regular);
        }
        //void Show(object from)
        //{
            //if (panel_container.Controls.Count > 0)
            //    this.panel_container.Controls.RemoveAt(0);
            //Produit_Form produit = formF as Produit_Form;
            //produit.TopLevel = false;
            //produit.Dock = DockStyle.Fill;
            //this.panel_container.Controls.Add(produit);
            //this.panel_container.Tag = produit;
            //produit.Show();
        //}
        private void Form1_Click(object sender, EventArgs e)
        {
            this.panel_achat.Size = new Size(this.panel_achat.Width, t2);
            this.panel_medicament.Size = new Size(this.panel_medicament.Width, t1);
        }
        void ShowProduit(object formF)
        {
            Produit produit = formF as Produit;
            produit.Dock = DockStyle.Fill;
            panel_container.Controls.Clear();
            panel_container.Controls.Add(produit);
            panel_container.Show();
        }
        void ShowAchat(object formF)
        {
            Approvisionnement approvisionnement = formF as Approvisionnement;
            approvisionnement.Dock = DockStyle.Fill;
            panel_container.Controls.Clear();
            panel_container.Controls.Add(approvisionnement);
            panel_container.Show();
        }
        void ShowFournisseur(object formF)
        {
            Fournisseur fournisseur = formF as Fournisseur;
            fournisseur.Dock = DockStyle.Fill;
            panel_container.Controls.Clear();
            panel_container.Controls.Add(fournisseur);
            panel_container.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ShowProduit(new Produit());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowAchat(new Approvisionnement());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowFournisseur(new Fournisseur());
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
           
            if (panel_medicament.Height == 35)
            {
                this.panel_medicament.Size = new Size(this.panel_medicament.Width, t1);
                timer1.Start();
            }
            else { panel_medicament.Height = 35; }
               
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (t1 > 140)
            {
                timer1.Stop();
            }
            else {
                this.panel_medicament.Size = new Size(this.panel_medicament.Width, t1);
                t1 += 15; }
        }

        private void label8_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel_achat.Height == 35)
            {
                this.panel_achat.Size = new Size(this.panel_achat.Width, t2);
                timer2.Start();
            }
            else { this.panel_achat.Height = 35; }
     
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (t2 > 140)
            {
                timer2.Stop();
            }
            else { this.panel_achat.Size = new Size(this.panel_achat.Width, t2);
                t2 += 15;
            }
        }

        private void accueilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inventaire.Visible = false;
            configuration.Visible = false;
            accueil.Visible = true;
        }

        private void repportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accueil.Visible = false;
            configuration.Visible = false;
            inventaire.Visible = true;
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accueil.Visible = false;
            inventaire.Visible = false;
            configuration.Visible = true;
        }

        private void lab_medicament_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void lab_medicament_MouseLeave(object sender, EventArgs e)
        {
            //leave_label(lab_medicament);
        }

        private void lab_medicament_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void panel_medicament_MouseEnter(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "panel_medicament":
                    hover_label(lab_medicament);
                    break;
                case "panel_sortie":
                    hover_label(lab_sortie);
                    break;
                case "panel_fourni":
                    hover_label(lab_fournisseur);
                    break;
                case "panel_agent":
                    hover_label(lab_agent);
                    break;
            }
        }

        private void panel_achat_MouseLeave(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "panel_medicament":
                    leave_label(lab_medicament);
                    break;
                case "panel_achat":
                    leave_label(lab_achat);
                    break;
                case "panel_sortie":
                    leave_label(lab_sortie);
                    break;
                case "panel_fourni":
                    leave_label(lab_fournisseur);
                    break;
                case "panel_agent":
                    leave_label(lab_agent);
                    break;
            }
        }

        private void panel_achat_MouseEnter(object sender, EventArgs e)
        {
            
                    hover_label(lab_achat);
          
        }
    }
}
