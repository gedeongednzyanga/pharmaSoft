using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortieLib
{
   public interface IEntete_Sortie
    {
        int Id { get; set; }
        int Ref { get; set; }
        int UserSession { get; set; }
        int Nouveau();
        void Enregistrer(IEntete_Sortie entete);
        void Supprimer(int id);
    }
}
