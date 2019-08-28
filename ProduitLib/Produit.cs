using ManageSingleConnexion;
using ParametreConnexionLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduitLib
{
    public class Produit : IProduit
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public string Dosage { get; set; }
        public string Forme { get; set; }
        public int QteStock { get; set; }
        public int Ref_Categ { get; set; }
        public string Categorie { get; set; }
        public int Nouveau()
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "select max(idproduit) as lastId from produit";
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
        public void Supprimer(int id)
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {

                cmd.CommandText = "DELETE_PRODUIT";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, id));
                cmd.ExecuteNonQuery();
            }
        }

        private IProduit GetDetailProduit(IDataReader rd)
        {
            IProduit prod = new Produit();

            prod.Id = Convert.ToInt32(rd["Numéro"].ToString());
            prod.Designation = rd["Produit"].ToString();
            prod.Categorie = rd["Catégorie"].ToString();
            prod.Dosage = rd["Dosage"].ToString();
            prod.Forme = rd["Forme"].ToString();
            prod.QteStock = Convert.ToInt32(rd["Quantité en Stock"].ToString());
            
            return prod;
        }

        public void Enregistrer(IProduit prod)
        {
            
                if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                    ImplementeConnexion.Instance.Conn.Open();
                using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT_PRODUIT";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, Id));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@designation", 50, DbType.String, Designation));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@dosage", 50, DbType.String, Dosage));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@forme", 50, DbType.String, Forme));
                    //cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "", 100, DbType.Int32, QteStock));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@refcategorie", 100, DbType.Int32, Ref_Categ));

                    cmd.ExecuteNonQuery();
                    

                    //MessageBox.Show("Enregistrement reussi svp !!!", "Reussite", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
           
        }

        public List<IProduit> AllProduits()
        {
            List<IProduit> lst = new List<IProduit>();
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "SELECT_PRODUIT";
                cmd.CommandType = CommandType.StoredProcedure;
                IDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lst.Add(GetDetailProduit(rd));
                }
                rd.Dispose();
                rd.Close();
            }
            return lst;
        }

        public IProduit OneProduit(int id)
        {
            IProduit prod = new Produit();
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "SELECT_ONE_PRODUIT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, id));

                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    prod = GetDetailProduit(dr);
                }
                dr.Dispose();
            }
            return prod;
        }

        public List<IProduit> Research(string NomTable, string Champs1, string Champs2, string Champs3, string recherche)
        {
            List<IProduit> lst = new List<IProduit>();
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "select * from " + NomTable + " WHERE " + Champs1 + " LIKE '%" + recherche + "%' or " + Champs2 + " LIKE '%" + recherche + "%' or " + Champs3 + " LIKE '%" + recherche + "%' ";
                //cmd.CommandType = CommandType.StoredProcedure;
                IDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lst.Add(GetDetailProduit(rd));
                }
                rd.Dispose();
                rd.Close();
            }
            return lst;
        }

    }
}
