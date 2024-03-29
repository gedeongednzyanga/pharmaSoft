﻿using ManageSingleConnexion;
using ParametreConnexionLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProduitLib
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public int Nouveau()
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "select max(idcat) as lastId from categorie";
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
        public void Enregistrer(Categorie cat)
        {

                if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                    ImplementeConnexion.Instance.Conn.Open();
                using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT_CATEGORIE";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, Id));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@designation", 100, DbType.String, Designation));

                    cmd.ExecuteNonQuery();
                   


                }
            
            

        }
        public void Supprimer(int id)
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {

                cmd.CommandText = "DELETE_CATEGORIE";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, id));
                cmd.ExecuteNonQuery();
            }
        }
        public List<Categorie> AllCategorie()
        {
            List<Categorie> lst = new List<Categorie>();
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "SELECT_CATEGORIE";
                cmd.CommandType = CommandType.StoredProcedure;
                IDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lst.Add(GetCategorie(rd));
                }
                rd.Dispose();
                rd.Close();
            }
            return lst;
        }

        private Categorie GetCategorie(IDataReader rd)
        {
            Categorie categ = new Categorie();

            categ.Id = Convert.ToInt32(rd["Numéro"].ToString());
            categ.Designation = rd["Catégorie"].ToString();
           
            return categ;
        }

    }
}
