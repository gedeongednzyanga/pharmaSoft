using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortieLib
{
   public interface IDetails_Sortie
    {
        int Id { get; set; }
        int Quantite { get; set; }
        decimal Pu { get; set; }
        decimal Pt { get; set; }
        DateTime Date_sortie { get; set; }
        int Ref_Produit { get; set; }
        int Ref_Entete { get; set; }
        string Produit { get; set; }
        string Dosage { get; set; }
        string Malade { get; set; }
        int Nouveau();
        void Enregistrer(IDetails_Sortie approv);
        void Supprimer(int id);
        List<IDetails_Sortie> DetailsSorties();
        List<IDetails_Sortie> AllMedicamentMaladeOrService(int id);
        IDetails_Sortie OneProduitDetail(string produit);
        //IDetails_Sortie GetDetailSortie(IDataReader rd);


    }
}
