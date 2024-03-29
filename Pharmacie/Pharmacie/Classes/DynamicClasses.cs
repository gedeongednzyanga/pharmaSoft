﻿using ManageSingleConnexion;
using ParametreConnexionLib;
using PharmacieUtilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Drawing;
using System.Drawing.Printing;
using System.IO;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Pharmacie.Classes
{
    public class DynamicClasses
    {
        SqlDataReader dr = null;

        SqlDataAdapter dt = null;
        SqlCommand sql = null;
        SqlConnection con;
       public  DataSet ds;
        //public DataGridPrinter MyDataPrinter;


        public static DynamicClasses _intance = null;

        public static DynamicClasses GetInstance()
        {
            if (_intance == null)
                _intance = new DynamicClasses();
            return _intance;
        }

   

        public DataTable Load_data(string nomtable)
        {
            try
            {
                if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                    ImplementeConnexion.Instance.Conn.Open();
                con = (SqlConnection)ImplementeConnexion.Instance.Conn;
                dt = new SqlDataAdapter("select * from " + nomtable + "", con);
                ds = new DataSet();
                dt.Fill(ds, nomtable);
                con.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { con.Close(); }
        }
        public DataTable call_report(string nomtable, string ref_champ, string nomchamp)
        {
            try
            {
                if(ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
                con = (SqlConnection)ImplementeConnexion.Instance.Conn;
                dt = new SqlDataAdapter("select * from " + nomtable + " where " + ref_champ + " = '" + nomchamp + "'", con);
                ds = new DataSet();
                dt.Fill(ds, nomtable);
                con.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { con.Close(); }
        }

        public void call_Rapport(int nomchamp)
        {
            try
            {
                if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                    ImplementeConnexion.Instance.Conn.Open();
                con = (SqlConnection)ImplementeConnexion.Instance.Conn;
                dt = new SqlDataAdapter("SELECT_FICHE_ST", con);
                dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                dt.SelectCommand.Parameters.Add(Parametre.Instance.AjouterParametre(dt.SelectCommand, "@codeprod", 5, DbType.Int32, nomchamp));
                ds = new DataSet();
                dt.Fill(ds);
                con.Close();
                //return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { con.Close(); }
        }



        public DataTable recherche_Infromation(string NomTable, string Nom, string Postnom, string Prenom, string recherche)
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            con = (SqlConnection)ImplementeConnexion.Instance.Conn;
            sql = new SqlCommand("select * from " + NomTable + " WHERE " + Nom + " LIKE '%" + recherche + "%' or " + Postnom + " LIKE '%" + recherche + "%' or " + Prenom + " LIKE '%" + recherche + "%' ", con);
            dt = null;
            dt = new SqlDataAdapter(sql);
            ds = new DataSet();
            dt.Fill(ds);
            con.Close();
            return ds.Tables[0];
        }
        public void retreivePhoto(string ChampPhoto, string nomTable, string ChampCode, string Valeur, PictureBox pic)
        {
            try
            {
                if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                    ImplementeConnexion.Instance.Conn.Open();
                using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT " + ChampPhoto + " from " + nomTable + " WHERE  " + ChampCode + " = " + Valeur + "";
                    dt = new SqlDataAdapter((SqlCommand)cmd);
                    Object resultat = cmd.ExecuteScalar();
                    if (DBNull.Value == (resultat))
                    {
                    }
                    else
                    {
                        Byte[] buffer = (Byte[])resultat;
                        MemoryStream ms = new MemoryStream(buffer);
                        Image image = Image.FromStream(ms);
                        pic.Image = image;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

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
                        MessageBox.Show("La connection a reussie !!!", "Message Serveur...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UserSession.GetInstance().AccessLevel = niveau;
                        UserSession.GetInstance().UserName = username;
                    }
                    else
                    {
                        MessageBox.Show("Echec de Connexion.", "Message Serveur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        #region IMPRIMER DOCUMENTS

        //public bool Imprimer_Facture(PrintDocument doc_print, DataGridView grid_toprint)
        //{
        //    PrintDialog _MyDialog_Print = new PrintDialog();
        //    _MyDialog_Print.AllowCurrentPage = false;
        //    _MyDialog_Print.AllowPrintToFile = false;
        //    _MyDialog_Print.AllowSelection = false;
        //    _MyDialog_Print.AllowSomePages = false;
        //    _MyDialog_Print.PrintToFile = false;
        //    _MyDialog_Print.ShowHelp = false;
        //    _MyDialog_Print.ShowNetwork = false;

        //    if (_MyDialog_Print.ShowDialog() != DialogResult.OK)
        //        return false;
        //    doc_print.DocumentName = "Facture du client";
        //    doc_print.PrinterSettings = _MyDialog_Print.PrinterSettings;
        //    doc_print.DefaultPageSettings = _MyDialog_Print.PrinterSettings.DefaultPageSettings;
        //    doc_print.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

        //    if (MessageBox.Show("Voulez-vous que le report soit centré sur la page ?", "Facturation - Center On Page",
        //        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        MyDataPrinter = new DataGridPrinter(grid_toprint, doc_print, true, true, "Facture Du client", new Font("Tahoma", 18,
        //            FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
        //    else
        //        MyDataPrinter = new DataGridPrinter(grid_toprint, doc_print, false, true, "Facture Du client", new Font("Tahoma", 18,
        //            FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
        //    return true;
        //}
        #endregion

    }

}
