using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacieUtilities
{
    public class ClsSMS
    {
        int code;
        string NumeroTutaire;
        string CorpsMessage, DateEnvoie;
        int EtatSms;
        string Utilisateur;

        public int Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        public string NumeroTutaire1
        {
            get
            {
                return NumeroTutaire;
            }

            set
            {
                NumeroTutaire = value;
            }
        }

        public string CorpsMessage1
        {
            get
            {
                return CorpsMessage;
            }

            set
            {
                CorpsMessage = value;
            }
        }

        public string DateEnvoie1
        {
            get
            {
                return DateEnvoie;
            }

            set
            {
                DateEnvoie = value;
            }
        }

        public int EtatSms1
        {
            get
            {
                return EtatSms;
            }

            set
            {
                EtatSms = value;
            }
        }

        public string Utilisateur1
        {
            get
            {
                return Utilisateur;
            }

            set
            {
                Utilisateur = value;
            }
        }
    }
}
