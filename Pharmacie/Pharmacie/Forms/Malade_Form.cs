using MaladeLib;
using ManageSingleConnexion;
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
    public partial class Malade_Form : Form
    {
        int idMalade = 0;
        public Malade_Form()
        {
            InitializeComponent();
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            try
            {
                Malade mal = new Malade();

                InitialseChamps();

                idMalade = mal.Nouveau();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                ImplementeConnexion.Instance.Conn.Close();
            }
        }
        void InitialseChamps()
        {
            idMalade = 0;
            designationTxt.Clear();
            formeCombo.SelectedIndex = -1;
            dosageTxt.Clear();
            stockTxt.Clear();
        }
        void SaveMalade()
        {
            try
            {
                Malade mal = new Malade();

                if (idMalade == 0 || designationTxt.Text == "" || formeCombo.Text == "" || dosageTxt.Text == "" || stockTxt.Text == "")
                {
                    MessageBox.Show("Completez tous les champs svp !!!", "Champs Obligatiore", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
                else
                {
                    mal.Id = idMalade;
                    mal.Noms = designationTxt.Text;
                    mal.Sex = formeCombo.Text.Equals(Sexe.Masculin.ToString()) ? Sexe.Masculin : Sexe.Féminin;
                    mal.NumOrdo = dosageTxt.Text;
                    mal.Maladie = stockTxt.Text;
                    mal.Enregistrer(mal);

                    InitialseChamps();

                    RefreshData(new Malade());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erreureur d'enregistrement " + ex.Message, "Echec", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                ImplementeConnexion.Instance.Conn.Close();
            }
        }
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            SaveMalade();
        }

        private void Malade_Form_Load(object sender, EventArgs e)
        {
            AllRefresh();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
       void RefreshData(Malade mal)
        {
            dataGridView1.DataSource = mal.AllMalade();
        }
        void DeleteData()
        {
            try
            {
                Malade mal = new Malade();

                mal.Supprimer(idMalade);

                RefreshData(new Malade());
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erreureur de suppression " + ex.Message, "Echec", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void AllRefresh()
        {
            try
            {
                formeCombo.DataSource = Enum.GetNames(typeof(Sexe));
                RefreshData(new Malade());
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error when loading datas, " + ex.Message, "Loading datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("Error when loading datas, " + ex.Message, "Loading datas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                ImplementeConnexion.Instance.Conn.Close();
            }
        }
        void SelectData()
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Malade mal = new Malade();

                    mal = (Malade)dataGridView1.SelectedRows[0].DataBoundItem;

                    idMalade = mal.Id;
                    designationTxt.Text = mal.Noms.ToString();
                    formeCombo.Text = mal.Sex == Sexe.Masculin ? Sexe.Masculin.ToString() : Sexe.Féminin.ToString();
                    dosageTxt.Text = mal.NumOrdo;
                    stockTxt.Text = mal.Maladie;
                }

            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error when Selecting data, " + ex.Message, "Selecting data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when Selecting data, " + ex.Message, "Selecting data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (ImplementeConnexion.Instance.Conn != null)
                {
                    if (ImplementeConnexion.Instance.Conn.State == System.Data.ConnectionState.Open)
                        ImplementeConnexion.Instance.Conn.Close();
                }
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            SelectData();
        }
    }
}
