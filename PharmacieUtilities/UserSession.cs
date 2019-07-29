using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacieUtilities
{
    public class UserSession
    {
        private static UserSession inst;

        private string _userName;
        private string _accessLevel;


        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                _userName = value;
            }
        }

        public string AccessLevel
        {
            get
            {
                return _accessLevel;
            }

            set
            {
                _accessLevel = value;
            }
        }

        public static UserSession GetInstance()
        {
            if (inst == null)
            {
                inst = new UserSession();
            }

            return inst;
        }
    }
}
