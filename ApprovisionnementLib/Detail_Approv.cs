using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ManageSingleConnexion;
using System.Data;
using ParametreConnexionLib;

using System.IO;


namespace ApprovisionnementLib
{
    public class Detail_Approv : IDetail_approv
    {
        public DateTime DateExpiration { get; set; }
        public DateTime DateFabric { get; set; }
        public int Id { get; set; }
        public decimal Pu { get; set; }
        public int Quantite { get; set; }
        public int RefApprov { get; set; }
        public int RefProduit { get; set; }
        public string Produit { get; set; }
        public decimal Pt { get; set; }
        public DateTime DateEntree { get; set; }
        //Fonction qui affiche la liste de toutes les details des approvisionnements
        public List<IDetail_approv> Approvisionnements()
        {
            List<IDetail_approv> lst = new List<IDetail_approv>();
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "SELECT_APPROVISIONNEMENT";
                cmd.CommandType = CommandType.StoredProcedure;
                IDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lst.Add(GetDetailApprov(rd));
                }
                rd.Dispose();
                rd.Close();
            }
            return lst;
        }
        //Fonction d'enregistrement des details d'approvisionnement
        public void Enregistrer(IDetail_approv approv)
        {
            
                if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                    ImplementeConnexion.Instance.Conn.Open();
                using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT_DETAIL_APPROV";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, Id));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@quantite", 50, DbType.Int32, Quantite));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@pua", 50, DbType.Decimal, Pu));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@datefabric", 100, DbType.Date, DateFabric));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@date_expir", 100, DbType.Date, DateExpiration));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@refprod", 10, DbType.Int32, RefProduit));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@refapprov", 20, DbType.Int32, RefApprov));

                    cmd.ExecuteNonQuery();
                   

                    //MessageBox.Show("Enregistrement reussi svp !!!", "Reussite", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
            

           
        }
        //Fonction de recuperation du LastId 
        public int Nouveau()
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "select max(iddetailapprov) as lastId from detail_approv";
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
        //Fonction de recuperation des détails concernant un produit 
        public IDetail_approv OneProduiDetail(int id)
        {
            IDetail_approv detailapprov = new Detail_Approv();
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "SELECT_ONE_PRODUIT_DETAILS";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, id));

                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    detailapprov = GetDetailApprov(dr);
                }
                dr.Dispose();
            }
            return detailapprov;
        }
        //Methode de suppression
        public void Supprimer(int id)
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {

                cmd.CommandText = "DELETE_DETAIL_APPROV";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, Id));
                cmd.ExecuteNonQuery();
            }
        }
        //Fonction qui permet de lire dans la table Detail approv et affecte les resultats dans les differentes variables
        private IDetail_approv GetDetailApprov(IDataReader rd)
        {
            IDetail_approv detailappro = new Detail_Approv();
            detailappro.Id = Convert.ToInt32(rd["Numéro"].ToString());
            detailappro.Produit = rd["Produit"].ToString();
            detailappro.Quantite = Convert.ToInt32(rd["Quantité"].ToString());
            detailappro.Pu = Convert.ToDecimal(rd["[P.U]"].ToString());
            detailappro.Pt = Convert.ToDecimal(rd["[P.T]"].ToString());
            detailappro.DateFabric = Convert.ToDateTime(rd["[Date Fabrication]"].ToString());
            detailappro.DateExpiration = Convert.ToDateTime(rd["[Date Expiration],"].ToString());
            detailappro.RefProduit = Convert.ToInt32(rd["Fournisseur"].ToString());
            detailappro.DateEntree = DateTime.Parse(rd["[Date Entrée]"].ToString());

            return detailappro;
        }
    }
}
