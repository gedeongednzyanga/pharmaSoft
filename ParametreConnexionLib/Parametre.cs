using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametreConnexionLib
{
    public class Parametre
    {
        private Parametre()
        {
        }

        public static Parametre _intances = null;

        public static Parametre Instance

        {
            get
            {
                if (_intances == null)
                    _intances = new Parametre();
                return _intances;
            }
        }

        public IDbDataParameter AjouterParametre(IDbCommand command, string nomParametre, int taille, DbType type, object valeur)
        {
            IDbDataParameter param = command.CreateParameter();
            param.ParameterName = nomParametre;
            param.DbType = type;
            param.Size = taille;
            param.Value = valeur;

            return param;
        }
    }
}
