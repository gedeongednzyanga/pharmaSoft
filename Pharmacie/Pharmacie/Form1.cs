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
using Pharmacie.Classes;

namespace Pharmacie
{
    public partial class Form1 : Form
    {
        int t1 = 35;
        int t2 = 35;

        //public Login_Form login;
        //public delegate void SendId(Form1 form1);
        //public delegate void SendDate(string text);



        Approvisionnement approvisionnement = new Approvisionnement();
        Produit_userC produit = new Produit_userC();
        Sortie_Facture sortiefacture = new Sortie_Facture();
        Sortie_Service sortieservice = new Sortie_Service();

        Produit_Form frmp = new Produit_Form();
        Approvisionnement_Form frma = new Approvisionnement_Form();
        Malade_Form frmMalade = new Malade_Form();
        Agent_Form frmag = new Agent_Form();
        Sortie_Facture_Form frmsf = new Sortie_Facture_Form();
        Sortie_Service_Form frmss = new Sortie_Service_Form();
        public Form1()
        {
            InitializeComponent();
        }


        //public void Fundform_Login(Login_Form login)
        //{
        //    this.login = login;
        //}
        //public void FundDataLogin(string data)
        //{
        //    lab_user.Text = data;
        //}




        void hover_label(Label label)
        {
            label.Font =new Font(label.Font, FontStyle.Underline);
            
        }
        void leave_label(Label label)
        {
            label.Font = new Font(label.Font, FontStyle.Regular);
        }
        void hover_label_menu(Label label)
        {
            label.ForeColor = Color.Maroon;
            label.Font = new Font(label.Font, FontStyle.Underline);
        }
        void leave_label_menu(Label label)
        {
            label.ForeColor =Color.Black;
            label.Font = new Font(label.Font, FontStyle.Regular);
        }
        void enter_label_menu_haut(Label label)
        {
            label.BackColor = Color.LightGray;
            label.Font = new Font(label.Font, FontStyle.Underline);
        }
        void leave_label_menu_haut(Label label)
        {
            label.BackColor = Color.WhiteSmoke;
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
            Produit_userC produit = formF as Produit_userC;
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
        void ShowAgent(object formA)
        {
            Agents agents = formA as Agents;
            agents.Dock = DockStyle.Fill;
            panel_container.Controls.Clear();
            panel_container.Controls.Add(agents);
            panel_container.Show();
        }
        void ShowSortieFactue(object formSF)
        {
            Sortie_Facture sortiefacture = formSF as Sortie_Facture;
            sortiefacture.Dock = DockStyle.Fill;
            panel_container.Controls.Clear();
            panel_container.Controls.Add(sortiefacture);
            panel_container.Show();
        }
        void ShowSortieService(object formSS)
        {
            Sortie_Service sortieService = formSS as Sortie_Service;
            sortieService.Dock = DockStyle.Fill;
            panel_container.Controls.Clear();
            panel_container.Controls.Add(sortieService);
            panel_container.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
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

        private void label3_MouseClick(object sender, MouseEventArgs e)
        {
            ShowProduit(produit);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label7_MouseClick(object sender, MouseEventArgs e)
        {
            ShowAchat(approvisionnement);
        }

        private void label15_MouseClick(object sender, MouseEventArgs e)
        {
            ShowFournisseur(new Fournisseur());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            frmp.ShowDialog();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            ShowAgent(new Agents());
        }

        private void label18_MouseClick(object sender, MouseEventArgs e)
        {
          
            frmag.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PubCon.testFile();

            Login_Form frm = new Login_Form();
            frm.ShowDialog();


            ShowProduit(produit);
        }

        private void label11_MouseClick(object sender, MouseEventArgs e)
        {
            ShowSortieFactue(sortiefacture);
        }

        private void label10_MouseClick(object sender, MouseEventArgs e)
        {
            ShowSortieService(sortieservice);
        }

        private void label1_MouseClick_1(object sender, MouseEventArgs e)
        {
            
            frmMalade.ShowDialog();

        }

        private void label8_MouseClick_1(object sender, MouseEventArgs e)
        {
            Service_Form frmService = new Service_Form();
            frmService.ShowDialog();
        }

        private void label4_MouseClick(object sender, MouseEventArgs e)
        {
            Categorie_Form categorie = new Categorie_Form();
            categorie.ShowDialog();
        }

        private void label28_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel_container.Parent.Contains(produit)){
                frmp.ShowDialog();
            }else if (panel_container.Parent.Contains(approvisionnement)){
                frma.ShowDialog();
            }
            else if (panel_container.Parent.Contains(sortiefacture))
            {
                frmsf.ShowDialog();
            }
            else if (panel_container.Parent.Contains(sortieservice))
            {
                frmss.ShowDialog();
            }
        }

        private void lab_nouveau_MouseHover(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "lab_nouveau":
                    hover_label_menu(lab_nouveau);
                    break;
                case "label3":
                    hover_label_menu(label3);
                    break;
                case "label4":
                    hover_label_menu(label4);
                    break;
                case "label5":
                    hover_label_menu(label5);
                    break;
                case "label6":
                    hover_label_menu(label6);
                    break;
                case "label7":
                    hover_label_menu(label7);
                    break;
                case "label9":
                    hover_label_menu(label9);
                    break;
                case "label10":
                    hover_label_menu(label10);
                    break;
                case "label11":
                    hover_label_menu(label11);
                    break;
                case "label13":
                    hover_label_menu(label13);
                    break;
                case "label14":
                    hover_label_menu(label14);
                    break;
                case "label15":
                    hover_label_menu(label15);
                    break;
                case "label17":
                    hover_label_menu(label17);
                    break;
                case "label18":
                    hover_label_menu(label18);
                    break;
                case "label19":
                    hover_label_menu(label19);
                    break;
            }
        }

        private void lab_nouveau_MouseLeave(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "lab_nouveau":
                    leave_label_menu(lab_nouveau);
                    break;
                case "label3":
                    leave_label_menu(label3);
                    break;
                case "label4":
                    leave_label_menu(label4);
                    break;
                case "label5":
                    leave_label_menu(label5);
                    break;
                case "label6":
                    leave_label_menu(label6);
                    break;
                case "label7":
                    leave_label_menu(label7);
                    break;
                case "label9":
                    leave_label_menu(label9);
                    break;
                case "label10":
                    leave_label_menu(label10);
                    break;
                case "label11":
                    leave_label_menu(label11);
                    break;
                case "label13":
                    leave_label_menu(label13);
                    break;
                case "label14":
                    leave_label_menu(label14);
                    break;
                case "label15":
                    leave_label_menu(label15);
                    break;
                case "label17":
                    leave_label_menu(label17);
                    break;
                case "label18":
                    leave_label_menu(label18);
                    break;
                case "label19":
                    leave_label_menu(label19);
                    break;
            }
        }

        private void label22_MouseEnter(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "label28":
                    enter_label_menu_haut(label28);
                    break;
                case "label22":
                    enter_label_menu_haut(label22);
                    break;
                case "label24":
                    enter_label_menu_haut(label24);
                    break;
                case "label25":
                    enter_label_menu_haut(label25);
                    break;
                case "label26":
                    enter_label_menu_haut(label26);
                    break;
                case "label27":
                    enter_label_menu_haut(label27);
                    break;
                case "label29":
                    enter_label_menu_haut(label29);
                    break;
                case "label1":
                    enter_label_menu_haut(label1);
                    break;
                case "label8":
                    enter_label_menu_haut(label8);
                    break;
            }
        }

        private void label28_MouseLeave(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "label28":
                    leave_label_menu_haut(label28);
                    break;
                case "label22":
                    leave_label_menu_haut(label22);
                    break;
                case "label24":
                    leave_label_menu_haut(label24);
                    break;
                case "label25":
                    leave_label_menu_haut(label25);
                    break;
                case "label26":
                    leave_label_menu_haut(label26);
                    break;
                case "label27":
                    leave_label_menu_haut(label27);
                    break;
                case "label29":
                    leave_label_menu_haut(label29);
                    break;
                case "label1":
                    leave_label_menu_haut(label1);
                    break;
                case "label8":
                    leave_label_menu_haut(label8);
                    break;
            }
        }
    }
}
