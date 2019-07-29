using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacieUtilities
{
    public class ClsGetdatas
    {
        public static ClsGetdatas _instance = null;

        private int testeconne;

        public static ClsGetdatas GetInstance()
        {
            if (_instance == null)
                _instance = new ClsGetdatas();
            return _instance;
        }

        public int Testeconne
        {
            get
            {
                return testeconne;
            }

            set
            {
                testeconne = value;
            }
        }
    }
}
