using ManageSingleConnexion;
using ParametreConnexionLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaladeLib
{
   public class Malade
    {
        public int Id { get; set; }
        public string Noms { get; set; }
        public Sexe Sex { get; set; }
        public string NumOrdo { get; set; }
        public string Maladie { get; set; }

        public int Nouveau()
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "SELECT MAX(idmalade) as Lastid FROM malade";
                IDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if (dr["Lastid"] == DBNull.Value)
                        Id = 1;
                    else
                        Id = Convert.ToInt32(dr["Lastid"].ToString()) + 1;
                }
                dr.Dispose();
            }
            return Id;
        }
        public void Enregistrer(Malade m)
        {
            
                if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                    ImplementeConnexion.Instance.Conn.Open();
                using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT_MALADE";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, Id));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@noms", 4, DbType.String, Noms));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@numero_ordo", 4, DbType.String, NumOrdo));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@maladie", 4, DbType.String, Maladie));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@sexe", 1, DbType.String, Sex == Sexe.Féminin ? "F" : "M"));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Enregistrement reussie", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
           
        }
        public void Supprimer(int id)
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {

                cmd.CommandText = "DELETE_MALADE";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, id));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Suppression reussie", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //A Revoir, c'est une liste des médicaments
        public List<Malade> AllMalade()
        {
            List<Malade> lst = new List<Malade>();
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "SELECT_MALADE";
                cmd.CommandType = CommandType.StoredProcedure;
                IDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lst.Add(GetMalade(rd));
                }
                rd.Dispose();
                rd.Close();
            }
            return lst;
        }
        private Malade GetMalade(IDataReader rd)
        {
            Malade mal = new Malade();
            mal.Id = Convert.ToInt32(rd["Numéro"].ToString());
            mal.Noms = rd["Malade"].ToString();
            mal.Sex = rd["Sexe"].ToString().Equals("M") ? Sexe.Masculin : Sexe.Féminin;
            mal.NumOrdo = rd["Ordonance"].ToString();
            mal.Maladie = rd["maladie"].ToString();

            return mal;
        }
    }
}
