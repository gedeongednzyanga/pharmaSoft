using ManageSingleConnexion;
using ParametreConnexionLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacieUtilities
{
   public class ClsPharmacie
    {
        int _codePharma;
        string _nomPharma;
        string _adressePharma;
        string _telephonePharma;
        string _mailPharma;
        Image _photo;
        string _siteweb;
        string _boitePostal;
        string _rccm;
        string _idNat;
        string _NumImpot;

        public int CodePharma
        {
            get
            {
                return _codePharma;
            }

            set
            {
                _codePharma = value;
            }
        }

        public string NomPharma
        {
            get
            {
                return _nomPharma;
            }

            set
            {
                _nomPharma = value;
            }
        }

        public string AdressePharma
        {
            get
            {
                return _adressePharma;
            }

            set
            {
                _adressePharma = value;
            }
        }

        public string TelephonePharma
        {
            get
            {
                return _telephonePharma;
            }

            set
            {
                _telephonePharma = value;
            }
        }

        public string MailPharma
        {
            get
            {
                return _mailPharma;
            }

            set
            {
                _mailPharma = value;
            }
        }

        public Image Photo
        {
            get
            {
                return _photo;
            }

            set
            {
                _photo = value;
            }
        }

        public string Siteweb
        {
            get
            {
                return _siteweb;
            }

            set
            {
                _siteweb = value;
            }
        }

        public string BoitePostal
        {
            get
            {
                return _boitePostal;
            }

            set
            {
                _boitePostal = value;
            }
        }

        public string Rccm
        {
            get
            {
                return _rccm;
            }

            set
            {
                _rccm = value;
            }
        }

        public string IdNat
        {
            get
            {
                return _idNat;
            }

            set
            {
                _idNat = value;
            }
        }

        public string NumImpot
        {
            get
            {
                return _NumImpot;
            }

            set
            {
                _NumImpot = value;
            }
        }

        private byte[] converttoByteImage(Image img)
        {
            MemoryStream ms = new MemoryStream();
            Bitmap bmpImage = new Bitmap(img);
            byte[] bytImage;
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            bytImage = ms.ToArray();
            ms.Close();
            return bytImage;
        }

        public void Enregistrer(ClsPharmacie pharma)
        {
            try
            {
                if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                    ImplementeConnexion.Instance.Conn.Open();
                using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT_PHARMACIE";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, _codePharma));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@noms", 300, DbType.String, _nomPharma));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@adresse", 500, DbType.String, _adressePharma));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@telephone", 20, DbType.String, _telephonePharma));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@mail", 100, DbType.String, _mailPharma));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@logo", int.MaxValue, DbType.Binary, converttoByteImage(Photo)));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@siteweb", 100, DbType.String, Siteweb));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@boitePostal", 50, DbType.String, BoitePostal));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@rccm", 50, DbType.String, Siteweb));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@idNat", 20, DbType.String, IdNat));
                    cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@NumImpot", 20, DbType.String, NumImpot));
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec d'enregistrement" + ex.Message);
            }
        }

        public void Supprimer(int Id)
        {
            if (ImplementeConnexion.Instance.Conn.State == ConnectionState.Closed)
                ImplementeConnexion.Instance.Conn.Open();
            using (IDbCommand cmd = ImplementeConnexion.Instance.Conn.CreateCommand())
            {
                cmd.CommandText = "DELETE_PHARMACIE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Parametre.Instance.AjouterParametre(cmd, "@id", 4, DbType.Int32, _codePharma));
                cmd.ExecuteNonQuery();

            }
        }
    }
}
