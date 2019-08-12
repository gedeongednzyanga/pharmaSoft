using ManageSingleConnexion;
using ParametreConnexionLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortieLib
{
    public class Detail_Sortie_Facture : IDetails_Sortie
    {
        public DateTime Date_sortie { get; set; }
        public int Id { get; set; }
        public decimal Pt { get; set; }
        public decimal Pu { get; set; }
        public int Quantite { get; set; }
        public int Ref_Entete { get; set; }
        public int Ref_Produit { get; set; }
       
        public string Produit { get; set; }
        public string Dosage { get; set; }
        public string Malade { get; set; }
        public List<IDetails_Sortie> AllMedicamentMaladeOrService(int id)
        {
            List<IDetails_Sortie> lst = new List<IDetails_Sortie>();
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "SELECT_ALL_MEDICAMENTS_MALADE";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, id));

                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lst.Add(GetDetailSortie(dr));

                }
                dr.Dispose();
            }
            return lst;
        }
        public List<IDetails_Sortie> DetailsSorties()
        {
            List<IDetails_Sortie> lst = new List<IDetails_Sortie>();
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "SELECT_DETAILS_SORTI_FACTURE";
                cmd.CommandType = CommandType.StoredProcedure;
                IDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lst.Add(GetDetailSortie(rd));
                }
                rd.Dispose();
                rd.Close();
            }
            return lst;
        }
        public void Enregistrer(IDetails_Sortie approv)
        {
            
                if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                    ImplementeConnexion.Instance.Conn.Open();
                using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT_DETAIL_SORTIE_FACTURE";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, Id));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@quantite", 10, DbType.Int32, Quantite));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@pu", 10, DbType.Decimal, Pu));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@refprod", 4, DbType.Int32, Ref_Produit));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@refentete", 5, DbType.Int32, Ref_Entete));


                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Enregistrement reussie !!!", "Reussite", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            

        }
        public int Nouveau()
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "select max(iddetail) as lastId from detail_sortie_facture";
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
        public IDetails_Sortie OneProduitDetail(string produit)
        {
            IDetails_Sortie detailapprov = new Detail_Sortie_Facture();
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "SELECT_ONE_PRODUIT_SORTIE_DETAILS";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@produit", 4, DbType.String, produit));

                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    detailapprov = GetDetailSortie(dr);
                }
                dr.Dispose();
            }
            return detailapprov;
        }
        public void Supprimer(int id)
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {

                cmd.CommandText = "DELETE_DETAIL_SORTIE_FACTURE";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, Id));
                cmd.ExecuteNonQuery();
            }
        }
        private IDetails_Sortie GetDetailSortie(IDataReader rd)
        {
            IDetails_Sortie detailsortie = new Detail_Sortie_Facture();

            detailsortie.Id = Convert.ToInt32(rd["Numéro"].ToString());
            detailsortie.Produit = rd["Produit"].ToString();
            detailsortie.Dosage = rd["Dosage"].ToString();
            detailsortie.Quantite = Convert.ToInt32(rd["Quantité"].ToString());
            detailsortie.Pu = Convert.ToDecimal(rd["PU"].ToString());
            detailsortie.Pt = Convert.ToDecimal(rd["PT"].ToString());
            detailsortie.Date_sortie = Convert.ToDateTime(rd["[Date de sortie]"].ToString());
            


            return detailsortie;
        }
    }
}
