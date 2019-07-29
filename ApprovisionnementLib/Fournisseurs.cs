using ManageSingleConnexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParametreConnexionLib;

namespace ApprovisionnementLib
{
   public class Fournisseurs
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Contact { get; set; }
        public int Nouveau()
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "select max(idfourni) as lastId from fournisseur";
                IDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["lastId"] == DBNull.Value)
                        Id = 1;
                    else
                        Id = Convert.ToInt32(dr["lastId"].ToString()) + 1;
                }
                dr.Dispose();
            }
            return Id;
        }
        public void Enregistrer(Fournisseurs f)
        {
            
                if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                    ImplementeConnexion.Instance.Conn.Open();
                using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT_FOURNISSEUR";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, Id));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@noms", 100, DbType.String, Nom));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@adresse", 100, DbType.String, Adresse));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@contact", 100, DbType.String, Contact));

                    cmd.ExecuteNonQuery();
                    
                }
            
        }
        public void Supprimer(int id)
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "DELETE_FOURNISSEUR";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, Id));
                cmd.ExecuteNonQuery();
            }
        }
        public List<Fournisseurs> Fournisseur()
        {
            List<Fournisseurs> lst = new List<Fournisseurs>();
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "procedure de selection";
                cmd.CommandType = CommandType.StoredProcedure;
                IDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lst.Add(GetDetailFournisseur(rd));
                }
                rd.Dispose();
                rd.Close();
            }
            return lst;
        }
        private Fournisseurs GetDetailFournisseur(IDataReader rd)
        {
            Fournisseurs fourni = new Fournisseurs();
            fourni.Id = Convert.ToInt32(rd["Numéro"].ToString());
            fourni.Nom = rd["Fournisseur"].ToString();
            fourni.Adresse = rd["[Adresse complète]"].ToString();
            fourni.Contact = rd["Contact"].ToString();
            

            return fourni;
        }

    }
}
