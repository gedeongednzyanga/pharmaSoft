using AgentLib;
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
    public partial class Service_Form : Form
    {
        int idService = 0;
        public Service_Form()
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
                Service service = new Service();

                InitialiseChamps();

                idService = service.Nouveau();
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
        void InitialiseChamps()
        {
            idService = 0;
            designationTxt.Clear();
            dosageTxt.Clear();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        void SaveData()
        {
            try
            {
                Service service = new Service();
                if (idService == 0 || designationTxt.Text == "" || dosageTxt.Text == "")
                {
                    MessageBox.Show("Completez tous les champs svp !!!", "Champs Obligatiore", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
                else
                {
                    service.Id = idService;
                    service.Designation = designationTxt.Text;
                    service.Responsable = dosageTxt.Text;

                    service.Enregistrer(service);

                    InitialiseChamps();

                    AllRefresh();
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
        void DeleteData()
        {
            try
            {
                Service service = new Service();
                if (idService == 0)
                    MessageBox.Show("Veuillez selectionner un champ dans le tableau svp !!!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    service.Supprimer(idService);

                    InitialiseChamps();

                    AllRefresh();
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show("Erreureur lors de suppression : " + ex.Message, "Echec", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                ImplementeConnexion.Instance.Conn.Close();
            }
        }
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
        void SelectData()
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Service service = new Service();

                    service = (Service)dataGridView1.SelectedRows[0].DataBoundItem;

                    idService = service.Id;
                    designationTxt.Text = service.Designation.ToString();
                    dosageTxt.Text = service.Responsable.ToString();

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
        void RefreshData(Service service)
        {
            dataGridView1.DataSource = service.AllServices();
        }
        void AllRefresh()
        {
            try
            {
                
                RefreshData(new Service());
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

        private void Service_Form_Load(object sender, EventArgs e)
        {
            AllRefresh();
        }
    }
    
}
