using ManageSingleConnexion;
using ParametreConnexionLib;
using PharmacieUtilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacie.Classes
{
    public class DynamicClasses
    {
        SqlDataReader dr = null;
        public static DynamicClasses _intance = null;

        public static DynamicClasses GetInstance()
        {
            if (_intance == null)
                _intance = new DynamicClasses();
            return _intance;
        }

        public void chargeCombo(ComboBox cmb, string nomChamp, string nomTable)
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = @"select " + nomChamp + " from " + nomTable + "";

                IDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    string de = rd[nomChamp].ToString();
                    cmb.Items.Add(de);
                }
                rd.Close();
                rd.Dispose();
                cmd.Dispose();
            }
        }

        public int retourId(string champCode, string nomTable, string champCondition, string valeur)
        {
            int identifiant = 0;
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = @"select " + champCode + " from " + nomTable + " where " + champCondition + " = '" + valeur + "'";

                IDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    identifiant = int.Parse(rd[champCode].ToString());
                }
                rd.Close();
                rd.Dispose();
                cmd.Dispose();
            }
            return identifiant;
        }
        public int retourStock(string champStock, string nomTable, string champCondition, string valeur)
        {
            int identifiant = 0;
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = @"select " + champStock + " from " + nomTable + " where " + champCondition + " = '" + valeur + "'";

                IDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    identifiant = int.Parse(rd[champStock].ToString());
                }
                rd.Close();
                rd.Dispose();
                cmd.Dispose();
            }
            return identifiant;
        }

        public int loginTest(string nom, string password)
        {
            int count = 0;
            string username = "";
            string niveau = "";
            try
            {
                if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                    ImplementeConnexion.Instance.Conn.Open();
                using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
                {
                    cmd.CommandText = "SP_Login";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@pseudo", 50, DbType.String, nom));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@pass", 200, DbType.String, password));
                    SqlCommand comande = (SqlCommand)cmd;
                    dr = comande.ExecuteReader();
                    while (dr.Read())
                    {
                        niveau = dr["niveau_acces"].ToString();
                        username = dr["noms"].ToString();
                        count += 1;
                    }
                    if (count == 1)
                    {
                        MessageBox.Show("La connection a reussie !!!!!!");
                        UserSession.GetInstance().AccessLevel = niveau;
                        UserSession.GetInstance().UserName = username;
                        
                    }
                    else
                    {
                        MessageBox.Show("Echec de Connexion");
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dr.Close();
            }
            return count;
        }

    }
}
