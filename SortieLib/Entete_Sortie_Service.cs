﻿using ManageSingleConnexion;
using ParametreConnexionLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortieLib
{
    public class Entete_Sortie_Service : IEntete_Sortie
    {
        public int Id { get; set; }

        public int Ref { get; set; }

        public string UserSession { get; set; }

        public void Enregistrer(IEntete_Sortie entete)

        {
            
                if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                    ImplementeConnexion.Instance.Conn.Open();
                using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT_ENTETE_SORTIE_SERVICE";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, Id));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@user", 100, DbType.String, UserSession));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@refservice", 10, DbType.Int32, Ref));

                    cmd.ExecuteNonQuery();
                    

                    //MessageBox.Show("Enregistrement reussi svp !!!", "Reussite", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
            
            
        }

        public int Nouveau()
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "select max(identete) as lastId from entete_sortie_service";
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

                cmd.CommandText = "DELETE_ENTETE_SORTIE_SERVICE";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, Id));
                cmd.ExecuteNonQuery();
            }
        }
    }
}
