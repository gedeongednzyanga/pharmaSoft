using ManageSingleConnexion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacieUtilities
{
    public class ClsConnexion
    {
        ConnexionType connectionType = new ConnexionType();

        public static ClsConnexion _instance = null;

        public static ClsConnexion GetInstance()
        {
            if (_instance == null)
                _instance = new ClsConnexion();
            return _instance;
        }
        public void connecter()
        {
            try
            {
                Connexion connexion = new Connexion();

                connexion.Serveur = File.ReadAllText(ClsConstantes.Table.serveur.ToString()).Trim();
                connexion.Database = File.ReadAllText(ClsConstantes.Table.database.ToString()).Trim();
                connexion.User = File.ReadAllText(ClsConstantes.Table.user.ToString()).Trim();
                connexion.Password = File.ReadAllText(ClsConstantes.Table.password.ToString()).Trim();

                ImplementeConnexion.Instance.Initialise(connexion, connectionType);
                ImplementeConnexion.Instance.Conn.Open();
                MessageBox.Show("Connection Succefully !!!", "Succefully", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                ClsGetdatas.GetInstance().Testeconne = 0;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message);
                ClsGetdatas.GetInstance().Testeconne = 0;
            }
            //catch (MySql.Data.MySqlClient.MySqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    clsgetdata.GetInstance().Testeconne = 0;
            //}
            //catch (NpgsqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    clsgetdata.GetInstance().Testeconne = 0;
            //}
            finally
            {
                if (ImplementeConnexion.Instance.Conn != null)
                {
                    if (ImplementeConnexion.Instance.Conn.State == System.Data.ConnectionState.Open)
                    {
                        ImplementeConnexion.Instance.Conn.Close();
                    }
                }
            }
        }
    }
}
