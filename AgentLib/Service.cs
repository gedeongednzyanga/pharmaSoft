using ManageSingleConnexion;
using ParametreConnexionLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgentLib
{
    public class Service
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public string Responsable { get; set; }
        public int Nouveau()
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "SELECT MAX(idservice) as Lastid FROM t_service";
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
        public  void Enregistrer(Service service)
        {
                if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                    ImplementeConnexion.Instance.Conn.Open();
                using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT_SERVICE";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, Id));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@designation", 100, DbType.String, Designation));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@responsable", 100, DbType.String, Responsable));

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
                cmd.CommandText = "DELETE_SERVICE";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, id));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Suppression reussie", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        public List<Service> AllServices()
        {
            List<Service> lst = new List<Service>();
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "SELECT_SERVICE";
                cmd.CommandType = CommandType.StoredProcedure;
                IDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lst.Add(GetSevice(rd));
                }
                rd.Dispose();
                rd.Close();
            }
            return lst;
        }
        private Service GetSevice(IDataReader rd)
        {
            Service s = new Service();
            s.Id = Convert.ToInt32(rd["Numéro"].ToString());
            s.Designation = rd["Service"].ToString();
            s.Responsable = rd["Responsable"].ToString();
            

            return s;
        }
    }
}
